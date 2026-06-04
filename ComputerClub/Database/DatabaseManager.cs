using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using Mysqlx.Connection;

namespace ComputerClub.Database
{
    public sealed class DatabaseManager
    {
        private static DatabaseManager? instance;
        private readonly string connectionString;

        private DatabaseManager()
        {
            connectionString = "server=localhost;database=computer_club;uid=root;pwd=root;";
        }

        public static DatabaseManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new DatabaseManager();
                return instance;
            }
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);

                adapter.Fill(dt);
            }

            return dt;
        }

        public int ExecuteNonQuery(string query)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);

                return cmd.ExecuteNonQuery();
            }
        }
    }
}
