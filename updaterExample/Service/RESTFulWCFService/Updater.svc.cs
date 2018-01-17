using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using System.Configuration;

namespace RESTFulWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Updater" in code, svc and config file together.
    public class Updater : IUpdater
    {
        Dictionary<string, string> files;
        public int DoWork()
        {
            return 15;
        }
        public byte[] DownloadFile(string url)
        {
            var a = File.ReadAllBytes(url);
            return a;
            //WebClient myWebClient = new WebClient();
            //return myWebClient.DownloadData(@"D:\WinMobProgects\service\RESTFulWCFService\RESTFulWCFService2\client\SQLite.Interop.066.DLL");
        }

        public Dictionary<string, string> GetHeshes()
        {
            var url = ConfigurationManager.AppSettings["DownloadPath"].ToString();
            return GetHeshes(url);
        }
       
        private Dictionary<string, string> GetHeshes(string url)
        {
            if (files == null) {
                files = new Dictionary<string, string>();
                /* var filename=@"D:\WinMobProgects\service\RESTFulWCFService\RESTFulWCFService2\test.txt";
                files.Add(filename, md5_hash(File.ReadAllBytes(filename)));  */       
                var fileNames = Directory.GetFiles(url);
                for (int i = 0; i < fileNames.Length; i++)
                {                 
                    files.Add(fileNames[i], md5_hash(File.ReadAllBytes(fileNames[i])));
                }
            }
            return files;
        }
        private static string md5_hash(byte[] arr)
        {
            return BitConverter.ToString(MD5.Create().ComputeHash(arr)).Replace("-", string.Empty);
        }
        //
        
        //public Dictionary<string, string> GetHeshes()
        //{
        //    Dictionary<string, string> dict = new Dictionary<string, string>();
        //   //var fileNames= Directory.GetFiles(@"D:\WinMobProgects\service\RESTFulWCFService\RESTFulWCFService2\client\");
        //   //for (int i = 0; i < fileNames.Length; i++) {
        //   //    dict.Add(fileNames[i], "1");
        //   //}
        //    dict.Add("barcodes.s3db", "1");
        //    dict.Add("NETCFv35.Messages.EN.cab", "1");
        //    dict.Add("Oracle.DataAccess.dll", "1");
        //    dict.Add("SQLite.Interop.066.DLL", "1");
        //    dict.Add("SQLite.Interop.066.exp", "1");
        //    dict.Add("SQLite.Interop.066.lib", "1");
        //    dict.Add("Symbol.Audio.dll", "1");
        //    dict.Add("Symbol.Audio.xml", "1");
        //    dict.Add("Symbol.Barcode.dll", "1");
        //    dict.Add("Symbol.Barcode.xml", "1");
        //    dict.Add("Symbol.dll", "1");
        //    dict.Add("Symbol.xml", "1");
        //    dict.Add("System.Data.OracleClient.dll", "1");
        //    dict.Add("System.EnterpriseServices.dll", "1");
        //    dict.Add("System.EnterpriseServices.Wrapper.dll", "1");
        //    dict.Add("System.SR.dll", "1");
        //    dict.Add("System.Transactions.dll", "1");
        //    dict.Add("System.Web.dll", "1");
        //    dict.Add("testSqLite.exe", "1");
        //    dict.Add("testSqLite.pdb", "1");
        //    dict.Add("NETCFv35.Messages.EN.wm.cab", "1");
        //    return dict;
        //}
    }
}
