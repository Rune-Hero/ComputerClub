using ComputerClub.Database;
using ComputerClub.Models;
using System;
using System.Collections.Generic;
using System.Data;
using static ComputerClub.Models.Reservation;

namespace ComputerClub.Repositories
{
    public class ReservationRepository
    {
        private Reservation MapRowToReservation(DataRow row)
        {
            return new Reservation
            {
                Id = Convert.ToInt32(row["id"]),
                ClientId = Convert.ToInt32(row["client_id"]),
                EquipmentId = Convert.ToInt32(row["equipment_id"]),
                TariffId = Convert.ToInt32(row["tariff_id"]),
                StartTime = Convert.ToDateTime(row["start_time"]),
                EndTime = Convert.ToDateTime(row["end_time"]),

                ResStatus = row["res_status"].ToString() switch
                {
                    "Активне" => ReservationStatus.Active,
                    "Завершене" => ReservationStatus.Completed,
                    "Скасоване" => ReservationStatus.Canceled,
                    _ => ReservationStatus.Active
                }
            };
        }

        public List<Reservation> GetAll()
        {
            List<Reservation> reservations = new List<Reservation>();
            string query = "select * from reservations";

            DataTable dt = DatabaseManager.Instance.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                reservations.Add(MapRowToReservation(row));
            }

            return reservations;
        }

        public Reservation? GetById(int id)
        {
            string query = $"select * from reservations where id = {id}";
            DataTable dt = DatabaseManager.Instance.ExecuteQuery(query);

            if (dt.Rows.Count == 0)
                return null;

            return MapRowToReservation(dt.Rows[0]);
        }

        public bool Add(Reservation reservation)
        {
            string statusStr = reservation.ResStatus switch
            {
                ReservationStatus.Active => "Активне",
                ReservationStatus.Completed => "Завершене",
                ReservationStatus.Canceled => "Скасоване",
                _ => "Активне"
            };

            string startStr = reservation.StartTime.ToString("yyyy-MM-dd HH:mm:ss");
            string endStr = reservation.EndTime.ToString("yyyy-MM-dd HH:mm:ss");

            string query = $"insert into reservations (client_id, equipment_id, tariff_id, start_time, end_time, res_status) " +
                           $"values ({reservation.ClientId}, {reservation.EquipmentId}, {reservation.TariffId}, '{startStr}', '{endStr}', '{statusStr}')";

            int rowsAffected = DatabaseManager.Instance.ExecuteNonQuery(query);
            return rowsAffected > 0;
        }

        public bool Update(Reservation reservation)
        {
            string statusStr = reservation.ResStatus switch
            {
                ReservationStatus.Active => "Активне",
                ReservationStatus.Completed => "Завершене",
                ReservationStatus.Canceled => "Скасоване",
                _ => "Активне"
            };

            string startStr = reservation.StartTime.ToString("yyyy-MM-dd HH:mm:ss");
            string endStr = reservation.EndTime.ToString("yyyy-MM-dd HH:mm:ss");

            string query = $"udate reservations set " +
                           $"client_id = {reservation.ClientId}, " +
                           $"equipment_id = {reservation.EquipmentId}, " +
                           $"tariff_id = {reservation.TariffId}, " +
                           $"start_time = '{startStr}', " +
                           $"end_time = '{endStr}', " +
                           $"res_status = '{statusStr}' " +
                           $"WHERE id = {reservation.Id}";

            int rowsAffected = DatabaseManager.Instance.ExecuteNonQuery(query);
            return rowsAffected > 0;
        }

        public bool Delete(int id)
        {
            string query = $"delete from reservations where id = {id}";
            int rowsAffected = DatabaseManager.Instance.ExecuteNonQuery(query);
            return rowsAffected > 0;
        }
    }
}