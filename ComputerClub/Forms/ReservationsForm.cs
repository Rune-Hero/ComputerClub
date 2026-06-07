using ComputerClub.Database;
using ComputerClub.Models;
using ComputerClub.Repositories;
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
using System.Xml.Linq;
using static ComputerClub.Models.Reservation;

namespace ComputerClub.Forms
{
    public partial class ReservationsForm : Form
    {
        private readonly ReservationService reservationService;
        private readonly TariffService tariffService;
        private int selectedTariffId = 0;
        private string selectedTariffName = "";

        public ReservationsForm()
        {
            InitializeComponent();
            reservationService = new ReservationService();
            tariffService = new TariffService();

            SetupDataGridView();
            LoadToGrid();
            SetupAutoComplete();
            LoadEquipment();
            LoadTariffButtons();
        }

        private void SetupDataGridView()
        {
            dgvReservations.Columns.Clear();

            dgvReservations.Columns.Add("ReservationId", "ID");
            dgvReservations.Columns["ReservationId"].Visible = false;

            dgvReservations.Columns.Add("ClientName", "Клієнт");
            dgvReservations.Columns.Add("EquipmentNumber", "№ ПК/Консолі");
            dgvReservations.Columns.Add("TariffName", "Тариф");
            dgvReservations.Columns.Add("StartTime", "Початок");
            dgvReservations.Columns.Add("EndTime", "Кінець");
            dgvReservations.Columns.Add("ResStatus", "Статус");

            DataGridViewButtonColumn cancelActionColumn = new DataGridViewButtonColumn();
            cancelActionColumn.Name = "btnCancelAction";
            cancelActionColumn.HeaderText = "";
            cancelActionColumn.Text = "❌";
            cancelActionColumn.UseColumnTextForButtonValue = true;
            cancelActionColumn.Width = 40;
            cancelActionColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            cancelActionColumn.FlatStyle = FlatStyle.Flat;
            cancelActionColumn.CellTemplate.Style.ForeColor = Color.FromArgb(192, 57, 43);
            dgvReservations.Columns.Add(cancelActionColumn);
        }

        public void LoadToGrid()
        {
            dgvReservations.Rows.Clear();
            DataTable dt = reservationService.GetReservationsForGrid();

            foreach (DataRow row in dt.Rows)
            {
                DateTime startTime = Convert.ToDateTime(row["StartTime"]);
                DateTime endTime = Convert.ToDateTime(row["EndTime"]);

                dgvReservations.Rows.Add(
                    row["ReservationId"],
                    row["ClientName"],
                    row["EquipmentNumber"],
                    row["TariffName"],
                    startTime.ToString("dd.MM.yyyy HH:mm"),
                    endTime.ToString("dd.MM.yyyy HH:mm"),
                    row["ResStatus"]
                );
            }
        }

        private void SetupAutoComplete()
        {
            txtName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtName.AutoCompleteCustomSource = reservationService.GetClientNames();
        }

        private void LoadEquipment()
        {
            cbEquipment.Items.Clear();
            DataTable dt = reservationService.GetAvailableEquipment();

            foreach (DataRow row in dt.Rows)
            {
                int id = Convert.ToInt32(row["id"]);
                string numberStr = row["eq_number"].ToString();
                string typeStr = row["eq_type"].ToString();

                if (!int.TryParse(numberStr, out int number))
                {
                    continue;
                }

                if (!Enum.TryParse(typeStr, true, out EquipmentType type))
                {
                    continue;
                }

                bool isVip = IsVipDevice(type, number);

                if (selectedTariffName.ToLower() == "vip")
                {
                    if (isVip)
                    {
                        cbEquipment.Items.Add(new ComboBoxItem { Id = id, Text = $"{typeStr} №{numberStr} (VIP)" });
                    }
                }
                else
                {
                    if (!isVip)
                    {
                        cbEquipment.Items.Add(new ComboBoxItem { Id = id, Text = $"{typeStr} №{numberStr}" });
                    }
                }
            }

            if (cbEquipment.Items.Count > 0)
            {
                cbEquipment.SelectedIndex = 0;
            }
        }

