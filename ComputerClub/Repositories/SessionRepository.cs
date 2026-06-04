using System;
using System.Collections.Generic;
using System.Data;
using ComputerClub.Models;
using ComputerClub.Database;

namespace ComputerClub.Repositories
{
    public class SessionRepository
    {
        private Session MapRowToSession(DataRow row)
        {
            return new Session
            {
                Id = Convert.ToInt32(row["id"]),
                ReservationId = Convert.ToInt32(row["reservation_id"]),
                StartTime = Convert.ToDateTime(row["start_time"]),
                EndTime = Convert.ToDateTime(row["end_time"]),
                TotalCost = Convert.ToDecimal(row["total_cost"])
            };
        }

        public List<Session> GetAll()
        {
            List<Session> sessions = new List<Session>();
            string query = "select * from session";

            DataTable dt = DatabaseManager.Instance.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                sessions.Add(MapRowToSession(row));
            }

            return sessions;
        }

        public Session? GetById(int id)
        {
            string query = $"select * from session where id = {id}";
            DataTable dt = DatabaseManager.Instance.ExecuteQuery(query);

            if (dt.Rows.Count == 0)
                return null;

            return MapRowToSession(dt.Rows[0]);
        }

        public bool Add(Session session)
        {
            string startStr = session.StartTime.ToString("yyyy-MM-dd HH:mm:ss");
            string endStr = session.EndTime.ToString("yyyy-MM-dd HH:mm:ss");

            string costStr = session.TotalCost.ToString(System.Globalization.CultureInfo.InvariantCulture);

            string query = $"insert into session (reservation_id, start_time, end_time, total_cost) " +
                           $"values ({session.ReservationId}, '{startStr}', '{endStr}', {costStr})";

            int rowsAffected = DatabaseManager.Instance.ExecuteNonQuery(query);
            return rowsAffected > 0;
        }

        public bool Update(Session session)
        {
            string startStr = session.StartTime.ToString("yyyy-MM-dd HH:mm:ss");
            string endStr = session.EndTime.ToString("yyyy-MM-dd HH:mm:ss");
            string costStr = session.TotalCost.ToString(System.Globalization.CultureInfo.InvariantCulture);

            string query = $"update session set " +
                           $"reservation_id = {session.ReservationId}, " +
                           $"start_time = '{startStr}', " +
                           $"end_time = '{endStr}', " +
                           $"total_cost = {costStr} " +
                           $"WHERE id = {session.Id}";

            int rowsAffected = DatabaseManager.Instance.ExecuteNonQuery(query);
            return rowsAffected > 0;
        }

        public bool Delete(int id)
        {
            string query = $"DELETE FROM session WHERE id = {id}";
            int rowsAffected = DatabaseManager.Instance.ExecuteNonQuery(query);
            return rowsAffected > 0;
        }
    }
}