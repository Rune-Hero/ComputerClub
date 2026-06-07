using ComputerClub.Models;
using ComputerClub.Properties;
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

namespace ComputerClub.Forms
{
    public partial class MapForm : Form
    {
        private readonly EquipmentService equipmentService;
        public MapForm()
        {
            InitializeComponent();
            equipmentService = new EquipmentService();


        }
        private async void MapForm_Load(object sender, EventArgs e)
        {
            UpdateStatistics();
            RenderAllZones();
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
        private void UpdateStatistics()
        {
            int[] stats = equipmentService.GetEquipmentStatistics(); // 0 - avaible, 1 - occupied, 2 - booked

            lblAvaible.Text = $"Вільно: {stats[0]}";
            lblOccupied.Text = $"Зайнято: {stats[1]}";
            lblBooked.Text = $"Заброньовано: {stats[2]}";

            lblTotalDevices.Text = $"Всього пристроїв: {stats.Sum()}";
        }

        private void RenderAllZones()
        {
            this.SuspendLayout();

            flowPanelPC.Controls.Clear();
            flowPanelPS.Controls.Clear();
            flowPanelXbox.Controls.Clear();

            populatePanels(EquipmentType.PC, flowPanelPC);
            populatePanels(EquipmentType.PS4, flowPanelPS);
            populatePanels(EquipmentType.PS5, flowPanelPS);
            populatePanels(EquipmentType.Xbox, flowPanelXbox);

            this.ResumeLayout(true);
        }

        private void populatePanels(EquipmentType type, FlowLayoutPanel panel)
        {
            List<Equipment> devices = equipmentService.GetEquipmentByType(type);

            foreach (Equipment eq in devices)
            {
                Button btnDevice = new Button();
                btnDevice.Size = new Size(90, 90);
                btnDevice.ImageAlign = ContentAlignment.TopCenter;
                btnDevice.TextAlign = ContentAlignment.BottomCenter;
                btnDevice.TextImageRelation = TextImageRelation.ImageAboveText;

                btnDevice.Margin = new Padding(10);
                btnDevice.Text = $"{eq.Type}\n№{eq.Number}";
                btnDevice.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                btnDevice.ForeColor = Color.White;
                btnDevice.FlatStyle = FlatStyle.Flat;
                btnDevice.FlatAppearance.BorderSize = 0;

                switch (eq.Status)
                {
                    case EquipmentStatus.Available:
                        btnDevice.BackColor = Color.FromArgb(46, 139, 87);
                        break;

                    case EquipmentStatus.Occupied:
                        btnDevice.BackColor = Color.FromArgb(192, 57, 43);
                        break;

                    case EquipmentStatus.Booked:
                        btnDevice.BackColor = Color.FromArgb(211, 84, 0);
                        break;

                    default:
                        btnDevice.BackColor = Color.Gray;
                        break;
                }

                switch (eq.Type)
                {
                    case EquipmentType.PC:
                        btnDevice.Image = Resources.PC;
                        break;

                    case EquipmentType.PS4:
                    case EquipmentType.PS5:
                        btnDevice.Image = Resources.PS;
                        break;

                    case EquipmentType.Xbox:
                        btnDevice.Image = Resources.Xbox;
                        break;
                }

                if (IsVipDevice(eq.Type, eq.Number))
                {
                    btnDevice.Paint += (sender, e) =>
                    {
                        Button b = (Button)sender;

                        using (SolidBrush brush = new SolidBrush(Color.FromArgb(212, 175, 55)))
                        {
                            int lineHeight = 10;

                            e.Graphics.FillRectangle(brush, 0, b.Height - lineHeight, b.Width, lineHeight);
                        }
                    };
                }

                btnDevice.Click += (s, args) =>
                {
                    // 1. Визначаємо, чи пристрій є VIP
                    bool isVip = IsVipDevice(eq.Type, eq.Number);

                    // Формуємо текст повідомлення (приводимо статус-енум до рядка)
                    string infoText = $"Керування пристроєм: {eq.Type} №{eq.Number}\nСтатус: {eq.Status}";
                    if (isVip)
                    {
                        infoText += " (VIP ЗОНА)";
                    }

                    // 2. Перевіряємо статус пристрою через Енум
                    if (eq.Status == EquipmentStatus.Available)
                    {
                        // Додаємо запитання про відкриття форми сесій
                        infoText += "\n\nБажаєте запустити нову сесію для цього пристрою?";

                        // Показуємо MessageBox з кнопками "Так" та "Ні"
                        DialogResult result = MessageBox.Show(infoText, "Дія", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        // 3. Якщо адмін натиснув "Так" — створюємо та відкриваємо форму через .Show()
                        if (result == DialogResult.Yes)
                        {
                            // Створюємо форму сесій через перевантажений конструктор
                            SessionsForm sessionsForm = new SessionsForm(eq, isVip);
                            sessionsForm.ShowDialog();
                        }
                    }
                    else
                    {
                        // Якщо статус "Зайнято" або "Заброньовано" — просто виводимо інформацію
                        MessageBox.Show(infoText, "Інформація про пристрій", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                };

                panel.Controls.Add(btnDevice);
            }
        }

        
    }
}
