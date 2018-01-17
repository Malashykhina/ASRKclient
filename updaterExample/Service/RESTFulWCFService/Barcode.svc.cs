using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml.Linq;
using Oracle.DataAccess.Client;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Xml.Serialization;

namespace RESTFulWCFService
{   
    public class Barcode : IBarcode
    {
        //good
        public loginResponse login(loginRequest login)
        {
            var a = BarcodeDbAdapter.Login(login.index, login.login, login.password);
            loginResponse l = new loginResponse();
            if (a.Count != 0)
            {
                l.registerId = a[0];
                l.userName = a[1];
                return l;
            }
            else
            {
                return l;
            }
        }

        //good
        public getUnpackedShellsResponse getUnpackedShells(getUnpackedShellsRequest UnpackedShells)
        {
            var res = new getUnpackedShellsResponse();
            var a = BarcodeDbAdapter.GetUnfinishedShells("0", UnpackedShells.index, "20201", "2");

            if ((a != null) && (a.Count > 0))
            {
                res.status = "1";
                res.shell = new string[a.Count];
                for (int i = 0; i < a.Count; i++)
                {
                    res.shell[i] = a[i];
                }
            }
            else
            {
                res.status = "-1";
                res.shell = new string[] { };
            }
            return res;
        }


        public packShellResponse packShell(packShellRequest shell)
        {
            //1-запаковано
            ////-999 если не найден баркод
            //-barcode.getStatus() если статус баркода не 0 и не 99
            ////-998 если баркод является шеллом (операция 20201)
            ////-997 если не найден текой шелл для данного отделения
            //-996 если шелл имеет статус не 0 (то есть уже запакован или отменен)
            ////-1 если упакован в текущий шелл
            ////-994 если упакован в другой шелл

            var res = new packShellResponse();
            try
            {
                var a = BarcodeDbAdapter.WriteBarcodeToDB(shell.barcodeId, shell.userid, "20301", "1", shell.shellId, shell.index, "0", "1");
                res.status=a[0];
                if (a.Count > 1) {
                    res.pack = a[1];
                    res.packUser = a[2];
                }
                return res;
            }
            catch (Exception ex)
            {
                return res;
            }
        }


        private string GenerateSellBarcode(string user_id) {
            return DateTime.Now.ToString("yyyyMMdd_hhmmss_fff") + "_" + user_id;
        }

