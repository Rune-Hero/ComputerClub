using ComputerClub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerClub.Forms
{
    public partial class EditTariffForm : Form
    {
        public Tariff TariffData { get; private set; }

        public EditTariffForm(Tariff tariff)
        {
            InitializeComponent();

            TariffData = tariff;

            txtEditName.Text = tariff.Name;
            txtEditPrice.Text = tariff.Price.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtEditName.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
            {
                MessageBox.Show("Назва має бути від 3 символів!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEditName.Focus();
                return;
            }

            if (!decimal.TryParse(txtEditPrice.Text.Trim(), out decimal price) || price <= 0)
            {
                MessageBox.Show("Введіть коректну ціну за годину!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEditPrice.Focus();
                return;
            }

            TariffData.Name = name;
            TariffData.Price = price;

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
