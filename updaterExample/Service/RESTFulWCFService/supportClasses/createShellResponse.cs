using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RESTFulWCFService
{
    [DataContract]
    public class createShellResponse
    {
        [DataMember]
        public string  status { get; set; }
        [DataMember]
        public string barcodeShell { get; set; }
    }
}
