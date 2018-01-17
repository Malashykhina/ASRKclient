using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;

namespace RESTFulWCFService
{
    public class BarcodeDbAdapter
    {
        public string connectionString = "user id=ASRK;password=krsa; data source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=10.255.102.10)(PORT=1521))(CONNECT_DATA=(SERVER=dedicated) (SERVICE_NAME = ukrpost)))";
       
        const string updateBarcodeData2 = @"UPDATE asrk_barcode SET STATUS = '{0}', USER_ID = '{1}', Date_Scan = CURRENT_TIMESTAMP WHERE BARCODE = '{2}' and STATUS = '0' and shell_barcode='{3}' and INDEX_PLACE = '{4}' ";

        const string updateBarcodeAnyway = @"UPDATE asrk_barcode SET STATUS = '{0}', USER_ID = '{1}', Date_Scan = CURRENT_TIMESTAMP WHERE BARCODE = '{2}' and INDEX_PLACE = '{3}' and shell_barcode='{4}'";

        const string sql_insert2 = @"INSERT INTO asrk_barcode
(BARCODE, INDEX_PLACE, USER_ID, OPERATION, STATUS, DATE_INSERT, barcode_shell)
VALUES (:BARCODE, :INDEX_PLACE, :USER_ID, :OPERATION, :STATUS, CURRENT_TIMESTAMP, :barcode_shell)";

        const string sql_check_shell = @"SELECT DB_UNID, Status from asrk_barcode WHERE asrk_barcode.BARCODE = :BARCODE and asrk_barcode.INDEX_PLACE = :INDEX_PLACE";

        const string sql_insert_shell = @"INSERT INTO asrk_barcode
(BARCODE, INDEX_PLACE, USER_ID, OPERATION, STATUS, DATE_INSERT, mailtype, typeinvoice, invoiceindex)
VALUES (:BARCODE, :INDEX_PLACE, :USER_ID, :OPERATION, :STATUS, CURRENT_TIMESTAMP, :mailtype, :typeinvoice, :BARCODE)";
     const string getBarcodeStatus = @"Select STATUS from asrk_barcode
WHERE asrk_barcode.BARCODE = :BARCODE";

        const string selectBarcodeData = @"Select STATUS, index_place, SHELL_BARCODE from asrk_barcode
WHERE asrk_barcode.BARCODE = :BARCODE";

        const string checkShell = @"Select SHELL_BARCODE, index_place from asrk_barcode
WHERE asrk_barcode.SHELL_BARCODE = :SHELL_BARCODE";

        const string leftInShell = @"Select SHELL_BARCODE, index_place from asrk_barcode WHERE asrk_barcode.SHELL_BARCODE = :SHELL_BARCODE and INDEX_PLACE=:INDEX_PLACE and STATUS = '0'";    //and INDEX_PLACE=:INDEX_PLACE";//     

        public static List<string> Login(string index_place, string login, string password)
        {
            List<string> DB_UNID_Status = new List<string>();
            const string sql = @"select REGISTRARID, USERNAME from asrk_users 
where  INDEX_PLACE=:INDEX_PLACE and Lower(REGISTRARLOGIN)=:REGISTRARLOGIN and asrk_users.PASSWORD=:PASSWORD";//Lower()

            var cmd = new OracleCommand(sql, Connection.getConnect());
            cmd.Parameters.Add("INDEX_PLACE", OracleDbType.Char).Value = index_place;
            cmd.Parameters.Add("REGISTRARLOGIN", OracleDbType.Char).Value = login.ToLower();
            cmd.Parameters.Add("PASSWORD", OracleDbType.Char).Value = password;
            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                DB_UNID_Status.Add(reader[0].ToString());
                DB_UNID_Status.Add(reader[1].ToString());

            }
            return DB_UNID_Status;
        }


