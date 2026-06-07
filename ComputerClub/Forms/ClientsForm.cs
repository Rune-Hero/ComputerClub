using ComputerClub.Models;
using ComputerClub.Services;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client = ComputerClub.Models.Client;

namespace ComputerClub.Forms
{
    public partial class ClientsForm : Form
    {
        ClientService clientService;
        public ClientsForm()
        {
            InitializeComponent();
            clientService = new ClientService();
        }

        public ClientsForm(string initialName) : this()
        {
            txtAddFullName.Text = initialName;
        }

        private void LoadToGrid()
        {
            dgvClients.Rows.Clear();

            var clientList = clientService.GetAllClients();
            foreach (Client client in clientList)
            {
                dgvClients.Rows.Add(client.Id, client.FullName, client.Phone, client.Email);
            }
        }
        private void SetupDataGridView()
        {
            dgvClients.Columns.Clear();

            dgvClients.Columns.Add("Id", "ID");
            dgvClients.Columns["Id"].Visible = false;

            dgvClients.Columns.Add("FullName", "ПІБ Клієнта");
            dgvClients.Columns.Add("Phone", "Номер телефону");
            dgvClients.Columns.Add("Email", "Електронна пошта");

            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.Name = "EditAction";
            editButtonColumn.HeaderText = "";
            editButtonColumn.Text = "🖉";
            editButtonColumn.UseColumnTextForButtonValue = true;
            editButtonColumn.Width = 40;
            editButtonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            editButtonColumn.FlatStyle = FlatStyle.Flat;
            editButtonColumn.CellTemplate.Style.ForeColor = Color.FromArgb(41, 128, 185);
            dgvClients.Columns.Add(editButtonColumn);

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = "DeleteAction";
            deleteButtonColumn.HeaderText = "";
            deleteButtonColumn.Text = "❌";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            deleteButtonColumn.Width = 40;
            deleteButtonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            deleteButtonColumn.FlatStyle = FlatStyle.Flat;
            deleteButtonColumn.CellTemplate.Style.ForeColor = Color.FromArgb(192, 57, 43);
            dgvClients.Columns.Add(deleteButtonColumn);
        }

        private void ClientsForm_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadToGrid();
        }

        private void dgvClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columnName = dgvClients.Columns[e.ColumnIndex].Name;

            int id = Convert.ToInt32(dgvClients.Rows[e.RowIndex].Cells["Id"].Value);
            string clientName = dgvClients.Rows[e.RowIndex].Cells["FullName"].Value?.ToString() ?? "";

            if (columnName == "EditAction")
            {
                string phone = dgvClients.Rows[e.RowIndex].Cells["Phone"].Value?.ToString() ?? "";
                string email = dgvClients.Rows[e.RowIndex].Cells["Email"].Value?.ToString() ?? "";

                Client clientToEdit = new Client
                {
                    Id = id,
                    FullName = clientName,
                    Phone = phone,
                    Email = email
                };

                using (EditClientForm editForm = new EditClientForm(clientToEdit))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        Client updatedClient = editForm.ClientData;

                        bool isSuccess = clientService.UpdateClient(updatedClient);

                        if (isSuccess)
                        {
                            dgvClients.Rows[e.RowIndex].Cells["FullName"].Value = updatedClient.FullName;
                            dgvClients.Rows[e.RowIndex].Cells["Phone"].Value = updatedClient.Phone;
                            dgvClients.Rows[e.RowIndex].Cells["Email"].Value = updatedClient.Email;

                            MessageBox.Show("Дані клієнта успішно оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Не вдалося зберегти зміни в базі даних.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            LoadToGrid();
                        }
                    }
                }
            }
            else if (columnName == "DeleteAction")
            {
                DialogResult result = MessageBox.Show(
                    $"Ви впевнені, що хочете остаточно видалити клієнта \"{clientName}\"?",
                    "Підтвердження видалення",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    bool isSuccess = clientService.DeleteClient(id);

                    if (isSuccess)
                    {
                        dgvClients.Rows.RemoveAt(e.RowIndex);
                        MessageBox.Show("Клієнта успішно видалено з бази даних.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Не вдалося видалити клієнта з бази даних. Спробуйте ще раз.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCreateClient_Click(object sender, EventArgs e)
        {
            string fullName = txtAddFullName.Text.Trim();
            string phone = txtAddPhone.Text.Trim();
            string email = txtAddEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(fullName) || fullName.Length < 3)
            {
                MessageBox.Show("ПІБ клієнта має містити хоча б 3 символи!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAddFullName.Focus();
                return;
            }

            string phonePattern = @"^\+?[0-9]{9,12}$";
            if (!Regex.IsMatch(phone, phonePattern))
            {
                MessageBox.Show("Некоректний формат телефону! Обов'язково від 9 до 12 цифр.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAddPhone.Focus();
                return;
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!string.IsNullOrEmpty(email) && !Regex.IsMatch(email, emailPattern))
            {
                MessageBox.Show("Некоректний формат електронної пошти!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAddEmail.Focus();
                return;
            }

            Client newClient = new Client
            {
                FullName = fullName,
                Phone = phone,
                Email = email
            };

            bool isSuccess = clientService.AddClient(newClient);

            if (isSuccess)
            {
                MessageBox.Show("Клієнта успішно додано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtAddFullName.Clear();
                txtAddPhone.Clear();
                txtAddEmail.Clear();

                LoadToGrid();
            }
            else
            {
                MessageBox.Show("Не вдалося додати клієнта в базу даних. Перевірте унікальність даних.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            dgvClients.Rows.Clear();

            var filteredClients = clientService.SearchClients(searchText);
            foreach (var client in filteredClients)
            {
                dgvClients.Rows.Add(client.Id, client.FullName, client.Phone, client.Email);
            }
        }
    }
}
