using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RESTFulWCFService
{
    [DataContract]
    public class getUnpackedShellsRequest
    {
        [DataMember]
        public string index { get; set; }
    }
}