        public static List<string> GetUnfinishedShells(string STATUS, string index_place, string operation, string typeinvoice)//, string SCANSTATE)
        {
            var result = new List<string>();
            string tmp = @"select barcode from asrk_barcode where id in
                            (select max(id)
                            from asrk_barcode where typeinvoice=:typeinvoice
                            and INDEX_PLACE = :index_place and operation = :operation
                            and unid is null
                            Group by barcode) and STATUS = :STATUS";
                //@"Select barcode from asrk_barcode WHERE STATUS = :STATUS 
//and INDEX_PLACE = :INDEX_PLACE and operation = :operation and typeinvoice = :typeinvoice";

            var cmd = new OracleCommand(tmp, Connection.getConnect());

            cmd.Parameters.Add("typeinvoice", OracleDbType.Decimal).Value = typeinvoice;
            cmd.Parameters.Add("index_place", OracleDbType.Char).Value = index_place;
            cmd.Parameters.Add("operation", OracleDbType.Char).Value = operation;
            cmd.Parameters.Add("STATUS", OracleDbType.Char).Value = STATUS;
            //cmd.Parameters.Add("SCANSTATE", OracleDbType.Char).Value = SCANSTATE;
            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(reader[0].ToString());

            }
            return result;
        }

        public static List<string> WriteBarcodeToDB(string barcode, string USER_ID, string OPERATION, string STATUS, string BARCODE_SHELL, string INDEX_PLACE, string MAILTYPE, string SCANSTATE)
        {//int
            //1-запаковано
            ////-999 если не найден баркод
            //-barcode.getStatus() если статус баркода не 0 и не 99
            ////-998 если баркод является шеллом (операция 20201)
            ////-997 если не найден текой шелл для данного отделения
            //-996 если шелл имеет статус не 0 (то есть уже запакован или отменен)
            ////-1 если упакован в текущий шелл
            ////-994 если упакован в другой шелл

            var res = new List<string>();
            var a = CheckBarcodeShell(barcode, INDEX_PLACE, BARCODE_SHELL);//a[0]-статус, a[1]-баркод шел, 
            //var bStatus= BarcodeStatus(barcode);
            if ((a == null) || (a.Count == 0))
            {
                res.Add("-999");
                return res;//not found//"-99"//(-999 если не найден баркод), одночасно у мене це і (-997 если не найден текой шелл для данного отделения)
            }
            else
            {
                if (a[0] == "2")//Status, barcode_shell 
                {
                    res.Add("-2");
                    return res;//статус -2
                }
                else
                {
                    if (a[0] == "1")//незрозуміло...
                    {
                        // return -1;
                        res.Add(a[1]);
                        res.Add(getNumberOfThingsInPackage(BARCODE_SHELL, "1", INDEX_PLACE).ToString());
                        res.Add(getNumberOfThingsInPackage(BARCODE_SHELL, "1", INDEX_PLACE, USER_ID).ToString());
                        return res;// повертаємо значення BARCODE_SHELL яке є в бд
                        //
                    }
                    else
                    {
                        //string sql_update3 = @"UPDATE asrk_barcode SET STATUS = '{0}', USER_ID = '{1}', OPERATION = '{2}', barcode_shell='{3}', Date_Scan = CURRENT_TIMESTAMP WHERE BARCODE = '{4}' and INDEX_PLACE = '{5}' and SCANSTATE='{6}' and STATUS!='2'";
                        string sql_update3 = @"UPDATE asrk_barcode SET STATUS = '{0}', USER_ID = '{1}', OPERATION = '{2}', barcode_shell='{3}', Date_Scan = CURRENT_TIMESTAMP WHERE BARCODE = '{4}' and INDEX_PLACE = '{5}' and SCANSTATE='{6}' and STATUS!='2'";
                        //status must be 0!!!!!!!!!!!

                        string updateData3 = String.Format(sql_update3, STATUS, USER_ID, OPERATION, BARCODE_SHELL, barcode, INDEX_PLACE, SCANSTATE);
                        var cmd = new OracleCommand(updateData3, Connection.getConnect());
                        cmd.CommandTimeout = 0;
                        var a1 = cmd.ExecuteNonQuery();
                        if (a1 > 0)
                        {
                            /*res.Add("1");////
                            res.Add(getNumberOfThingsInPackage(BARCODE_SHELL, "1", INDEX_PLACE).ToString());////
                            res.Add(getNumberOfThingsInPackage(BARCODE_SHELL, "1", INDEX_PLACE, USER_ID).ToString());////*/
                            //!!!!!!!!!!!!!
                            //успіх, значить повертаєм кільксть речей для цієї оболонки по цьому юзеру.
                        }
                        //if (a[1] != "")
                        //{
                        //    return Convert.ToInt32( a[1]);
                        //}
                        //else
                        //{
                        res.Add(a1.ToString());
                        res.Add(getNumberOfThingsInPackage(BARCODE_SHELL, "1", INDEX_PLACE).ToString());
                        res.Add(getNumberOfThingsInPackage(BARCODE_SHELL, "1", INDEX_PLACE, USER_ID).ToString());
                        return res;
                        // }
                    }
                }
            }
        }
    
        public static int FinishPackingShell(string shell_barcode, string STATUS, string index_place)
        {
            string tmp = @"UPDATE asrk_barcode SET STATUS = '{0}' WHERE invoiceindex = '{1}' and INDEX_PLACE = '{2}'";// and status = '1'";//!!!!!!!!!!!!!!!! status = '1'

            string updateBarcodeData3 = String.Format(tmp, STATUS, shell_barcode,  index_place);
            var cmd = new OracleCommand(updateBarcodeData3, Connection.getConnect());
            cmd.CommandTimeout = 0;
            //return 
                cmd.ExecuteNonQuery();//кількість стрічок, для яких виконали update
                return getNumberOfThingsInPackage(shell_barcode, "1", index_place);
        }

        private static int getNumberOfThingsInPackage(string barcode_shell, string status, string index_place)
        {
            List<string> DB_UNID_Status = new List<string>();
            string sql1 = @"SELECT count(*) from asrk_barcode WHERE asrk_barcode.BARCODE_SHELL = :BARCODE_SHELL 
and status = :status and index_place=:index_place";
            var cmd = new OracleCommand(sql1, Connection.getConnect());
            cmd.Parameters.Add("BARCODE_SHELL", OracleDbType.Char).Value = barcode_shell;
            cmd.Parameters.Add("status", OracleDbType.Char).Value = status;
            cmd.Parameters.Add("index_place", OracleDbType.Char).Value = index_place;            

            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();
            var reader = cmd.ExecuteReader();


            //var a1 = cmd.ExecuteNonQuery();
            if(reader.Read())//  (reader[1] != "")
            {
                return Convert.ToInt32(reader[0].ToString());
            }
            else return 0;
            //if (reader.Read())
            //{
            //    DB_UNID_Status.Add(reader[0].ToString());

            //}
            //return DB_UNID_Status;
        }
        private static int getNumberOfThingsInPackage(string barcode_shell, string status, string index_place, string USER_ID)
        {
            List<string> DB_UNID_Status = new List<string>();
            string sql1 = @"SELECT count(*) from asrk_barcode WHERE asrk_barcode.BARCODE_SHELL = :BARCODE_SHELL 
and status = :status and index_place=:index_place and USER_ID=:USER_ID";
            var cmd = new OracleCommand(sql1, Connection.getConnect());
            cmd.Parameters.Add("BARCODE_SHELL", OracleDbType.Char).Value = barcode_shell;
            cmd.Parameters.Add("status", OracleDbType.Char).Value = status;
            cmd.Parameters.Add("index_place", OracleDbType.Char).Value = index_place;
            cmd.Parameters.Add("USER_ID", OracleDbType.Char).Value = USER_ID;

            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();
            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return Convert.ToInt32(reader[0].ToString());
            }
            else return 0;
        }

        public static int CancelPackingShell(string shell_barcode, string STATUS, string index_place)
        {
            string tmp = @"UPDATE asrk_barcode SET STATUS = '{0}' WHERE (invoiceindex = '{1}' or barcode_shell = '{1}') and INDEX_PLACE = '{2}'";

            string updateBarcodeData3 = String.Format(tmp, STATUS, shell_barcode, index_place);
            var cmd = new OracleCommand(updateBarcodeData3, Connection.getConnect());
            cmd.CommandTimeout = 0;
            return cmd.ExecuteNonQuery();//кількість стрічок, для яких виконали update
        }

     /*   public static int CancelPack(string barcode, string STATUS, string index_place)
        {
            //!!!!!!!!!!!TO DO
            string tmp = @"UPDATE asrk_barcode SET STATUS = '{0}' WHERE (invoiceindex = '{1}' or barcode_shell = '{1}') and INDEX_PLACE = '{2}'";

            string updateBarcodeData3 = String.Format(tmp, STATUS, shell_barcode, index_place);
            var cmd = new OracleCommand(updateBarcodeData3, Connection.getConnect());
            cmd.CommandTimeout = 0;
            return cmd.ExecuteNonQuery();//кількість стрічок, для яких виконали update
        }*/

        private static int UpdateBarcodeData2(string barcode, string USER_ID, string STATUS, string shell_barcode, string index_place)
        {
            string updateBarcodeData3 = String.Format(updateBarcodeData2, STATUS, USER_ID, barcode, shell_barcode, index_place);
            //@"UPDATE asrk_barcode SET STATUS = '{0}', USER_ID = '{1}', Date_Scan = CURRENT_TIMESTAMP WHERE BARCODE = '{2}' and STATUS = '0' and shell_barcode='{3}' and INDEX_PLACE = '{4}' ";
            var cmd = new OracleCommand(updateBarcodeData3, Connection.getConnect());
            /*cmd.Parameters.Add("STATUS", OracleDbType.Char).Value = STATUS;
            cmd.Parameters.Add("USER_ID", OracleDbType.Char).Value = USER_ID;//OracleDbType.Int32
            cmd.Parameters.Add("BARCODE", OracleDbType.Char).Value = barcode;
            cmd.Parameters.Add("INDEX_PLACE", OracleDbType.Char).Value = index_place;*/
            cmd.CommandTimeout = 0;
            return cmd.ExecuteNonQuery();//кількість стрічок, для яких виконали update
        }

        public static int SelectBarcodeData(string barcode, string USER_ID, string STATUS, string shell_barcode, string index_place)//!!!!!!!!!!!!!!!!!!
        {
            bool hasIndex = false;
            var cmd = new OracleCommand(selectBarcodeData, Connection.getConnect());
            cmd.Parameters.Add("BARCODE", OracleDbType.Char).Value = barcode;
            cmd.CommandTimeout = 0;
            List<BarcodeData> barcodeData = new List<BarcodeData>();
            var reader = cmd.ExecuteReader();
            while(reader.Read()){
                barcodeData.Add(new BarcodeData { Barcode = barcode,
                Status=reader[0].ToString(),
                IndexPlace=reader[1].ToString(),
                ShellBarcode=reader[2].ToString()});
            }
            if (barcodeData.Count <= 0) { 
                return -1;}
            else
            {
                foreach (var data in barcodeData)
                {
                    if ((data.IndexPlace == index_place)&&(data.ShellBarcode == shell_barcode)) {
                        hasIndex = true;
                        if (data.Status == "0") 
                        {
                            return UpdateBarcodeData2(barcode, USER_ID, STATUS, shell_barcode, index_place);
                            //всі умови виконались!!! ура, записали, shell_barcode не перевіряється!!!!!!!!!!
                        }                        
                    }                    
                }
                if (!hasIndex) return -2;
                else { return -3; }
            }
           // return cmd.ExecuteNonQuery();//кількість стрічок, для яких виконали select

        }

        public static void WriteBarcodeToDB(string barcode, string USER_ID, string OPERATION, string STATUS, string shell_barcode, string INDEX_PLACE)//, string INVOICE)
        {//(barcode, user_id, "1", STATUS, shell_barcode, index_place);

            var cmd = new OracleCommand(sql_insert2, Connection.getConnect());
            cmd.Parameters.Add("BARCODE", OracleDbType.Char).Value = barcode;
            cmd.Parameters.Add("INDEX_PLACE", OracleDbType.Char).Value = INDEX_PLACE;
            cmd.Parameters.Add("USER_ID", OracleDbType.Char).Value = USER_ID;//cmd.Parameters.Add("USER_ID", OracleDbType.Int32).Value = USER_ID;
            cmd.Parameters.Add("OPERATION", OracleDbType.Char).Value = OPERATION;
            cmd.Parameters.Add("STATUS", OracleDbType.Char).Value = STATUS;
            cmd.Parameters.Add("shell_barcode", OracleDbType.Char).Value = shell_barcode;
            //cmd.Parameters.Add("INVOICE", OracleDbType.Char).Value = INVOICE;
            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();
        }

        //
        public static List<string> CheckBarcodeShell(string barcode,  string INDEX_PLACE)//string USER_ID, string OPERATION, string STATUS, string INDEX_PLACE, string mailtype)//, string INVOICE)
        {
            //const string sql_check_shell = 
//@"SELECT DB_UNID, Status from asrk_barcode WHERE asrk_barcode.BARCODE = :BARCODE and asrk_barcode.INDEX_PLACE = :INDEX_PLACE";

            List<string> DB_UNID_Status = new List<string>();
            //(barcode, USER_ID, "20201", STATUS, index_place, "0");
            var cmd = new OracleCommand(sql_check_shell, Connection.getConnect());
            cmd.Parameters.Add("BARCODE", OracleDbType.Char).Value = barcode;
            cmd.Parameters.Add("INDEX_PLACE", OracleDbType.Char).Value = INDEX_PLACE;
            //cmd.Parameters.Add("USER_ID", OracleDbType.Char).Value = USER_ID;//cmd.Parameters.Add("USER_ID", OracleDbType.Int32).Value = USER_ID;
            //cmd.Parameters.Add("OPERATION", OracleDbType.Char).Value = OPERATION;
            //cmd.Parameters.Add("STATUS", OracleDbType.Char).Value = STATUS;
            // cmd.Parameters.Add("shell_barcode", OracleDbType.Char).Value = shell_barcode;
            //cmd.Parameters.Add("INVOICE", OracleDbType.Char).Value = INVOICE;
            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                DB_UNID_Status.Add(reader[0].ToString());
                DB_UNID_Status.Add(reader[1].ToString());
                //DB_UNID_Status.Add(reader.NextResult().ToString());
               
            } 
            return DB_UNID_Status;
            //else return  null;
        }
        public static List<string> CheckBarcodeShell(string barcode, string INDEX_PLACE, string barcode_shell)
        {
            List<string> DB_UNID_Status = new List<string>();
            string sql1 = @"SELECT Status, barcode_shell from asrk_barcode WHERE asrk_barcode.BARCODE = :BARCODE and asrk_barcode.INDEX_PLACE = :INDEX_PLACE";
            //DB_UNID, 
            var cmd = new OracleCommand(sql1, Connection.getConnect());
            cmd.Parameters.Add("BARCODE", OracleDbType.Char).Value = barcode;
            cmd.Parameters.Add("INDEX_PLACE", OracleDbType.Char).Value = INDEX_PLACE;
            //cmd.Parameters.Add("barcode_shell", OracleDbType.Char).Value = barcode_shell;
            
            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                DB_UNID_Status.Add(reader[0].ToString());
                DB_UNID_Status.Add(reader[1].ToString());
               // DB_UNID_Status.Add(reader[2].ToString());
                //DB_UNID_Status.Add(reader.NextResult().ToString());

            }
            return DB_UNID_Status;
            //else return  null;
        }
        public static string WriteBarcodeShell(string barcode, string USER_ID, string OPERATION, string STATUS, string INDEX_PLACE, string mailtype, string typeinvoice)//, string INVOICE)
        {
            //(barcode, USER_ID, "20201", STATUS, index_place, "0");
            var cmd = new OracleCommand(sql_insert_shell, Connection.getConnect());
            cmd.Parameters.Add("BARCODE", OracleDbType.Char).Value = barcode;
            cmd.Parameters.Add("INDEX_PLACE", OracleDbType.Char).Value = INDEX_PLACE;
            cmd.Parameters.Add("USER_ID", OracleDbType.Char).Value = USER_ID;//cmd.Parameters.Add("USER_ID", OracleDbType.Int32).Value = USER_ID;
            cmd.Parameters.Add("OPERATION", OracleDbType.Char).Value = OPERATION;
            cmd.Parameters.Add("STATUS", OracleDbType.Char).Value = STATUS;
            cmd.Parameters.Add("mailtype", OracleDbType.Char).Value = mailtype;
            cmd.Parameters.Add("typeinvoice", OracleDbType.Char).Value = typeinvoice; 
           // cmd.Parameters.Add("shell_barcode", OracleDbType.Char).Value = shell_barcode;
            //cmd.Parameters.Add("INVOICE", OracleDbType.Char).Value = INVOICE;
            cmd.CommandTimeout = 0;
            var a = cmd.ExecuteNonQuery();
            return a.ToString();
            //var reader = cmd.ExecuteReader();
            //if (reader.Read())
            //{
            //    return reader[0].ToString();
            //}
            //else return null;
        }

        public static string UpdatePackingShell(string barcode, string USER_ID, string OPERATION, string STATUS, string INDEX_PLACE, string mailtype, string typeinvoice)//, string INVOICE)
        {
            //string sql_update3 = @"UPDATE asrk_barcode SET STATUS = '{0}', USER_ID = '{1}', OPERATION = '{2}', mailtype='{3}',typeinvoice='{4}', Date_Scan = CURRENT_TIMESTAMP WHERE BARCODE = '{5}' and INDEX_PLACE = '{6}'";// and SCANSTATE='1' and STATUS!='2'";
            string sql_update3 = @"UPDATE asrk_barcode SET STATUS = '{0}', USER_ID = '{1}', OPERATION = '{2}', mailtype='{3}',typeinvoice='{4}', Date_insert = CURRENT_TIMESTAMP WHERE BARCODE = '{5}' and INDEX_PLACE = '{6}'";// and SCANSTATE='1' and STATUS!='2'";
            
            //string sql3 = @"INSERT INTO asrk_barcode
//(BARCODE, INDEX_PLACE, USER_ID, OPERATION, STATUS, DATE_INSERT, mailtype, typeinvoice, invoiceindex)
//VALUES (:BARCODE, :INDEX_PLACE, :USER_ID, :OPERATION, :STATUS, CURRENT_TIMESTAMP, :mailtype, :typeinvoice, :BARCODE)";
            string updateData3 = String.Format(sql_update3, STATUS, USER_ID, OPERATION, mailtype, typeinvoice, barcode, INDEX_PLACE);
            var cmd = new OracleCommand(updateData3, Connection.getConnect());
            cmd.CommandTimeout = 0;
            var a = cmd.ExecuteNonQuery();
            //return a;
            ////(barcode, USER_ID, "20201", STATUS, index_place, "0");
            //var cmd = new OracleCommand(sql_insert_shell, Connection.getConnect());
            //cmd.Parameters.Add("BARCODE", OracleDbType.Char).Value = barcode;
            //cmd.Parameters.Add("INDEX_PLACE", OracleDbType.Char).Value = INDEX_PLACE;
            //cmd.Parameters.Add("USER_ID", OracleDbType.Char).Value = USER_ID;
            //cmd.Parameters.Add("OPERATION", OracleDbType.Char).Value = OPERATION;
            //cmd.Parameters.Add("STATUS", OracleDbType.Char).Value = STATUS;
            //cmd.Parameters.Add("mailtype", OracleDbType.Char).Value = mailtype;
            //cmd.Parameters.Add("typeinvoice", OracleDbType.Char).Value = typeinvoice; 
            //cmd.CommandTimeout = 0;
            //var a = cmd.ExecuteNonQuery();
            return a.ToString();
        }        

        public static int WriteBarcodeToDB(string barcode, string USER_ID, string OPERATION, string STATUS, string BARCODE_SHELL, string INDEX_PLACE, string MAILTYPE)//, string INVOICE)
        {
            string sql_update3 = @"UPDATE asrk_barcode SET STATUS = '{0}', USER_ID = '{1}', OPERATION = '{2}', barcode_shell='{3}', Date_Scan = CURRENT_TIMESTAMP WHERE BARCODE = '{4}' and INDEX_PLACE = '{5}'";// and SCANSTATE='1' and STATUS!='2'";
           
            string updateData3 = String.Format(sql_update3, STATUS, USER_ID, OPERATION, BARCODE_SHELL, barcode, INDEX_PLACE);
            var cmd = new OracleCommand(updateData3, Connection.getConnect());
            cmd.CommandTimeout = 0;
            var a = cmd.ExecuteNonQuery();
            return a;
        }

       public static int? BarcodeStatus(string barcode)
        {
            var cmd = new OracleCommand(getBarcodeStatus, Connection.getConnect());
            cmd.Parameters.Add("BARCODE", OracleDbType.Char).Value = barcode;
            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return Convert.ToInt32(reader[0].ToString());
            }
            else return null;
        }

        public static int UpdateBarcodeAnyway(string barcode, string USER_ID, string STATUS, string shell_barcode, string index_place)
        {
            string updateBarcodeData3 = String.Format(updateBarcodeAnyway, STATUS, USER_ID, barcode, index_place, shell_barcode);//!!!!!!!!!!!!

            var cmd = new OracleCommand(updateBarcodeData3, Connection.getConnect());
            cmd.CommandTimeout = 0;
            return cmd.ExecuteNonQuery();//кількість стрічок, для яких виконали update
        }


       public static int CheckShell(string shell_barcode, string index_place)
        {
             bool hasIndex = false;
             var cmd = new OracleCommand(checkShell, Connection.getConnect());
            cmd.Parameters.Add("SHELL_BARCODE", OracleDbType.Char).Value = shell_barcode;
            cmd.CommandTimeout = 0;
            List<BarcodeData> barcodeData = new List<BarcodeData>();
            var reader = cmd.ExecuteReader();
            while(reader.Read()){
                barcodeData.Add(new BarcodeData
                {
                    Barcode = shell_barcode,
                //Status=reader[0].ToString(),
                IndexPlace=reader[1].ToString() });
            }
            if (barcodeData.Count <= 0) { 
                return -1;}
            else
            {
                foreach (var data in barcodeData)
                {
                    if (data.IndexPlace == index_place) {
                        hasIndex = true;                                             
                    }                    
                }
                if (!hasIndex) return -2;
                else { return 1; }
            }
           // return cmd.ExecuteNonQuery();//кількість стрічок, для яких виконали select
        }


       public static int LeftInShell(string shell_barcode, string index_place)
       {
           int result = 0;
           var cmd = new OracleCommand(leftInShell, Connection.getConnect());
           cmd.Parameters.Add("SHELL_BARCODE", OracleDbType.Char).Value = shell_barcode;
           cmd.Parameters.Add("INDEX_PLACE", OracleDbType.Char).Value = index_place;
           cmd.CommandTimeout = 0;

           var reader = cmd.ExecuteReader();
           while (reader.Read())
           {
               result++;
           }
           return result;

          // return cmd.ExecuteNonQuery();//кількість стрічок, для яких виконали update
       }