        private bool IsVipDevice(EquipmentType type, int number)
        {
            switch (type)
            {
                case EquipmentType.PC:
                    return (number >= 10 && number <= 15) || (number >= 20 && number <= 22);

                case EquipmentType.PS4:
                case EquipmentType.PS5:
                    return (number >= 7 && number <= 13);

                case EquipmentType.Xbox:
                    return (number >= 4 && number <= 5);

                default:
                    return false;
            }
        }

        private void LoadTariffButtons()
        {
            flpTariffs.Controls.Clear();
            var tariffs = tariffService.GetAllTariffs();

            foreach (var tariff in tariffs)
            {
                RadioButton rb = new RadioButton
                {
                    Text = $"{tariff.Name}",
                    Tag = tariff,
                    Appearance = Appearance.Button,
                    Size = new Size(100, 50),
                    TextAlign = ContentAlignment.MiddleCenter,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(245, 246, 250)
                };

                rb.CheckedChanged += (s, e) =>
                {
                    if (rb.Checked)
                    {
                        rb.BackColor = Color.FromArgb(52, 152, 219);
                        rb.ForeColor = Color.White;
                        selectedTariffId = tariff.Id;
                        selectedTariffName = tariff.Name;
                        LoadEquipment();
                    }
                    else
                    {
                        rb.BackColor = Color.FromArgb(245, 246, 250);
                        rb.ForeColor = Color.Black;
                    }
                };

                flpTariffs.Controls.Add(rb);
            }
        }

        public class ComboBoxItem
        {
            public int Id { get; set; }
            public string Text { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private void dgvReservations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvReservations.Columns[e.ColumnIndex].Name == "btnCancelAction")
            {
                int reservationId = Convert.ToInt32(dgvReservations.Rows[e.RowIndex].Cells["ReservationId"].Value);

                DialogResult result = MessageBox.Show("Скасувати це бронювання?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (reservationService.CancelReservation(reservationId))
                    {
                        LoadToGrid();
                        LoadEquipment();
                    }
                }
            }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            string clientName = txtName.Text.Trim();
            if (string.IsNullOrWhiteSpace(clientName))
            {
                MessageBox.Show("Введіть ПІБ клієнта!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int clientId = reservationService.GetClientId(clientName);
            if (clientId == 0)
            {
                DialogResult dialogResult = MessageBox.Show("Такого клієнта немає. Додати нового?", "Клієнта не знайдено", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    using (ClientsForm addClientForm = new ClientsForm(clientName))
                    {
                        if (addClientForm.ShowDialog() == DialogResult.OK)
                        {
                            SetupAutoComplete();
                            clientId = reservationService.GetClientId(clientName);
                            if (clientId == 0) return;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else
                {
                    return;
                }
            }

            if (cbEquipment.SelectedItem == null)
            {
                MessageBox.Show("Виберіть обладнання!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int equipmentId = ((ComboBoxItem)cbEquipment.SelectedItem).Id;

            if (selectedTariffId == 0)
            {
                MessageBox.Show("Виберіть тариф зі списку зверху!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime date = dtpDate.Value.Date;
            TimeSpan time = dtpTime.Value.TimeOfDay;
            DateTime startTime = date.Add(time);
            DateTime endTime = startTime.AddHours(1);

            if (reservationService.IsEquipmentOccupied(equipmentId, startTime, endTime))
            {
                MessageBox.Show("Це обладнання вже заброньоване на вказаний час!", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Reservation reservation = new Reservation
            {
                ClientId = clientId,
                EquipmentId = equipmentId,
                TariffId = selectedTariffId,
                StartTime = startTime,
                EndTime = endTime,
                ResStatus = ReservationStatus.Active
            };

            if (reservationService.CreateReservation(reservation))
            {
                MessageBox.Show("Бронювання успішно створено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Clear();
                LoadEquipment();
                LoadToGrid();
            }
            else
            {
                MessageBox.Show("Помилка створення бронювання.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
