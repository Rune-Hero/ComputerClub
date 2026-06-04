using ComputerClub.Database;
using ComputerClub.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerClub.Repositories
{
    public class ClientRepository
    {
        private Client MapRowToClient(DataRow row)
        {
            return new Client
            {
                Id = Convert.ToInt32(row["id"]),
                FullName = row["full_name"].ToString() ?? string.Empty,
                Phone = row["phone"].ToString() ?? string.Empty,
                Email = row["email"].ToString() ?? string.Empty
            };
        }

        public List<Client> GetAll()
        {
            List<Client> clients = new List<Client>();
            string query = "select * from clients";

            DataTable dt = DatabaseManager.Instance.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                clients.Add(MapRowToClient(row));
            }

            return clients;
        }

        public Client? GetById(int id)
        {
            string query = $"select * from clients where id = {id}";
            DataTable dt = DatabaseManager.Instance.ExecuteQuery(query);

            if (dt.Rows.Count == 0)
                return null;

            return MapRowToClient(dt.Rows[0]);
        }

        public bool Add(Client client)
        {
            string query = $"insert into clients (full_name, phone, email) " +
                $"values ('{client.FullName}', '{client.Phone}', '{client.Email}')";

            int rowsAffected = DatabaseManager.Instance.ExecuteNonQuery(query);
            return rowsAffected > 0;
        }

        public bool Update(Client client)
        {
            string query = $"update clients set name = '{client.FullName}', phone = '{client.Phone}', email = '{client.Email}' where id = {client.Id}";

            int rowsAffected = DatabaseManager.Instance.ExecuteNonQuery(query);
            return rowsAffected > 0;
        }

        public bool Delete(int id)
        {
            string query = $"delete from clients where id = {id}";

            int rowsAffected = DatabaseManager.Instance.ExecuteNonQuery(query);
            return rowsAffected > 0;
        }
    }
}
