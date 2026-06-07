using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerClub.Models
{
    public class Session
    {
        public enum SessionStatus
        {
            Active,
            Completed
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public int EquipmentId { get; set; }
        public int TariffId { get; set; }
        public DateTime StartTime { get; set; }
        public int DurationHours { get; set; }
        public DateTime EndTime { get; set; }
        public decimal TotalPrice { get; set; }
        public SessionStatus Status { get; set; } = SessionStatus.Active;
    }
}
