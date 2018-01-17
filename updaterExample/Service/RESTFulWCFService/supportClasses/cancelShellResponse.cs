using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RESTFulWCFService
{
    [DataContract]
    public class cancelShellResponse
    {  
        [DataMember]
        public string cancel { get; set; }
        [DataMember]
        public string status { get; set; }
    }
}
