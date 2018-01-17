using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml.Linq;
using Oracle.DataAccess.Client;
//using RESTFulWCFService.BarcodeDbAdapter;

namespace RESTFulWCFService
{   
    public class Barcode : IBarcode
    {
       public string ChangeStatusToUnpack(string barcode)
        {
            string productName = string.Empty;

            try
            {
                BarcodeDbAdapter.ChangeStatusToUnpacked(barcode);
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                     (ex.Message);
            }

            return productName;
        }

       public string WriteBarcode(string barcode, string user_id, string STATUS, string index_place)
        {
           //if (BarcodeDbAdapter.BarcodeStatus(barcode) == null) {
           //     return null;
           // }
           // else
           // {
                try
                {
                    BarcodeDbAdapter.WriteBarcodeToDB(barcode, index_place, user_id, "1", STATUS);
                    return "ok";
                }
                catch (Exception ex)
                {
                    return ex.Message.ToString();
                }
           // }
            /*string strProductQty = string.Empty; 

            try
            {
                if (BarcodeDbAdapter.BarcodeIsPresent(barcode)) {
                    UpdateBarcodeData(barcode,user_id,"1");
                    strProductQty = "Barcode status updated";
                }
                else
                {
                    BarcodeDbAdapter.WriteBarcodeToDB(barcode, index_place, user_id, "1", "-5");
                    strProductQty = "Barcode will be added with status -5"; 
                }
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                   (ex.Message);
            }
            return strProductQty;*/
        }

        public string UpdateBarcodeData(string barcode, string USER_ID, string STATUS)//
        {
            //if (BarcodeDbAdapter.BarcodeStatus(barcode) == null) {
            //    return null;
            //}
            //else
            //{ 
                try
                {
                BarcodeDbAdapter.UpdateBarcodeData2(barcode, USER_ID, STATUS);
                /*if (BarcodeDbAdapter.BarcodeStatus(barcode) == null) {
                    return "no data";
                }
                else if (BarcodeDbAdapter.BarcodeStatus(barcode) == 0)
                {
                    BarcodeDbAdapter.UpdateBarcodeData2(barcode, USER_ID, STATUS);
                    return "ok";
                }
                else 
                return BarcodeDbAdapter.BarcodeStatus(barcode).ToString();*/
                return "ok";
                }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
           // }
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
    }
}