/*

        const string sql_insert = @"INSERT INTO asrk_barcode
(BARCODE, INDEX_PLACE, USER_ID, OPERATION, STATUS, INVOICE)
VALUES (:BARCODE, :INDEX_PLACE, :USER_ID, :OPERATION, :STATUS, :INVOICE)";



       // const string sql_get_user_id = @"Select USER_ID from asrk_USER where Login=:Login and pass=:pass";

        //const string sql_open_bag = @"Select INVOICE from asrk_barcode where INVOICE=:INVOICE";

        const string changeStatusToUnpacked = @"UPDATE asrk_barcode
SET STATUS = :STATUS
WHERE asrk_barcode.BARCODE = :BARCODE";

        const string updateBarcodeData = @"UPDATE asrk_barcode
SET STATUS = :STATUS, USER_ID = :USER_ID
WHERE asrk_barcode.BARCODE = :BARCODE";

       
        const string barcodIsPreasent = @"Select count(*) from asrk_barcode
WHERE asrk_barcode.BARCODE = :BARCODE";

       
       
        public static bool BarcodeIsPresent(string barcode)
        {
            var cmd = new OracleCommand(barcodIsPreasent, Connection.getConnect());
            cmd.Parameters.Add("BARCODE", OracleDbType.Char).Value = barcode;
            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();
            var reader = cmd.ExecuteReader();
            return reader.Read() ? true : false;
        }
       
        public static void UpdateBarcodeData2(string barcode, string INDEX_PLACE, int USER_ID, string STATUS, DateTime date_device)
        {

            var cmd = new OracleCommand(updateBarcodeData, Connection.getConnect());
            cmd.Parameters.Add("BARCODE", OracleDbType.Char).Value = barcode;
            cmd.Parameters.Add("INDEX_PLACE", OracleDbType.Char).Value = INDEX_PLACE;//!!!!
            cmd.Parameters.Add("USER_ID", OracleDbType.Int32).Value = USER_ID;
            cmd.Parameters.Add("STATUS", OracleDbType.Char).Value = STATUS;
            cmd.Parameters.Add("date_device", OracleDbType.Char).Value = date_device;//to do!!!!!!!!
            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();
        }

        public static void ChangeStatusToUnpacked(string barcode)
        {
            ChangeStatusOfBarcode(barcode,1);
        }
        public static void ChangeStatusOfBarcode(string barcode, int status)
        {

            var cmd = new OracleCommand(changeStatusToUnpacked, Connection.getConnect());
            cmd.Parameters.Add("STATUS", OracleDbType.Char).Value = status;
            cmd.Parameters.Add("BARCODE", OracleDbType.Char).Value = barcode;
            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();
        } */

    }
}