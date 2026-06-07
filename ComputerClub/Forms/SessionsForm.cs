using ComputerClub.Models;
using ComputerClub.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using static ComputerClub.Forms.ReservationsForm;
using Timer = System.Windows.Forms.Timer;

namespace ComputerClub.Forms
{
    public partial class SessionsForm : Form
    {
        private readonly SessionService sessionService;
        private readonly TariffService tariffService;

        private int selectedTariffId = 0;
        private decimal selectedTariffPrice = 0;
        private string selectedTariffName = "";
        private int preselectedEquipmentId = 0;
        private Timer autoUpdateTimer;

        public SessionsForm()
        {
            InitializeComponent();

            sessionService = new SessionService();
            tariffService = new TariffService();

            this.Load += SessionsForm_Load;

            autoUpdateTimer = new Timer();
            autoUpdateTimer.Interval = 30000;
            autoUpdateTimer.Tick += AutoUpdateTimer_Tick;
            autoUpdateTimer.Start();
        }

        public SessionsForm(Equipment equipment, bool isVip) : this()
        {
            // 1. Просто зберігаємо ID
            this.preselectedEquipmentId = equipment.Id;

            // 2. Примусово викликаємо завантаження списку саме для цього пристрою
            LoadEquipmentList();

            // 3. Тепер залізобетонно вибираємо саме цей пристрій у ComboBox
            bool found = false;
            for (int i = 0; i < cbEquipment.Items.Count; i++)
            {
                if (cbEquipment.Items[i] is ComboBoxItem item && item.Id == equipment.Id)
                {
                    cbEquipment.SelectedIndex = i;
                    found = true;
                    break;
                }
            }

            // Якщо раптом у списку його не знайшло (наприклад, через фільтрацію), 
            // але ми точно знаємо, що передали його, додамо його вручну, щоб адмін бачив, що вибрав
            if (!found)
            {
                int index = cbEquipment.Items.Add(new ComboBoxItem
                {
                    Id = equipment.Id,
                    Text = $"{equipment.Type} №{equipment.Number}"
                });
                cbEquipment.SelectedIndex = index;
            }

            // 4. Логіка автоматичного вибору VIP тарифу
            if (isVip)
            {
                // Переконуємося, що кнопки тарифів точно створені
                LoadTariffButtons();

                foreach (Control control in flpTariffs.Controls)
                {
                    if (isVip)
                    {
                        this.Shown += (s, e) =>
                        {
                            // Проходимо по вже створених і відображених кнопках
                            foreach (Control control in flpTariffs.Controls)
                            {
                                if (control is RadioButton rb && rb.Tag is (int id, decimal price, string name))
                                {
                                    string cleanTariffName = name.Trim().ToUpper();

                                    // Шукаємо тариф VIP
                                    if (cleanTariffName.Contains("VIP") ||
                                        cleanTariffName.Contains("ВІП") ||
                                        rb.Text.ToUpper().Contains("VIP") ||
                                        rb.Text.ToUpper().Contains("ВІП"))
                                    {
                                        rb.Checked = true; // Тепер WinForms успішно перемикає кнопку!
                                        break;
                                    }
                                }
                            }
                        };
                    }
                }
            }
        }

        private void SessionsForm_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadToGrid();
            SetupAutoComplete();
            LoadEquipmentList();
            LoadTariffButtons();
            CalculateTotalPrice();

        }

        private void AutoUpdateTimer_Tick(object sender, EventArgs e)
        {
            LoadToGrid();
            LoadEquipmentList();
        }

