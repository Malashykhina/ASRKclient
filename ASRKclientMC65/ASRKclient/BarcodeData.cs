using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ASRKclient
{
    public class BarcodeData
    {
        public int Barcode_id { get; set; }
        public string Barcode_value { get; set; }
        public int Status { get; set; }
    }
    public class BarcodeList
    {
        private List<BarcodeData> arr;
        public void Add(BarcodeData b) {
            if (arr == null) {
                arr = new List<BarcodeData>();
            }
            arr.Add(b);
        }
        public void Add(int barcode_id, string barcode_value, int status)
        {
            this.Add(new BarcodeData() { Barcode_id = barcode_id, Barcode_value = barcode_value, Status = status });
        }
        public List<BarcodeData> getList() {
            return this.arr;
        }
        public void Clean() {
            this.arr = null;
        }
    }
}
