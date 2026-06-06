using ComputerClub.Models;
using ComputerClub.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerClub.Services
{
    public class EquipmentService
    {
        private readonly EquipmentRepository eqRepo;

        public EquipmentService()
        {
            eqRepo = new EquipmentRepository();
        }

        public List<Equipment> GetAllEquipment()
        {
            return eqRepo.GetAll();
        }

        public bool UpdateEquipment(Equipment equipment)
        {
            if (equipment == null) return false;

            if (equipment.Number <= 0)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(equipment.Specifications) || equipment.Specifications.Trim().Length < 5)
            {
                return false;
            }

            return eqRepo.Update(equipment);
        }

        public bool DeleteEquipment(int id)
        {
            return eqRepo.Delete(id);
        }

        public List<Equipment> GetEquipmentByType(EquipmentType type)
        {
            var eqList = eqRepo.GetAll();
            var fiteredEqList = new List<Equipment>();

            foreach (var eq in eqList)
            {
                if (eq.Type == type)
                {
                    fiteredEqList.Add(eq);
                }
            }

            return fiteredEqList;
        }

        public int[] GetEquipmentStatistics()
        {
            List<Equipment> eqList = eqRepo.GetAll();

            int freeCount = 0;
            int occupiedCount = 0;
            int bookedCount = 0;

            foreach (var eq in eqList)
            {
                switch (eq.Status)
                {
                    case EquipmentStatus.Available:
                        freeCount++;
                        break;
                    case EquipmentStatus.Occupied:
                        occupiedCount++;
                        break;
                    case EquipmentStatus.Booked:
                        bookedCount++;
                        break;
                }
            }

            return [freeCount, occupiedCount, bookedCount];
        }

        public List<Equipment> SearchEquipment(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return eqRepo.GetAll();
            }

            return eqRepo.Search(text);
        }

        public bool AddEquipment(Equipment equipment)
        {
            if (equipment == null) return false;

            if (equipment.Number <= 0)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(equipment.Specifications) || equipment.Specifications.Trim().Length < 5)
            {
                return false;
            }

            return eqRepo.Add(equipment);
        }
    }
}
