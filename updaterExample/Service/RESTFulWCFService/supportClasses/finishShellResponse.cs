using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RESTFulWCFService
{
     [DataContract]
    public class finishShellResponse
    {
        [DataMember]
        public string status { get; set; } 
        [DataMember]
        public string inShell { get; set; } 
    }
}
