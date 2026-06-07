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
    public partial class EquipmentForm : Form
    {
        EquipmentService equipmentService;

        public EquipmentForm()
        {
            InitializeComponent();
            equipmentService = new EquipmentService();
        }

        private void EquipmentForm_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadToGrid();
            cmbAddType.DataSource = Enum.GetValues(typeof(EquipmentType));
            cmbAddType.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LoadToGrid()
        {
            dgvEquipment.Rows.Clear();

            var equipmentList = equipmentService.GetAllEquipment();
            foreach (Equipment equipment in equipmentList)
            {
                dgvEquipment.Rows.Add(
                    equipment.Id,
                    equipment.Number,
                    equipment.Type,
                    equipment.Specifications,
                    equipment.Status switch
                    {
                        EquipmentStatus.Available => "Вільний",
                        EquipmentStatus.Occupied => "Зайнятий",
                        EquipmentStatus.Booked => "Заброньований",
                        _ => "Вільний"
                    }
                );
            }
        }

        private void SetupDataGridView()
        {
            dgvEquipment.Columns.Clear();

            dgvEquipment.Columns.Add("Id", "ID");
            dgvEquipment.Columns["Id"].Visible = false;

            dgvEquipment.Columns.Add("Number", "Номер пристрою");
            dgvEquipment.Columns.Add("Type", "Тип");
            dgvEquipment.Columns.Add("Specifications", "Технічні характеристики");
            dgvEquipment.Columns.Add("Status", "Статус");

            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.Name = "EditAction";
            editButtonColumn.HeaderText = "";
            editButtonColumn.Text = "🖉";
            editButtonColumn.UseColumnTextForButtonValue = true;
            editButtonColumn.Width = 40;
            editButtonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            editButtonColumn.FlatStyle = FlatStyle.Flat;
            editButtonColumn.CellTemplate.Style.ForeColor = Color.FromArgb(41, 128, 185);
            dgvEquipment.Columns.Add(editButtonColumn);

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = "DeleteAction";
            deleteButtonColumn.HeaderText = "";
            deleteButtonColumn.Text = "❌";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            deleteButtonColumn.Width = 40;
            deleteButtonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            deleteButtonColumn.FlatStyle = FlatStyle.Flat;
            deleteButtonColumn.CellTemplate.Style.ForeColor = Color.FromArgb(192, 57, 43);
            dgvEquipment.Columns.Add(deleteButtonColumn);
        }

        private void dgvEquipment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columnName = dgvEquipment.Columns[e.ColumnIndex].Name;

            int id = Convert.ToInt32(dgvEquipment.Rows[e.RowIndex].Cells["Id"].Value);
            int number = Convert.ToInt32(dgvEquipment.Rows[e.RowIndex].Cells["Number"].Value);
            string specifications = dgvEquipment.Rows[e.RowIndex].Cells["Specifications"].Value?.ToString() ?? "";

            string typeStr = dgvEquipment.Rows[e.RowIndex].Cells["Type"].Value?.ToString() ?? "";
            string statusStr = dgvEquipment.Rows[e.RowIndex].Cells["Status"].Value?.ToString() ?? "";

            if (columnName == "EditAction")
            {
                Enum.TryParse(typeStr, out EquipmentType typeEnum);

                EquipmentStatus statusEnum = statusStr switch
                {
                    "Вільний" => EquipmentStatus.Available,
                    "Зайнятий" => EquipmentStatus.Occupied,
                    "Заброньований" => EquipmentStatus.Booked,
                    _ => EquipmentStatus.Available
                };

                Equipment equipmentToEdit = new Equipment
                {
                    Id = id,
                    Number = number,
                    Type = typeEnum,
                    Specifications = specifications,
                    Status = statusEnum
                };

                using (EditEquipmentForm editForm = new EditEquipmentForm(equipmentToEdit))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        Equipment updatedEquipment = editForm.EquipmentData;

                        bool isSuccess = equipmentService.UpdateEquipment(updatedEquipment);

                        if (isSuccess)
                        {
                            dgvEquipment.Rows[e.RowIndex].Cells["Number"].Value = updatedEquipment.Number;
                            dgvEquipment.Rows[e.RowIndex].Cells["Type"].Value = updatedEquipment.Type.ToString();
                            dgvEquipment.Rows[e.RowIndex].Cells["Specifications"].Value = updatedEquipment.Specifications;

                            dgvEquipment.Rows[e.RowIndex].Cells["Status"].Value = updatedEquipment.Status switch
                            {
                                EquipmentStatus.Available => "Вільний",
                                EquipmentStatus.Occupied => "Зайнятий",
                                EquipmentStatus.Booked => "Заброньований",
                                _ => "Вільний"
                            };

                            MessageBox.Show("Дані про обладнання успішно оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    $"Ви впевнені, що хочете остаточно видалити обладнання №\"{number}\" ({specifications})?",
                    "Підтвердження видалення",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    bool isSuccess = equipmentService.DeleteEquipment(id);

                    if (isSuccess)
                    {
                        dgvEquipment.Rows.RemoveAt(e.RowIndex);
                        MessageBox.Show("Обладнання успішно видалено з бази даних.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Не вдалося видалити обладнання з бази даних. Спробуйте ще раз.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            dgvEquipment.Rows.Clear();

            var filteredEquipment = equipmentService.SearchEquipment(searchText);
            foreach (Equipment equipment in filteredEquipment)
            {
                dgvEquipment.Rows.Add(
                    equipment.Id,
                    equipment.Number,
                    equipment.Type,
                    equipment.Specifications,
                    equipment.Status switch
                    {
                        EquipmentStatus.Available => "Вільний",
                        EquipmentStatus.Occupied => "Зайнятий",
                        EquipmentStatus.Booked => "Заброньований",
                        _ => "Вільний"
                    }
                );
            }
        }

        private void btnCreateEquipment_Click(object sender, EventArgs e)
        {
            string numberText = txtAddNumber.Text.Trim();
            string specifications = txtAddSpecifications.Text.Trim();

            if (!int.TryParse(numberText, out int number) || number <= 0)
            {
                MessageBox.Show("Номер обладнання має бути додатним числом!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAddNumber.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(specifications) || specifications.Length < 5)
            {
                MessageBox.Show("Будь ласка, введіть коректні технічні характеристики (хоча б 5 символів)!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAddSpecifications.Focus();
                return;
            }

            if (cmbAddType.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть тип обладнання з випадаючого списку!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbAddType.Focus();
                return;
            }

            EquipmentType selectedType = (EquipmentType)cmbAddType.SelectedItem;

            Equipment newEquipment = new Equipment
            {
                Number = number,
                Type = selectedType,
                Specifications = specifications,
                Status = EquipmentStatus.Available
            };

            bool isSuccess = equipmentService.AddEquipment(newEquipment);

            if (isSuccess)
            {
                MessageBox.Show("Обладнання успішно додано до бази даних!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtAddNumber.Clear();
                txtAddSpecifications.Clear();

                if (cmbAddType.Items.Count > 0) cmbAddType.SelectedIndex = 0;

                LoadToGrid();
            }
            else
            {
                MessageBox.Show("Не вдалося додати обладнання в базу даних. Перевірте унікальність номера пристрою.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
