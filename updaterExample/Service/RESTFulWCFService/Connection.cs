using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Oracle.DataAccess.Client;

namespace RESTFulWCFService
{
    public  class Connection
    {
        private static OracleConnection connnect;
        private static string connectionString = "user id=ASRK;password=krsa; data source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=10.255.102.10)(PORT=1521))(CONNECT_DATA=(SERVER=dedicated) (SERVICE_NAME = ukrpost)))";

        public static  OracleConnection getConnect()
        {

            if (connnect == null)
            {
               // connnect = new OracleConnection(connectionString);
                connnect = new OracleConnection(connectionString);//WebConfigurationManager.ConnectionStrings["myIfxConnection"].ConnectionString
            }

            if (connnect.State != System.Data.ConnectionState.Open)
            {
                while ((connnect.State == System.Data.ConnectionState.Connecting) ||
                      (connnect.State == System.Data.ConnectionState.Executing) ||
                      (connnect.State == System.Data.ConnectionState.Fetching))
                {
                    //ждем...
                }

                if (connnect.State == System.Data.ConnectionState.Broken)
                {
                    connnect.Close();
                }

                if (connnect.State == System.Data.ConnectionState.Closed)
                {
                    connnect.Open();
                }

            }
            //на всякий случай )))
            if (connnect.State == System.Data.ConnectionState.Closed)
            {
                connnect.Open();
            }

            return connnect;
        }
    }
}