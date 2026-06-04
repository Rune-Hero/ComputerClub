using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerClub.Models
{
    public enum EquipmentType
    {
        PC,
        PS5,
        PS4,
        Xbox
    }
    public enum EquipmentStatus
    {
        Available,
        Occupied,
        Booked
    }

    public class Equipment
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public EquipmentType Type { get; set; }
        public string Specifications { get; set; } = string.Empty;
        public EquipmentStatus Status { get; set; }
    }
}
