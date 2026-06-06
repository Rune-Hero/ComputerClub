using ComputerClub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerClub.Forms
{
    public partial class MainForm : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        

        private Button? currentButton;
        private Random random;
        private int tempIndex;
        private Form ActiveForm;

        public MainForm()
        {
            InitializeComponent();
            random = new Random();

            typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, panelTitleBar, new object[] { true });
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            RenderTitleLabel();
            btnMap_Click(btnMap, EventArgs.Empty);
        }

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.colorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.colorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.colorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (ActiveForm != null)
            {
                ActiveForm.Close();
            }
            ActivateButton(btnSender);
            ActiveForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new Font("Segoe UI", 12.5F);
                    panelTitleBar.BackColor = color;
                    lblTitle.Text = currentButton.Text;
                    RenderTitleLabel();
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousButton in panelMenu.Controls)
            {
                if (previousButton.GetType() == typeof(Button))
                {
                    previousButton.BackColor = Color.FromArgb(51, 51, 76);
                    previousButton.ForeColor = Color.Gainsboro;
                    previousButton.Font = new Font("Segoe UI", 10F);
                }
            }
        }

        private void RenderTitleLabel()
        {
            lblTitle.Left = (panelTitleBar.Width - lblTitle.Width) / 2;
            lblTitle.Top = (panelTitleBar.Height - lblTitle.Height) / 2;
        }

        private void btnMap_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MapForm(), sender);
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ClientsForm(), sender);
        }

        private void btnEquipment_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EquipmentForm(), sender);
        }

        private void btnReservations_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ReservationsForm(), sender);
        }

        private void btnSessions_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SessionsForm(), sender);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ReportsForm(), sender);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SettingsForm(), sender);
        }

        private void panelTitleBar_SizeChanged(object sender, EventArgs e)
        {
            RenderTitleLabel();
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelLogo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
