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
        MySqlCommand command;
        MySqlDataReader reader;
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

            dbconn = new MySqlConnection(builder.ToString());
            
        }

        public void Insert(string username, byte[] passwd, byte[] salt)
        {
            _sqlStatement = $"INSERT INTO `userdata`( `username`, `passwd`, `salt`) " +
                $"VALUES ('{username}','{passwd}','{salt}');";

            try
            {
                dbconn.Open();

                command = new MySqlCommand();
                command.Connection = dbconn;
                command.CommandText = _sqlStatement;

                command.ExecuteNonQuery();


                dbconn.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public User Select(string username) 
        {
            _sqlStatement = $"SELECT passwd, salt, userid FROM `userdata` " +
                $"where username = '{username}';";
            User user;
            byte[] passwd = new byte[32];
            byte[] salt = new byte[12];
            int id = 0;
            try
            {
                dbconn.Open();
                command = new MySqlCommand();
                command.Connection = dbconn;
                command.CommandText = _sqlStatement;

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    reader.GetBytes(0,0,passwd,0,32);
                    reader.GetBytes(1,0,salt,0,12);
                    id = reader.GetInt32(2);
                }

                user = new User(id, username, passwd, salt);

                dbconn.Close();

                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