        private void SetupDataGridView()
        {
            dgvSessions.Columns.Clear();
            dgvSessions.AllowUserToAddRows = false;
            dgvSessions.ReadOnly = true;
            dgvSessions.RowHeadersVisible = false;
            dgvSessions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvSessions.Columns.Add("SessionId", "ID");
            dgvSessions.Columns["SessionId"].Visible = false;

            dgvSessions.Columns.Add("ClientName", "Клієнт");
            dgvSessions.Columns.Add("EquipmentInfo", "Пристрій");
            dgvSessions.Columns.Add("TariffName", "Тариф");
            dgvSessions.Columns.Add("StartTime", "Початок");
            dgvSessions.Columns.Add("Duration", "Годин");
            dgvSessions.Columns.Add("EndTime", "Кінець");
            dgvSessions.Columns.Add("TotalPrice", "Сума (грн)");
            dgvSessions.Columns.Add("SessionStatus", "Статус");

            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn
            {
                Name = "ActionBtn",
                HeaderText = "",
                Text = "❌",
                UseColumnTextForButtonValue = true,
                Width = 40,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                FlatStyle = FlatStyle.Flat
            };
            btnColumn.CellTemplate.Style.ForeColor = Color.FromArgb(192, 57, 43);
            dgvSessions.Columns.Add(btnColumn);
        }

