using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RESTFulWCFService
{
    [DataContract]
    public class finishShellRequest
    {       
        [DataMember]
        public string shell { get; set; } 
        [DataMember]
        public string index { get; set; }
    }
}
