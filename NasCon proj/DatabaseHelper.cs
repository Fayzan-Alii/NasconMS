using MySql.Data.MySqlClient;
using NasCon_proj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasCon_proj
{
    internal class DatabaseHelper
    {
        private static string connectionString = "server=localhost;uid=root;pwd=Furious@2020;database=nascon";
        private static MySqlConnection connection = new MySqlConnection(connectionString);

        public static MySqlConnection GetConnection()
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
            return connection;
        }

        public static void CloseConnection()
        {
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }

    }
}