using ComputerClub.Models;
using ComputerClub.Services;
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
    public partial class TariffsForm : Form
    {
        private readonly TariffService tariffService;

        public TariffsForm()
        {
            InitializeComponent();
            tariffService = new TariffService();

            SetupDataGridView();
            LoadToGrid();
        }

        private void LoadToGrid()
        {
            dgvTariffs.Rows.Clear();

            var tariffs = tariffService.GetAllTariffs();
            foreach (Tariff tariff in tariffs)
            {
                dgvTariffs.Rows.Add(tariff.Id, tariff.Name, $"{tariff.Price:F2}");
            }
        }

        private void SetupDataGridView()
        {
            dgvTariffs.Columns.Clear();

            dgvTariffs.Columns.Add("Id", "ID");
            dgvTariffs.Columns["Id"].Visible = false;

            dgvTariffs.Columns.Add("Name", "Назва тарифу");
            dgvTariffs.Columns.Add("Price", "Ціна за годину (грн)");

            DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
            editButton.Name = "EditAction";
            editButton.HeaderText = "";
            editButton.Text = "🖉";
            editButton.UseColumnTextForButtonValue = true;
            editButton.Width = 40;
            editButton.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            editButton.FlatStyle = FlatStyle.Flat;
            editButton.CellTemplate.Style.ForeColor = Color.FromArgb(41, 128, 185);
            dgvTariffs.Columns.Add(editButton);

            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "DeleteAction";
            deleteButton.HeaderText = "";
            deleteButton.Text = "❌";
            deleteButton.UseColumnTextForButtonValue = true;
            deleteButton.Width = 40;
            deleteButton.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            deleteButton.FlatStyle = FlatStyle.Flat;
            deleteButton.CellTemplate.Style.ForeColor = Color.FromArgb(192, 57, 43);
            dgvTariffs.Columns.Add(deleteButton);
        }
        private void btnAddTariff_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string priceText = txtPrice.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
            {
                MessageBox.Show("Назва тарифу має містити хоча б 3 символи!", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }

            if (!decimal.TryParse(priceText, out decimal price) || price <= 0)
            {
                MessageBox.Show("Введіть коректну додатну ціну за годину!", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice.Focus();
                return;
            }

            Tariff newTariff = new Tariff
            {
                Name = name,
                Price = price
            };

            bool isSuccess = tariffService.AddTariff(newTariff);

            if (isSuccess)
            {
                MessageBox.Show("Новий тариф успішно додано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtName.Clear();
                txtPrice.Clear();

                LoadToGrid();
            }
            else
            {
                MessageBox.Show("Не вдалося зберегти тариф. Перевірте коректність даних.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTariffs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ігноруємо шапку таблиці

            string columnName = dgvTariffs.Columns[e.ColumnIndex].Name;

            // Витягуємо дані поточного рядка
            int id = Convert.ToInt32(dgvTariffs.Rows[e.RowIndex].Cells["Id"].Value);
            string name = dgvTariffs.Rows[e.RowIndex].Cells["Name"].Value.ToString()!;
            decimal price = Convert.ToDecimal(dgvTariffs.Rows[e.RowIndex].Cells["Price"].Value);

            // ЛОГІКА РЕДАГУВАННЯ
            if (columnName == "EditAction")
            {
                Tariff tariffToEdit = new Tariff { Id = id, Name = name, Price = price };

                // Відкриваємо нашу мікро-форму редагування
                using (EditTariffForm editForm = new EditTariffForm(tariffToEdit))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        Tariff updatedTariff = editForm.TariffData;

                        bool isSuccess = tariffService.UpdateTariff(updatedTariff);
                        if (isSuccess)
                        {
                            // Оновлюємо рядок в інтерфейсі на місці
                            dgvTariffs.Rows[e.RowIndex].Cells["Name"].Value = updatedTariff.Name;
                            dgvTariffs.Rows[e.RowIndex].Cells["Price"].Value = $"{updatedTariff.Price:F2}";

                            MessageBox.Show("Тариф успішно оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Не вдалося оновити дані в базі.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            LoadToGrid();
                        }
                    }
                }
            }
            // ЛОГІКА ВИДАЛЕННЯ
            else if (columnName == "DeleteAction")
            {
                DialogResult result = MessageBox.Show(
                    $"Ви впевнені, що хочете видалити тариф \"{name}\"?",
                    "Підтвердження видалення",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    bool isSuccess = tariffService.DeleteTariff(id);
                    if (isSuccess)
                    {
                        dgvTariffs.Rows.RemoveAt(e.RowIndex);
                        MessageBox.Show("Тариф видалено з бази даних.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Не вдалося видалити тариф. Можливо, він використовується в активних бронюваннях.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
