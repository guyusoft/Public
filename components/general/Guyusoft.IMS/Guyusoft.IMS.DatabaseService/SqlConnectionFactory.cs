using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Guyusoft.IMS.DatabaseService
{
    public class SqlConnectionFactory
    {
        public static SqlConnection CreateConnection()
        {
            var connSetting = ConfigurationManager.ConnectionStrings["IMS"];

            var conn = new SqlConnection(connSetting.ConnectionString);

            return conn;
        }
    }
}
