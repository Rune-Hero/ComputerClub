using ComputerClub.Models;
using ComputerClub.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerClub.Services
{
    public class SessionService
    {
        private readonly SessionRepository sessionRepo;
        private readonly ReservationRepository rvRepo;

        public SessionService()
        {
            sessionRepo = new SessionRepository();
            rvRepo = new ReservationRepository();
        }

        public DataTable GetSessionsForGrid()
        {
            return sessionRepo.GetAllForGrid();
        }

        public AutoCompleteStringCollection GetClientNames()
        {
            return rvRepo.GetClientNamesCollection();
        }

        public int GetClientId(string name)
        {
            return rvRepo.GetClientIdByName(name);
        }

        public DataTable GetAvailableEquipment(int preselectedId)
        {
            return sessionRepo.GetAvailableEquipmentForSession(preselectedId);
        }

        public bool StartSession(Session session)
        {
            if (session == null || session.ClientId <= 0 || session.EquipmentId <= 0 || session.TariffId <= 0 || session.DurationHours <= 0)
            {
                return false;
            }

            session.EndTime = session.StartTime.AddHours(session.DurationHours);

            bool isAdded = sessionRepo.Add(session);

            if (isAdded)
            {
                sessionRepo.UpdateEquipmentStatus(session.EquipmentId, "Зайнятий");
            }

            return isAdded;
        }

        public bool StopSessionManually(int sessionId, int equipmentId)
        {
            if (sessionId <= 0 || equipmentId <= 0) return false;
            return sessionRepo.CompleteSession(sessionId, equipmentId);
        }

        public DataRow GetSummaryKPI(DateTime start, DateTime end)
        {
            return sessionRepo.GetSummaryKPI(start, end);
        }

        public DataTable GetRevenueByDays(DateTime start, DateTime end)
        {
            return sessionRepo.GetRevenueByDays(start, end);
        }

        public DataTable GetTariffPopularity(DateTime start, DateTime end)
        {
            return sessionRepo.GetTariffPopularity(start, end);
        }

        public DataTable GetRevenueByHours(DateTime date)
        {
            return sessionRepo.GetRevenueByHours(date);
        }
    }
}
