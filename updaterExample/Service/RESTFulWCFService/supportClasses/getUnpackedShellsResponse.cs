using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RESTFulWCFService
{[DataContract]
    public class getUnpackedShellsResponse
    {
    [DataMember]
        public string status { get; set; }
       [DataMember]
    public string[] shell { get; set; }
    }
}
