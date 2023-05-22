using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace csd_evaluation_system.Models
{
    class Database
    {
        private static OleDbConnection connection = null;

        public static OleDbConnection GetConnection()
        {
            if (connection == null)
            {
                String provider = "Microsoft.ACE.OLEDB.12.0";
                String db_path = (String)Properties.Settings.Default["db_path"];
                String connection_string = "Provider=" + provider + ";Data Source=" + db_path + ";Ole DB Services=-1";
                connection = new OleDbConnection(connection_string);
            }
            return connection;
        }
    }
}
