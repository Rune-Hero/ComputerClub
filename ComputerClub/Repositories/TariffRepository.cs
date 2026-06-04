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
    public class TariffRepository
    {
        public Tariff MapRowToTariff(DataRow row)
        {
            return new Tariff
            {
                Id = Convert.ToInt32(row["id"]),
                Name = row["tariff_name"].ToString()!,
                Price = Convert.ToDecimal(row["price_per_hour"])
            };
        }

        public List<Tariff> GetAll()
        {
            List<Tariff> tariffs = new List<Tariff>();
            string query = "select * from tariffs";

            DataTable dt = DatabaseManager.Instance.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                tariffs.Add(MapRowToTariff(row));
            }

            return tariffs;
        }

        public Tariff? GetById(int id)
        {
            string query = $"select * from tariffs where id = {id}";
            DataTable dt = DatabaseManager.Instance.ExecuteQuery(query);

            if (dt.Rows.Count == 0)
                return null;

            return MapRowToTariff(dt.Rows[0]);
        }

        public bool Add(Tariff tariff)
        {
            string query = $"insert into tariffs (tariff_name, price_per_hour) " +
                $"values ('{tariff.Name}', '{tariff.Price}')";

            int rowsAffected = DatabaseManager.Instance.ExecuteNonQuery(query);
            return rowsAffected > 0;
        }

        public bool Update(Tariff tariff)
        {
            string query = $"update tariffs set tariff_name = '{tariff.Name}', price_per_hour = '{tariff.Price}' where id = {tariff.Id}";

            int rowsAffected = DatabaseManager.Instance.ExecuteNonQuery(query);
            return rowsAffected > 0;
        }

        public bool Delete(int id)
        {
            string query = $"delete from tariffs where id = {id}";

            int rowsAffected = DatabaseManager.Instance.ExecuteNonQuery(query);
            return rowsAffected > 0;
        }
    }
}
