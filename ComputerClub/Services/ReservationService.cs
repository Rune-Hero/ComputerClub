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

            bool isAdded = rsRepo.Add(reservation);

            if (isAdded)
            {
                if (reservation.StartTime <= DateTime.Now && reservation.EndTime > DateTime.Now)
                {
                    rsRepo.UpdateEquipmentStatus(reservation.EquipmentId, "Заброньований");
                }
            }

            return isAdded;
        }

        public bool CancelReservation(int id)
        {
            if (id <= 0) return false;

            Reservation? reservation = rsRepo.GetById(id);

            bool isUpdated = rsRepo.UpdateStatus(id, Reservation.ReservationStatus.Canceled);

            if (isUpdated && reservation != null)
            {
                rsRepo.UpdateEquipmentStatus(reservation.EquipmentId, "Вільний");
            }

            return isUpdated;
        }

        public bool IsEquipmentOccupied(int equipmentId, DateTime startTime, DateTime endTime)
        {
            if (equipmentId <= 0) return false;
            return rsRepo.HasConflictingReservation(equipmentId, startTime, endTime);
        }

        public void CheckAndExpiredReservations()
        {
            rsRepo.AutoUpdateReservationsAndEquipment();
        }
    }
}
