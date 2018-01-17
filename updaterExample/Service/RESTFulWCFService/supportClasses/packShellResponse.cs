using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RESTFulWCFService
{
    [DataContract]
    public class packShellResponse
    {
    
    [DataMember]
    public string status { get; set; }
    
    [DataMember]
    public string pack{ get; set; }
    
    [DataMember]
    public string packUser{ get; set; }
    }
}
