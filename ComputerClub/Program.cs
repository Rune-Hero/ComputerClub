using System;
using System.Windows.Forms;
using System.Collections.Generic;
using ComputerClub.Models;
using ComputerClub.Repositories;

namespace ComputerClub
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // ================= ТЕМЧАСОВИЙ ТЕСТ БАЗИ ДАНИХ =================
            try
            {
                ClientRepository clientRepo = new ClientRepository();

                // 1. Створюємо тестового клієнта
                Client newClient = new Client
                {
                    FullName = "Олег Тестовий",
                    Phone = "+380971234567",
                    Email = "test@gmail.com"
                };

                // 2. Пробуємо додати
                bool isAdded = clientRepo.Add(newClient);

                if (isAdded)
                {
                    // 3. Якщо додалося, пробуємо зчитати назад, щоб перевірити GetAll
                    List<Client> allClients = clientRepo.GetAll();

                    MessageBox.Show(
                        $"Успіх! Клієнта додано.\nВсього клієнтів у базі: {allClients.Count}",
                        "Тест БД",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    MessageBox.Show(
                        "Запит виконався, але рядок не додався.",
                        "Увага",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch (Exception ex)
            {
                // Якщо десь помилка підключення або назв колонок — вискочить це вікно
                MessageBox.Show(
                    $"Помилка БД: {ex.Message}",
                    "Критична помилка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            // ================= КІНЕЦЬ ТЕСТУ =================

            // Твій стандартний запуск форми (залишається без змін)
            Application.Run(new Form1());
        }
    }
}