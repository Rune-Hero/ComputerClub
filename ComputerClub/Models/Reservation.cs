using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerClub.Models
{
    public class Reservation
    {
        public enum ReservationStatus
        {
            Active,
            Completed,
            Canceled
        }

        public int Id { get; set; }

        public int ClientId { get; set; }

        public int EquipmentId { get; set; }

        public int TariffId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public ReservationStatus ResStatus { get; set; }
    }
}