        public void LoadToGrid()
        {
            if (sessionService == null || dgvSessions.Columns.Count == 0) return;

            DataTable dt = sessionService.GetSessionsForGrid();
            if (dt == null) return;

            dgvSessions.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                DateTime startTime = Convert.ToDateTime(row["StartTime"]);
                DateTime endTime = Convert.ToDateTime(row["EndTime"]);

                dgvSessions.Rows.Add(
                    row["SessionId"],
                    row["ClientName"],
                    row["EquipmentInfo"],
                    row["TariffName"],
                    startTime.ToString("dd.MM.yyyy HH:mm"),
                    row["Duration"],
                    endTime.ToString("dd.MM.yyyy HH:mm"),
                    Convert.ToDecimal(row["TotalPrice"]).ToString("F2"),
                    row["SessionStatus"]
                );
            }
        }

        private void SetupAutoComplete()
        {
            txtClientName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtClientName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtClientName.AutoCompleteCustomSource = sessionService.GetClientNames();
        }

        private void LoadEquipmentList()
        {
            cbEquipment.Items.Clear();

            DataTable dt = sessionService.GetAvailableEquipment(preselectedEquipmentId);
            if (dt == null) return;

            foreach (DataRow row in dt.Rows)
            {
                int id = Convert.ToInt32(row["id"]);
                string numberStr = row["eq_number"]?.ToString() ?? "0";
                string typeStr = row["eq_type"]?.ToString() ?? "";

                // Парсимо номер та тип для перевірки на VIP
                if (!int.TryParse(numberStr, out int number)) continue;
                if (!Enum.TryParse(typeStr, true, out EquipmentType type)) continue;

                // Визначаємо, чи пристрій є ВІП
                bool isVip = IsVipDevice(type, number);
                string cleanTariffName = selectedTariffName.Trim().ToLower();

                // ФІЛЬТРАЦІЯ:
                if (cleanTariffName.Contains("vip") || cleanTariffName.Contains("віп"))
                {
                    // Якщо обрано VIP-тариф — додаємо ТІЛЬКИ ВІП-пристрої
                    if (isVip)
                    {
                        cbEquipment.Items.Add(new ComboBoxItem
                        {
                            Id = id,
                            Text = $"{typeStr} №{numberStr} (VIP)"
                        });
                    }
                }
                else
                {
                    // Якщо обрано звичайний тариф (Стандартний/Нічний) — ВІП-пристрої ховаємо
                    if (!isVip)
                    {
                        cbEquipment.Items.Add(new ComboBoxItem
                        {
                            Id = id,
                            Text = $"{typeStr} №{numberStr}"
                        });
                    }
                }
            }

            // Керування обраним індексом
            if (cbEquipment.Items.Count > 0)
            {
                // Якщо форма відкрита просто так — ставимо перший елемент
                if (preselectedEquipmentId == 0)
                {
                    cbEquipment.SelectedIndex = 0;
                }
                else
                {
                    // Якщо пристрій передано з мапи — шукаємо його серед відфільтрованих елементів
                    bool found = false;
                    for (int i = 0; i < cbEquipment.Items.Count; i++)
                    {
                        if (cbEquipment.Items[i] is ComboBoxItem item && item.Id == preselectedEquipmentId)
                        {
                            cbEquipment.SelectedIndex = i;
                            found = true;
                            break;
                        }
                    }
                    // Якщо через фільтр тарифів його тут немає, залишаємо вибір порожнім або ставимо 0
                    if (!found && preselectedEquipmentId == 0) cbEquipment.SelectedIndex = 0;
                }
            }
        }

        private void LoadTariffButtons()
        {
            flpTariffs.Controls.Clear();

            List<Tariff> tariffs = tariffService.GetAllTariffs();
            if (tariffs == null || tariffs.Count == 0) return;

            for (int i = 0; i < tariffs.Count; i++)
            {
                Tariff tariff = tariffs[i];

                RadioButton rb = new RadioButton
                {
                    Text = $"{tariff.Name}\n{tariff.Price:F2} грн",
                    Appearance = Appearance.Button,
                    TextAlign = ContentAlignment.MiddleCenter,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.White,
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    Size = new Size(130, 60),
                    Margin = new Padding(5),
                    Tag = (tariff.Id, tariff.Price, tariff.Name)
                };

                rb.FlatAppearance.CheckedBackColor = Color.FromArgb(0, 123, 255);
                rb.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 240, 240);

                rb.CheckedChanged += (s, e) =>
                {
                    if (rb.Checked)
                    {
                        rb.BackColor = Color.FromArgb(0, 123, 255);
                        rb.ForeColor = Color.White;

                        if (rb.Tag is (int id, decimal price, string name))
                        {
                            selectedTariffId = id;
                            selectedTariffPrice = price;
                            selectedTariffName = name; // Зберігаємо назву тарифу
                        }

                        // ОНОВЛЮЄМО СПИСОК ТЕХНІКИ під новий тариф!
                        LoadEquipmentList();

                        CalculateTotalPrice();
                    }
                    else
                    {
                        rb.BackColor = Color.White;
                        rb.ForeColor = Color.Black;
                    }
                };

                flpTariffs.Controls.Add(rb);

                if (i == 0)
                {
                    rb.Checked = true;
                }
            }
        }

        private void CalculateTotalPrice()
        {
            int hours = (int)nudDuration.Value;
            decimal total = hours * selectedTariffPrice;
            lblTotalPrice.Text = $"До сплати: {total:F2} грн";
        }

        private void btnStartSession_Click(object sender, EventArgs e)
        {
            string clientName = txtClientName.Text.Trim();
            if (string.IsNullOrEmpty(clientName))
            {
                MessageBox.Show("Будь ласка, введіть ПІБ клієнта!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbEquipment.SelectedItem == null)
            {
                MessageBox.Show("Немає вільного обладнання для запуску сесії!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ComboBoxItem selectedEquip = (ComboBoxItem)cbEquipment.SelectedItem;

            if (selectedTariffId == 0)
            {
                MessageBox.Show("Будь ласка, оберіть тариф!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int clientId = sessionService.GetClientId(clientName);

            if (clientId == 0)
            {
                var result = MessageBox.Show(
                    $"Клієнта \"{clientName}\" не знайдено в базі.\nБажаєте додати його зараз?",
                    "Новий клієнт",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    using (ClientsForm addClientForm = new ClientsForm(clientName))
                    {
                        if (addClientForm.ShowDialog() == DialogResult.OK)
                        {
                            SetupAutoComplete();
                            clientId = sessionService.GetClientId(clientName);
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

            int duration = (int)nudDuration.Value;
            DateTime startTime = DateTime.Now;
            decimal totalPrice = duration * selectedTariffPrice;

            Session newSession = new Session
            {
                ClientId = clientId,
                EquipmentId = selectedEquip.Id,
                TariffId = selectedTariffId,
                StartTime = startTime,
                DurationHours = duration,
                TotalPrice = totalPrice,
                Status = Session.SessionStatus.Active
            };

            bool success = sessionService.StartSession(newSession);

            if (success)
            {
                MessageBox.Show(
                    $"Сеанс успішно запущено!\nПристрій: {selectedEquip.Text}\nЧас завершення: {startTime.AddHours(duration):dd.MM.yyyy HH:mm}",
                    "Успіх",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                txtClientName.Clear();
                nudDuration.Value = 1;
                LoadEquipmentList();
                LoadToGrid();
            }
            else
            {
                MessageBox.Show("Не вдалося запустити сесію. Спробуйте ще раз.", "Помилка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
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


    }
}