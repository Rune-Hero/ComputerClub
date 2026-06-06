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
    public partial class EditEquipmentForm : Form
    {
        public Equipment EquipmentData { get; private set; }
        public EditEquipmentForm(Equipment equipment)
        {
            InitializeComponent();
            EquipmentData = equipment;

            txtNumber.Text = equipment.Number.ToString();
            txtSpecifications.Text = equipment.Specifications;

            cmbType.SelectedItem = equipment.Type;
            cmbStatus.SelectedItem = equipment.Status;
        }

        private void EditEquipmentForm_Load(object sender, EventArgs e)
        {
            cmbType.DataSource = Enum.GetValues(typeof(EquipmentType));
            cmbStatus.DataSource = Enum.GetValues(typeof(EquipmentStatus));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtNumber.Text.Trim(), out int number) || number <= 0)
            {
                MessageBox.Show("Номер обладнання має бути додатним числом!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNumber.Focus();
                return;
            }

            string specs = txtSpecifications.Text.Trim();
            if (string.IsNullOrWhiteSpace(specs) || specs.Length < 5)
            {
                MessageBox.Show("Будь ласка, введіть коректні характеристики (хоча б 5 символів)!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSpecifications.Focus();
                return;
            }

            EquipmentData.Number = number;
            EquipmentData.Specifications = specs;
            EquipmentData.Type = (EquipmentType)cmbType.SelectedItem!;
            EquipmentData.Status = (EquipmentStatus)cmbStatus.SelectedItem!;

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
