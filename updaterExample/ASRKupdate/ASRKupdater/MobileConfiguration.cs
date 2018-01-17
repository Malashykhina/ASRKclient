using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using System.Xml;

namespace ASRKupdator
{
    public static class MobileConfiguration
    {
        public static NameValueCollection Settings;

        static MobileConfiguration()
        {
            string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            string configFile = Path.Combine(appPath, "Resource.xml");//"Resource.config")

            if (!File.Exists(configFile))
            {
                throw new FileNotFoundException(string.Format("Application configuration file '{0}' not found.", configFile));
            }

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(configFile);
            XmlNodeList nodeList = xmlDocument.GetElementsByTagName("appSettings");
            Settings = new NameValueCollection();

            foreach (XmlNode node in nodeList)
            {
                foreach (XmlNode key in node.ChildNodes)
                {
                    Settings.Add(key.Attributes["key"].Value, key.Attributes["value"].Value);
                }
            }
        }
    }
}
