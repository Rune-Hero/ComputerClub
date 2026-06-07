using ComputerClub.Models;
using ComputerClub.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerClub.Services
{
    public class TariffService
    {
        private readonly TariffRepository trRepo;

        public TariffService()
        {
            trRepo = new TariffRepository();
        }

        public List<Tariff> GetAllTariffs()
        {
            return trRepo.GetAll();
        }

        public bool AddTariff(Tariff tariff)
        {
            if (tariff == null) return false;

            if (string.IsNullOrWhiteSpace(tariff.Name) || tariff.Name.Trim().Length < 3)
            {
                return false;
            }

            tariff.Name = tariff.Name.Trim();

            if (tariff.Price <= 0)
            {
                return false;
            }

            return trRepo.Add(tariff);
        }

        public bool UpdateTariff(Tariff tariff)
        {
            if (tariff == null) return false;

            if (string.IsNullOrWhiteSpace(tariff.Name) || tariff.Name.Trim().Length < 3)
            {
                return false;
            }

            tariff.Name = tariff.Name.Trim();

            if (tariff.Price <= 0)
            {
                return false;
            }

            return trRepo.Update(tariff);
        }

        public bool DeleteTariff(int id)
        {
            return trRepo.Delete(id);
        }
    }

    
}
