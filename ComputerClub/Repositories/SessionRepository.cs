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
                ClientId = Convert.ToInt32(row["client_id"]),
                EquipmentId = Convert.ToInt32(row["equipment_id"]),
                TariffId = Convert.ToInt32(row["tariff_id"]),
                StartTime = Convert.ToDateTime(row["start_time"]),
                DurationHours = Convert.ToInt32(row["duration_hours"]),
                EndTime = Convert.ToDateTime(row["end_time"]),
                TotalPrice = Convert.ToDecimal(row["total_price"]),
                Status = row["session_status"].ToString() == "Завершено"
                    ? Session.SessionStatus.Completed
                    : Session.SessionStatus.Active
            };
        }

        public DataTable GetAllForGrid()
        {
            string query = @"
                select 
                    s.id as SessionId,
                    c.full_name as ClientName,
                    concat(e.eq_type, ' №', e.eq_number) as EquipmentInfo,
                    t.tariff_name as TariffName,
                    s.start_time as StartTime,
                    s.duration_hours as Duration,
                    s.end_time as EndTime,
                    s.total_price as TotalPrice,
                    s.session_status as SessionStatus
                from sessions s
                left join clients c on s.client_id = c.id
                left join equipment e on s.equipment_id = e.id
                left join tariffs t on s.tariff_id = t.id
                order by s.session_status asc, s.start_time desc";

            return DatabaseManager.Instance.ExecuteQuery(query);
        }

        public bool Add(Session session)
        {
            string statusStr = session.Status == Session.SessionStatus.Completed ? "Завершено" : "Активно";
            string startStr = session.StartTime.ToString("yyyy-MM-dd HH:mm:ss");
            string endStr = session.EndTime.ToString("yyyy-MM-dd HH:mm:ss");

            string query = $@"insert into sessions 
                (client_id, equipment_id, tariff_id, start_time, duration_hours, end_time, total_price, session_status) 
                values 
                ({session.ClientId}, {session.EquipmentId}, {session.TariffId}, '{startStr}', {session.DurationHours}, '{endStr}', {session.TotalPrice.ToString().Replace(',', '.')}, '{statusStr}')";

            int rowsAffected = DatabaseManager.Instance.ExecuteNonQuery(query);
            return rowsAffected > 0;
        }

        public bool UpdateEquipmentStatus(int equipmentId, string status)
        {
            string query = $"update equipment set eq_status = '{status}' where id = {equipmentId}";
            return DatabaseManager.Instance.ExecuteNonQuery(query) > 0;
        }

        public DataTable GetAvailableEquipmentForSession(int currentEquipmentId)
        {
            string query = "select id, eq_number, eq_type from equipment where eq_status = 'Вільний'";

            if (currentEquipmentId > 0)
            {
                query += $" or id = {currentEquipmentId}";
            }

            return DatabaseManager.Instance.ExecuteQuery(query);
        }

        public bool CompleteSession(int sessionId, int equipmentId)
        {
            string query = $"update sessions set session_status = 'Завершено' where id = {sessionId}";
            bool isUpdated = DatabaseManager.Instance.ExecuteNonQuery(query) > 0;

            if (isUpdated)
            {
                UpdateEquipmentStatus(equipmentId, "Вільний");
            }
            return isUpdated;
        }

        public DataRow GetSummaryKPI(DateTime startDate, DateTime endDate)
        {
            string startStr = startDate.ToString("yyyy-MM-dd 00:00:00");
            string endStr = endDate.ToString("yyyy-MM-dd 23:59:59");

            string query = $@"
        select 
            coalesce(sum(total_price), 0) as TotalRevenue,
            count(id) as TotalSessions,
            coalesce(sum(duration_hours), 0) as TotalHours
        from sessions 
        where start_time >= '{startStr}' and start_time <= '{endStr}'";

            DataTable dt = DatabaseManager.Instance.ExecuteQuery(query);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        // 2. Дані для лінійного графіка (Дохід по днях)
        

        // 3. Дані для кругової діаграми (Популярність тарифів)
        public DataTable GetTariffPopularity(DateTime startDate, DateTime endDate)
        {
            string startStr = startDate.ToString("yyyy-MM-dd 00:00:00");
            string endStr = endDate.ToString("yyyy-MM-dd 23:59:59");

            string query = $@"
        select 
            t.tariff_name as TariffName,
            count(s.id) as UsageCount
        from sessions s
        join tariffs t on s.tariff_id = t.id
        where s.start_time >= '{startStr}' and s.start_time <= '{endStr}'
        group by t.tariff_name
        order by UsageCount desc";

            return DatabaseManager.Instance.ExecuteQuery(query);
        }

        public DataTable GetRevenueByHours(DateTime date)
        {
            string start = date.Date.ToString("yyyy-MM-dd 00:00:00");
            string end = date.Date.ToString("yyyy-MM-dd 23:59:59");

            string query = $@"
                        select
                        hour(start_time) as SessionHour,
                        sum(total_price) as HourlyRevenue
                    from sessions
                    where start_time between '{start}' and '{end}'
                    group by hour(start_time)
                    order by hour(start_time)";

            return DatabaseManager.Instance.ExecuteQuery(query);
        }

        public DataTable GetRevenueByDays(DateTime startDate, DateTime endDate)
        {
            string startStr = startDate.ToString("yyyy-MM-dd 00:00:00");
            string endStr = endDate.ToString("yyyy-MM-dd 23:59:59");

            string query = $@"
        select 
            date(start_time) as SessionDate,
            coalesce(sum(total_price), 0) as DailyRevenue
        from sessions
        where start_time >= '{startStr}' and start_time <= '{endStr}'
        group by date(start_time)
        order by SessionDate asc";

            return DatabaseManager.Instance.ExecuteQuery(query);
        }
    }
}