using ComputerClub.Models;
using ComputerClub.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ComputerClub.Models.Reservation;

namespace ComputerClub.Services
{
    public class ReservationService
    {
        private readonly ReservationRepository rsRepo;

        public ReservationService()
        {
            rsRepo = new ReservationRepository();
        }

        public DataTable GetReservationsForGrid()
        {
            return rsRepo.GetAllForGrid();
        }

        public AutoCompleteStringCollection GetClientNames()
        {
            return rsRepo.GetClientNamesCollection();
        }

        public DataTable GetAvailableEquipment()
        {
            return rsRepo.GetAvailableEquipment();
        }

        public int GetClientId(string name)
        {
            return rsRepo.GetClientIdByName(name);
        }

        public bool CreateReservation(Reservation reservation)
        {
            if (reservation == null || reservation.ClientId <= 0 || reservation.EquipmentId <= 0 || reservation.TariffId <= 0)
            {
                return false;
            }

            if (reservation.StartTime >= reservation.EndTime)
            {
                return false;
            }

            return rsRepo.Add(reservation);
        }

        public bool CancelReservation(int id)
        {
            if (id <= 0) return false;
            return rsRepo.UpdateStatus(id, ReservationStatus.Canceled);
        }

        public bool IsEquipmentOccupied(int equipmentId, DateTime startTime, DateTime endTime)
        {
            if (equipmentId <= 0) return false;
            return rsRepo.HasConflictingReservation(equipmentId, startTime, endTime);
        }
    }
}
