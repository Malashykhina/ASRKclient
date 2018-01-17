using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using System.IO;

namespace RESTFulWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUpdater" in both code and config file together.
    [ServiceContract]
    public interface IUpdater
    {
        [OperationContract]
        String getHelloString(RequestMessage request);//(string a);//
        [OperationContract]
        RequestMessage Hello();
        [OperationContract]
        [WebGet]
        int DoWork();
        [OperationContract]
        [WebGet]//
        byte[] DownloadFile(string url);
        [OperationContract]
        [WebGet]// 
        Dictionary<string, string> GetHeshes();
        [OperationContract]
        string[] GetHeshes2();
    }
    [DataContract]
    public class RequestMessage
    {
        [DataMember]//(IsRequired = true)]
        public string param1 { get; set; }

        [DataMember]//(IsRequired = true)]
        public string param3 { get; set; }
    }
}
