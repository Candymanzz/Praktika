using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika
{
    public class DB
    {
        MySqlConnection _connection = new MySqlConnection("server=localhost;port=3306;user=root;password=root;database=users");
    
        public void openConnectin()
        {
            if(_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        public void closeConnectin()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public MySqlConnection getConnection()
        {
            return _connection;
        }
    }
}
