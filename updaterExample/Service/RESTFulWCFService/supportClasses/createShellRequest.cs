using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RESTFulWCFService
{
    [DataContract]
    public class createShellRequest
    {
       [DataMember]
        public string index { get; set; }
        [DataMember]
        public string userid { get; set; } 
    }
}
