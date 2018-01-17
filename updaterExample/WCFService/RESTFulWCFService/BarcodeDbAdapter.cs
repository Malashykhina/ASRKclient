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

        const string sql_insert = @"INSERT INTO asrk_barcode
(BARCODE, INDEX_PLACE, USER_ID, OPERATION, STATUS, INVOICE)
VALUES (:BARCODE, :INDEX_PLACE, :USER_ID, :OPERATION, :STATUS, :INVOICE)";

        const string sql_insert2 = @"INSERT INTO asrk_barcode
(BARCODE, INDEX_PLACE, USER_ID, OPERATION, STATUS, DATE_INSERT)
VALUES (:BARCODE, :INDEX_PLACE, :USER_ID, :OPERATION, :STATUS, CURRENT_TIMESTAMP)";

        const string sql_get_user_id = @"Select USER_ID from asrk_USER
where Login=:Login and pass=:pass";

        const string sql_open_bag = @"Select INVOICE from asrk_barcode
where INVOICE=:INVOICE";

        const string changeStatusToUnpacked = @"UPDATE asrk_barcode
SET STATUS = :STATUS
WHERE asrk_barcode.BARCODE = :BARCODE";

        const string updateBarcodeData = @"UPDATE asrk_barcode
SET STATUS = :STATUS, USER_ID = :USER_ID
WHERE asrk_barcode.BARCODE = :BARCODE";

        //const string updateBarcodeData2 = @"UPDATE asrk_barcode SET STATUS = '{0}', USER_ID = '{1}', Date_Scan = CURRENT_TIMESTAMP WHERE asrk_barcode.BARCODE = '{2}'";
        const string updateBarcodeData2 = @"UPDATE asrk_barcode SET STATUS = '{0}', USER_ID = '{1}' WHERE asrk_barcode.BARCODE = '{2}'";

        const string barcodIsPreasent = @"Select count(*) from asrk_barcode
WHERE asrk_barcode.BARCODE = :BARCODE";

        const string getBarcodeStatus = @"Select STATUS from asrk_barcode
WHERE asrk_barcode.BARCODE = :BARCODE";

        public static void WriteBarcodeToDB(string barcode, string INDEX_PLACE, string USER_ID, string OPERATION, string STATUS)//, string INVOICE)
        {

            var cmd = new OracleCommand(sql_insert2, Connection.getConnect());
            cmd.Parameters.Add("BARCODE", OracleDbType.Char).Value = barcode;
            cmd.Parameters.Add("INDEX_PLACE", OracleDbType.Char).Value = INDEX_PLACE;
            cmd.Parameters.Add("USER_ID", OracleDbType.Char).Value = USER_ID;//cmd.Parameters.Add("USER_ID", OracleDbType.Int32).Value = USER_ID;
            cmd.Parameters.Add("OPERATION", OracleDbType.Char).Value = OPERATION;
            cmd.Parameters.Add("STATUS", OracleDbType.Char).Value = STATUS;
            //cmd.Parameters.Add("INVOICE", OracleDbType.Char).Value = INVOICE;
            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();
        }
        public static void UpdateBarcodeData2(string barcode, string USER_ID, string STATUS)
        {
            string updateBarcodeData3 = String.Format(updateBarcodeData2, STATUS, USER_ID, barcode);

            var cmd = new OracleCommand(updateBarcodeData3, Connection.getConnect());
           cmd.Parameters.Add("STATUS", OracleDbType.Char).Value = STATUS;
           cmd.Parameters.Add("USER_ID", OracleDbType.Char).Value = USER_ID;//OracleDbType.Int32
           cmd.Parameters.Add("BARCODE", OracleDbType.Char).Value = barcode;
            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();
        }

        public static bool BarcodeIsPresent(string barcode)
        {
            var cmd = new OracleCommand(barcodIsPreasent, Connection.getConnect());
            cmd.Parameters.Add("BARCODE", OracleDbType.Char).Value = barcode;
            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();
            var reader = cmd.ExecuteReader();
            return reader.Read() ? true : false;
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
        } /**/

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
        }
    }
}