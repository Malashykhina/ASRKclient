﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RESTFulWCFService
{
    [DataContract]
    public class cancelShellRequest
    {
        [DataMember]
        public string index { get; set; }
        [DataMember]
        public string userid { get; set; }
        [DataMember]
        public string shellId { get; set; }
    }
}
