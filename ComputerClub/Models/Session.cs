using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerClub.Models
{
    public class Session
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public DateTime StartTime {  get; set; }
        public DateTime EndTime { get; set; }
        public decimal TotalCost { get; set; }
    }
}
