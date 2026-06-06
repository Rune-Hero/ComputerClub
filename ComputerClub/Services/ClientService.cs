using ComputerClub.Models;
using ComputerClub.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ComputerClub.Services
{
    public class ClientService
    {
        private readonly ClientRepository clRepo;

        public ClientService() 
        {
            clRepo = new ClientRepository();
        }

        public List<Client> GetAllClients()
        {
            return clRepo.GetTop50();
        }

        public bool UpdateClient(Client client)
        {
            if (client == null) return false;

            if (string.IsNullOrWhiteSpace(client.FullName) || client.FullName.Trim().Length < 3)
            {
                return false;
            }

            string phonePattern = @"^\+?[0-9]{9,12}$";
            if (string.IsNullOrWhiteSpace(client.Phone) || !Regex.IsMatch(client.Phone.Trim(), phonePattern))
            {
                return false;
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!string.IsNullOrEmpty(client.Email) && !Regex.IsMatch(client.Email, emailPattern))
            {
                return false;
            }
            return clRepo.Update(client);
        }

        public bool DeleteClient(int id)
        {
            return clRepo.Delete(id);
        }

        public bool AddClient(Client client)
        {
            if (client == null) return false;

            if (string.IsNullOrWhiteSpace(client.FullName) || client.FullName.Trim().Length < 3)
            {
                return false;
            }

            string phonePattern = @"^\+?[0-9]{9,12}$";
            if (string.IsNullOrWhiteSpace(client.Phone) || !Regex.IsMatch(client.Phone.Trim(), phonePattern))
            {
                return false;
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!string.IsNullOrEmpty(client.Email) && !Regex.IsMatch(client.Email, emailPattern))
            {
                return false;
            }

            return clRepo.Add(client);
        }

        public List<Client> SearchClients(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return clRepo.GetTop50();
            }

            return clRepo.Search(text);
        }
    }
}
