using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTFulWCFService
{
    public class BarcodeData
    {
        public string Barcode { get; set; }
        public string Status { get; set; }
        public string IndexPlace { get; set; }
        public string ShellBarcode { get; set; }
    }
}