        public string CancelPackingShell(string shell_barcode, string STATUS, string index_place)
        {
            try
            {
                var shellRes = BarcodeDbAdapter.CheckBarcodeShell(shell_barcode, index_place);
                if (shellRes.Count == 0)//shellRes == null
                {
                    return "-99";// не знайдено такого штрихкоду
                }
                else
                {
                    if (shellRes[0] == "")//пришло не з асрк
                    {
                        //потрібно перевірити статус shellRes[1] 
                        if (shellRes[1] != "2")// if (shellRes[1] == "0")
                        {
                            return BarcodeDbAdapter.CancelPackingShell(shell_barcode, STATUS, index_place).ToString();//1 якщо все ок, 0 апдейт не відбувся
                            //return "0";//хтось інший додав оболочку i вона ще не запакована
                        }
                        else return "-" + shellRes[1];//хтось інший додав оболочку i вона вже запакована
                    }
                    else return "-99";// має UNID, а одже дублювання
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        
        public string WriteBarcode(string barcode, string user_id, string STATUS, string shell_barcode, string index_place)
        {
                try
                {
                    BarcodeDbAdapter.WriteBarcodeToDB(barcode, user_id, "1", STATUS, shell_barcode, index_place);
                    return "ok";
                }
                catch (Exception ex)
                {
                    return ex.Message.ToString();
                }
        }

       public string CheckShell(string shell_barcode, string index_place)
       {
           var status = BarcodeDbAdapter.CheckShell(shell_barcode, index_place);
           return status.ToString();//status==1 ->ok
       }
       public string LeftInShell(string shell_barcode, string index_place)
       {
           var status = BarcodeDbAdapter.LeftInShell(shell_barcode, index_place);
           return status.ToString();//кількість
       }
       public string UpdateBarcodeData(string barcode, string USER_ID, string STATUS, string shell_barcode, string index_place)// UpdateBarcodeData(string barcode, string USER_ID, string STATUS)//
       {
           try
           {
               var a = BarcodeDbAdapter.SelectBarcodeData(barcode, USER_ID, STATUS, shell_barcode, index_place);
             return a.ToString();
           }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        //
       public string UpdateBarcodeAnyway(string barcode, string USER_ID, string STATUS, string shell_barcode, string index_place)
       {  
           try
           {
               var a = BarcodeDbAdapter.UpdateBarcodeAnyway(barcode, USER_ID, STATUS, shell_barcode, index_place);
             if (a > 0)
                 return "ok";
             else return "not found";
           }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
       }

        public string GetStatus(string barcode)
        {
            var status = BarcodeDbAdapter.BarcodeStatus(barcode);
            if (status == null)
            {
                return null;//?
            }
            else
                return status.ToString();
        }

        public cancelShellResponse cancelShell(cancelShellRequest cancellSR)
        {
            var res = new cancelShellResponse();
            try
            {
                var shellRes = BarcodeDbAdapter.CheckBarcodeShell(cancellSR.shellId, cancellSR.index);
                if (shellRes.Count == 0)//shellRes == null
                {
                    res.status="-99";// не знайдено такого штрихкоду                    
                }
                else
                {
                    if (shellRes[0] == "")//пришло не з асрк
                    {
                        //потрібно перевірити статус shellRes[1] 
                        if (shellRes[1] != "2")// if (shellRes[1] == "0")
                        {
                            res.status = BarcodeDbAdapter.CancelPackingShell(cancellSR.shellId, "99", cancellSR.index).ToString();//1 якщо все ок, 0 апдейт не відбувся
                            //return "0";//хтось інший додав оболочку i вона ще не запакована
                        }
                        else  res.status= "-" + shellRes[1];//хтось інший додав оболочку i вона вже запакована
                    }
                    else res.status = "-99";// має UNID, а одже дублювання
                }
                return res;
            }
            catch (Exception ex)
            {
                return res;
            }
        }

        public createShellResponse createShell(createShellRequest createSR)
        {
           var b = new createShellResponse();


           try
           {
               var a = GenerateSellBarcode(createSR.userid);
               BarcodeDbAdapter.WriteBarcodeShell(a, createSR.userid, "20201", "0", createSR.index, "0", "2");
               b.barcodeShell = a;
               b.status = "1"; 
               return b;
           }
           catch (Exception ex)
           {
               b.barcodeShell = "";
               b.status = "-1";
               return b;
               //return ex.Message.ToString();
           }
        }

        public finishShellResponse finishShell(finishShellRequest fSR)
        {
            try
            {
                var res= new finishShellResponse();
                var shellRes = BarcodeDbAdapter.CheckBarcodeShell(fSR.shell,fSR.index);
                if (shellRes.Count == 0)//shellRes == null
                {
                    res.status="-99";// не знайдено такого штрихкоду
                    return res; 
                }
                else
                {
                    if (shellRes[0] == "")//пришло не з асрк
                    {
                        //потрібно перевірити статус shellRes[1] 
                        if (shellRes[1] != "2")// if (shellRes[1] == "0")
                        {
                            res.status = BarcodeDbAdapter.FinishPackingShell(fSR.shell, "1", fSR.index).ToString();
                            return res;//1 якщо все ок, 0 апдейт не відбувся
                            //return "0";//хтось інший додав оболочку i вона ще не запакована
                        }
                        else {
                            res.status = "-" + shellRes[1];
                            return res;//хтось інший додав оболочку i вона вже запакована
                        }
                    }
                    else {
                        res.status = "-99";// має UNID, а одже дублювання
                        return res;
                    } 
                }
            }
            catch (Exception ex)
            {
                return null;// ex.Message.ToString();
            }
        }

       

    }
}
