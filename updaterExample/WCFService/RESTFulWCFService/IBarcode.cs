using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace RESTFulWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBarcode" in both code and config file together.
    [ServiceContract]
    public interface IBarcode
    {
        /*[OperationContract]
        [WebGet(UriTemplate = "/Unpack/{barcode}")]
        string ChangeStatusToUnpack(string barcode);*/

        [OperationContract]//
       // [WebGet(UriTemplate = "/Unpack1/{barcode}/{USER_ID}/{STATUS}")]
        [WebInvoke(Method = "GET",
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "/Unpack/{barcode}/{USER_ID}/{STATUS}")]
        string UpdateBarcodeData(string barcode, string USER_ID, string STATUS);

        [OperationContract]
        [WebInvoke(Method = "GET",
                   ResponseFormat = WebMessageFormat.Json,
                   UriTemplate = "/WriteBarcode/{barcode}/{USER_ID}/{STATUS}/{index_place}")]
        //[WebGet(UriTemplate = "/WriteBarcode/{barcode}/{USER_ID}/{index_place}")]
        string WriteBarcode(string barcode, string USER_ID, string STATUS, string index_place);
        
        [OperationContract]
        [WebInvoke(Method = "GET",
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "/GetStatus/{barcode}")]
        string GetStatus(string barcode);
        
        /*[OperationContract]
        [WebGet(UriTemplate = "/GetAllIndexes")]
        string GetAllIndexes();*/
    }
}
