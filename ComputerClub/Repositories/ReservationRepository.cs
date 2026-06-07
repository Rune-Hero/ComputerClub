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
                    "Активно" => ReservationStatus.Active,
                    "Завершено" => ReservationStatus.Completed,
                    "Скасовано" => ReservationStatus.Canceled,
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

        public DataTable GetAllForGrid()
        {
            string query = @"
                select 
                    r.id as ReservationId,
                    c.full_name as ClientName,
                    e.eq_number as EquipmentNumber,
                    t.tariff_name as TariffName,
                    r.start_time as StartTime,
                    r.end_time as EndTime,
                    r.res_status as ResStatus
                from reservations r
                left join clients c on r.client_id = c.id
                left join equipment e on r.equipment_id = e.id
                left join tariffs t on r.tariff_id = t.id
                order by r.start_time desc";

            return DatabaseManager.Instance.ExecuteQuery(query);
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
                ReservationStatus.Active => "Активно",
                ReservationStatus.Completed => "Завершено",
                ReservationStatus.Canceled => "Скасовано",
                _ => "Активно"
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
                ReservationStatus.Active => "Активно",
                ReservationStatus.Completed => "Завершено",
                ReservationStatus.Canceled => "Скасовано",
                _ => "Активно"
            };

            string startStr = reservation.StartTime.ToString("yyyy-MM-dd HH:mm:ss");
            string endStr = reservation.EndTime.ToString("yyyy-MM-dd HH:mm:ss");

            string query = $"update reservations set " +
                           $"client_id = {reservation.ClientId}, " +
                           $"equipment_id = {reservation.EquipmentId}, " +
                           $"tariff_id = {reservation.TariffId}, " +
                           $"start_time = '{startStr}', " +
                           $"end_time = '{endStr}', " +
                           $"res_status = '{statusStr}' " +
                           $"where id = {reservation.Id}";

            int rowsAffected = DatabaseManager.Instance.ExecuteNonQuery(query);
            return rowsAffected > 0;
        }

        public bool UpdateEquipmentStatus(int equipmentId, string status)
        {
            string query = $"update equipment set eq_status = '{status}' where id = {equipmentId}";
            int rowsAffected = DatabaseManager.Instance.ExecuteNonQuery(query);
            return rowsAffected > 0;
        }
        public bool Delete(int id)
        {
            string query = $"delete from reservations where id = {id}";
            int rowsAffected = DatabaseManager.Instance.ExecuteNonQuery(query);
            return rowsAffected > 0;
        }

        public bool UpdateStatus(int id, ReservationStatus status)
        {
            string statusStr = status switch
            {
                ReservationStatus.Active => "Активно",
                ReservationStatus.Completed => "Завершено",
                ReservationStatus.Canceled => "Скасовано",
                _ => "Активно"
            };

            string query = $"update reservations set res_status = '{statusStr}' where id = {id}";
            int rowsAffected = DatabaseManager.Instance.ExecuteNonQuery(query);
            return rowsAffected > 0;
        }

        public int GetClientIdByName(string fullname)
        {
            string query = $"select id from clients where full_name = '{MySql.Data.MySqlClient.MySqlHelper.EscapeString(fullname)}'";
            DataTable dt = DatabaseManager.Instance.ExecuteQuery(query);

            if (dt.Rows.Count == 0) return 0;
            return Convert.ToInt32(dt.Rows[0]["id"]);
        }

        public AutoCompleteStringCollection GetClientNamesCollection()
        {
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            string query = "select full_name from clients";
            DataTable dt = DatabaseManager.Instance.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                collection.Add(row["full_name"].ToString());
            }

            return collection;
        }

        public DataTable GetAvailableEquipment()
        {
            string query = "select id, eq_number, eq_type from equipment where eq_status = 'Вільний'";
            return DatabaseManager.Instance.ExecuteQuery(query);
        }

        public bool HasConflictingReservation(int equipmentId, DateTime startTime, DateTime endTime)
        {
            string startStr = startTime.ToString("yyyy-MM-dd HH:mm:ss");
            string endStr = endTime.ToString("yyyy-MM-dd HH:mm:ss");

            string query = $@"
            select count(*) 
            from reservations 
            where equipment_id = {equipmentId} 
          and res_status = 'Активно'
          and (
               ('{startStr}' >= start_time and '{startStr}' < end_time) or
               ('{endStr}' > start_time and '{endStr}' <= end_time) or
               (start_time >= '{startStr}' and start_time < '{endStr}')
              )";

            DataTable dt = DatabaseManager.Instance.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]) > 0;
            }
            return false;
        }

        public void AutoUpdateReservationsAndEquipment()
        {
            string nowStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            string activateEquipQuery = $@"
        update equipment set eq_status = 'Заброньований'
        where id in (
            select equipment_id 
            from reservations 
            where res_status = 'Активно' 
              and '{nowStr}' >= start_time 
              and '{nowStr}' < end_time
        )";
            DatabaseManager.Instance.ExecuteNonQuery(activateEquipQuery);

            string getExpiredQuery = $"select id, equipment_id from reservations where res_status = 'Активно' and '{nowStr}' >= end_time";
            DataTable expiredReservations = DatabaseManager.Instance.ExecuteQuery(getExpiredQuery);

            foreach (DataRow row in expiredReservations.Rows)
            {
                int resId = Convert.ToInt32(row["id"]);
                int equipId = Convert.ToInt32(row["equipment_id"]);

                UpdateStatus(resId, Reservation.ReservationStatus.Completed);

                string checkNextQuery = $@"
            select count(*) from reservations 
            where equipment_id = {equipId} 
              and res_status = 'Активно' 
              and '{nowStr}' >= start_time 
              and '{nowStr}' < end_time";

                DataTable dtCheck = DatabaseManager.Instance.ExecuteQuery(checkNextQuery);

                if (dtCheck.Rows.Count == 0 || Convert.ToInt32(dtCheck.Rows[0][0]) == 0)
                {
                    UpdateEquipmentStatus(equipId, "Вільний");
                }
            }
        }
    }
}
