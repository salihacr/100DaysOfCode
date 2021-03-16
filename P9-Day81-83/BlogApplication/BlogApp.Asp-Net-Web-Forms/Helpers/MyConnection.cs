using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BlogApp.Asp_Net_Web_Forms.Helpers
{
    public class MyConnection
    {
        private static SqlConnection connection { get; set; }
        private static string address { get; set; }

        public static SqlConnection GetConnection()
        {
            try
            {
                address = ConfigurationManager.ConnectionStrings["PanelDB"].ConnectionString;
                connection = new SqlConnection(address);
                return connection;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}