using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace StorePasswdAsHash
{
    internal class Connection
    {
        private string _sqlStatement, connstring;
        MySqlConnection dbconn;
        public Connection() 
        {
            Initialize();
        }

        private void Initialize()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.Database = "hashedpasswd_test";
            builder.UserID = "root";
            builder.Password = "";
            
        }
    }
}
