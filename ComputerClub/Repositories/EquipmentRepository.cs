using ComputerClub.Models;
using ComputerClub.Database;
using System;
using System.Collections.Generic;
using System.Data;

namespace ComputerClub.Repositories
{
    public class EquipmentRepository
    {
        private Equipment MapRowToEquipment(DataRow row)
        {
            return new Equipment
            {
                Id = Convert.ToInt32(row["id"]),
                Number = Convert.ToInt32(row["eq_number"]),
                Type = row["eq_type"].ToString() switch
                {
                    "PC" => EquipmentType.PC,
                    "PS4" => EquipmentType.PS4,
                    "PS5" => EquipmentType.PS5,
                    "Xbox" => EquipmentType.Xbox,
                    _ => EquipmentType.PC
                },
                Specifications = row["specifications"].ToString() ?? string.Empty,
                Status = row["eq_status"].ToString() switch
                {
                    "Вільний" => EquipmentStatus.Available,
                    "Зайнятий" => EquipmentStatus.Occupied,
                    "Заброньований" => EquipmentStatus.Booked,
                    _ => EquipmentStatus.Available
                }
            };
        }

        public List<Equipment> GetAll()
        {
            List<Equipment> equipment = new List<Equipment>();
            string query = "select * from equipment";

            DataTable dt = DatabaseManager.Instance.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                equipment.Add(MapRowToEquipment(row));
            }

            return equipment;
        }

        public Equipment? GetById(int id)
        {
            string query = $"select * from equipment where id = {id}";
            DataTable dt = DatabaseManager.Instance.ExecuteQuery(query);

            if (dt.Rows.Count == 0)
                return null;

            return MapRowToEquipment(dt.Rows[0]);
        }

        public bool Add(Equipment equipment)
        {
            string typeStr = equipment.Type.ToString();

            string statusStr = equipment.Status switch
            {
                EquipmentStatus.Available => "Вільний",
                EquipmentStatus.Occupied => "Зайнятий",
                EquipmentStatus.Booked => "Заброньований",
                _ => "Вільний"
            };

            string query = $"insert into equipment (eq_number, eq_type, specifications, eq_status) " +
                           $"values ('{equipment.Number}', '{typeStr}', '{equipment.Specifications}', '{statusStr}')";

            int rowsAffected = DatabaseManager.Instance.ExecuteNonQuery(query);
            return rowsAffected > 0;
        }

        public bool Update(Equipment equipment)
        {
            string typeStr = equipment.Type.ToString();

            string statusStr = equipment.Status switch
            {
                EquipmentStatus.Available => "Вільний",
                EquipmentStatus.Occupied => "Зайнятий",
                EquipmentStatus.Booked => "Заброньований",
                _ => "Вільний"
            };

            string query = $"update equipment set " +
                           $"eq_number = '{equipment.Number}', " +
                           $"eq_type = '{typeStr}', " +
                           $"specifications = '{equipment.Specifications}', " +
                           $"eq_status = '{statusStr}' " +
                           $"where id = {equipment.Id}";

            int rowsAffected = DatabaseManager.Instance.ExecuteNonQuery(query);
            return rowsAffected > 0;
        }

        public bool Delete(int id)
        {
            string query = $"delete from equipment where id = {id}";

            int rowsAffected = DatabaseManager.Instance.ExecuteNonQuery(query);
            return rowsAffected > 0;
        }
    }
}