using ComputerClub.Models;
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
    public partial class EditClientForm : Form
    {
        public Client ClientData { get; private set; }

        public EditClientForm(Client client)
        {
            InitializeComponent();

            ClientData = client;

            txtFullName.Text = client.FullName;
            txtPhone.Text = client.Phone;
            txtEmail.Text = client.Email;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("ПІБ клієнта не може бути порожнім!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(fullName))
            {
                MessageBox.Show("Поле 'ПІБ Клієнта' не може бути порожнім!", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFullName.Focus();
                return;
            }
            if (fullName.Length < 3)
            {
                MessageBox.Show("ПІБ клієнта має містити хоча б 3 символи!", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFullName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Поле 'Номер телефону' не може бути порожнім!", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhone.Focus();
                return;
            }
            string phonePattern = @"^\+?[0-9]{9,12}$";
            if (!Regex.IsMatch(phone, phonePattern))
            {
                MessageBox.Show("Некоректний формат телефону!\nДозволені формати: +380671234567 або 0671234567.",
                                "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhone.Focus();
                return;
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!string.IsNullOrEmpty(email) && !Regex.IsMatch(email, emailPattern))
            {
                MessageBox.Show("Некоректний формат електронної пошти!\nПриклад правильного формату: client@gmail.com",
                                "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }

            ClientData.FullName = txtFullName.Text.Trim();
            ClientData.Phone = txtPhone.Text.Trim();
            ClientData.Email = txtEmail.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
