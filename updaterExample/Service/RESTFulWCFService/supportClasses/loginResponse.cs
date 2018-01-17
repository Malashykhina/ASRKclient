using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RESTFulWCFService
{
    [DataContract]
    public class loginResponse
    {
        [DataMember]
        public string registerId { get; set; }

        [DataMember]
        public string userName{ get; set; }
    }
}
