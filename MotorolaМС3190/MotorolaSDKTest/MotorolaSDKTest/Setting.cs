using System;
using System.Collections.Specialized;
using System.IO;
using System.Xml;

namespace ASRKclient
{
	/// <summary>
	/// Summary description for Settings.
	/// </summary>
	public class Setting
	{
		private static NameValueCollection m_settings;
		private static string m_settingsPath;
        
		static Setting()
		{
			m_settingsPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
			m_settingsPath += @"\Setting.xml";
			
			if(!File.Exists(m_settingsPath))
				throw new FileNotFoundException(m_settingsPath + " could not be found.");

			System.Xml.XmlDocument xdoc = new XmlDocument();
			xdoc.Load(m_settingsPath);
			XmlElement root = xdoc.DocumentElement;
			System.Xml.XmlNodeList nodeList = root.ChildNodes.Item(0).ChildNodes;

			// Add settings to the NameValueCollection.
			m_settings = new NameValueCollection();
            for (int i = 0; i < nodeList.Count; i++) {
                m_settings.Add(nodeList.Item(i).Attributes["key"].Value, nodeList.Item(i).Attributes["value"].Value);
            }
           /* m_settings.Add("Index", nodeList.Item(0).Attributes["value"].Value);
            m_settings.Add("Login", nodeList.Item(1).Attributes["value"].Value);
			m_settings.Add("Password", nodeList.Item(2).Attributes["value"].Value);

            m_settings.Add("ServerIP", nodeList.Item(3).Attributes["value"].Value);
			m_settings.Add("UserName", nodeList.Item(4).Attributes["value"].Value);
			m_settings.Add("PhoneNumber", nodeList.Item(5).Attributes["value"].Value);
			m_settings.Add("TimeOut", nodeList.Item(6).Attributes["value"].Value);
			m_settings.Add("LastTransmit", nodeList.Item(7).Attributes["value"].Value);
			m_settings.Add("DatabasePath", nodeList.Item(8).Attributes["value"].Value);*/
		}

		public static void Update()
		{
			XmlTextWriter tw = new XmlTextWriter(m_settingsPath, System.Text.UTF8Encoding.UTF8);
			tw.WriteStartDocument();
			tw.WriteStartElement("configuration");
			tw.WriteStartElement("appSettings");

			for(int i=0; i<m_settings.Count; ++i)
			{
				tw.WriteStartElement("add");
				tw.WriteStartAttribute("key", string.Empty);
				tw.WriteRaw(m_settings.GetKey(i));
				tw.WriteEndAttribute();

				tw.WriteStartAttribute("value", string.Empty);
				tw.WriteRaw(m_settings.Get(i));
				tw.WriteEndAttribute();
				tw.WriteEndElement();
			}

			tw.WriteEndElement();
			tw.WriteEndElement();

			tw.Close();
		}
        public static string ServiceUrl
        {
            get { return m_settings.Get("ServiceUrl"); }
            set { m_settings.Set("ServiceUrl", value); }
        }
        public static string Index
        {
            get { return m_settings.Get("Index"); }
            set { m_settings.Set("Index", value); }
        }
        public static string Login
        {
            get { return m_settings.Get("Login"); }
            set { m_settings.Set("Login", value); }
        }

		public static string Password
		{
			get { return m_settings.Get("Password"); }
			set { m_settings.Set("Password", value); }
		}

		public static string ServerIP
		{
			get { return m_settings.Get("ServerIP"); }
			set { m_settings.Set("ServerIP", value); }
		}

		public static string Port
		{
            get { return m_settings.Get("Port"); }
            set { m_settings.Set("Port", value); }
		}


        public static string ServerIP2
		{
            get { return m_settings.Get("ServerIP2"); }
            set { m_settings.Set("ServerIP2", value); }
		}

		public static string TimeOut
		{
			get { return m_settings.Get("TimeOut"); }
			set { m_settings.Set("TimeOut", value); }
		}

		public static string LastTransmit
		{
			get { return m_settings.Get("LastTransmit"); }
			set { m_settings.Set("LastTransmit", value); }
		}

		public static string Port2
		{
            get { return m_settings.Get("Port2"); }
            set { m_settings.Set("Port2", value); }
		}
	}
}
