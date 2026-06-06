namespace ComputerClub.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelMenu = new Panel();
            btnSettings = new Button();
            btnReports = new Button();
            btnSessions = new Button();
            btnReservations = new Button();
            btnEquipment = new Button();
            btnClients = new Button();
            btnMap = new Button();
            panelLogo = new Panel();
            label1 = new Label();
            panelTitleBar = new Panel();
            lblTitle = new Label();
            panelDesktop = new Panel();
            panelMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            panelTitleBar.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(51, 51, 76);
            panelMenu.Controls.Add(btnSettings);
            panelMenu.Controls.Add(btnReports);
            panelMenu.Controls.Add(btnSessions);
            panelMenu.Controls.Add(btnReservations);
            panelMenu.Controls.Add(btnEquipment);
            panelMenu.Controls.Add(btnClients);
            panelMenu.Controls.Add(btnMap);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(220, 600);
            panelMenu.TabIndex = 0;
            // 
            // btnSettings
            // 
            btnSettings.Dock = DockStyle.Bottom;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 10F);
            btnSettings.ForeColor = Color.Gainsboro;
            btnSettings.Image = Properties.Resources.settings;
            btnSettings.ImageAlign = ContentAlignment.MiddleLeft;
            btnSettings.Location = new Point(0, 540);
            btnSettings.Name = "btnSettings";
            btnSettings.Padding = new Padding(12, 0, 0, 0);
            btnSettings.Size = new Size(220, 60);
            btnSettings.TabIndex = 7;
            btnSettings.Text = "    Налаштування";
            btnSettings.TextAlign = ContentAlignment.MiddleLeft;
            btnSettings.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnReports
            // 
            btnReports.Dock = DockStyle.Top;
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 10F);
            btnReports.ForeColor = Color.Gainsboro;
            btnReports.Image = Properties.Resources.reports;
            btnReports.ImageAlign = ContentAlignment.MiddleLeft;
            btnReports.Location = new Point(0, 380);
            btnReports.Name = "btnReports";
            btnReports.Padding = new Padding(12, 0, 0, 0);
            btnReports.Size = new Size(220, 60);
            btnReports.TabIndex = 6;
            btnReports.Text = "    Звіти";
            btnReports.TextAlign = ContentAlignment.MiddleLeft;
            btnReports.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
            // 
            // btnSessions
            // 
            btnSessions.Dock = DockStyle.Top;
            btnSessions.FlatAppearance.BorderSize = 0;
            btnSessions.FlatStyle = FlatStyle.Flat;
            btnSessions.Font = new Font("Segoe UI", 10F);
            btnSessions.ForeColor = Color.Gainsboro;
            btnSessions.Image = Properties.Resources.sessions;
            btnSessions.ImageAlign = ContentAlignment.MiddleLeft;
            btnSessions.Location = new Point(0, 320);
            btnSessions.Name = "btnSessions";
            btnSessions.Padding = new Padding(12, 0, 0, 0);
            btnSessions.Size = new Size(220, 60);
            btnSessions.TabIndex = 5;
            btnSessions.Text = "    Сеанси";
            btnSessions.TextAlign = ContentAlignment.MiddleLeft;
            btnSessions.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSessions.UseVisualStyleBackColor = true;
            btnSessions.Click += btnSessions_Click;
            // 
            // btnReservations
            // 
            btnReservations.Dock = DockStyle.Top;
            btnReservations.FlatAppearance.BorderSize = 0;
            btnReservations.FlatStyle = FlatStyle.Flat;
            btnReservations.Font = new Font("Segoe UI", 10F);
            btnReservations.ForeColor = Color.Gainsboro;
            btnReservations.Image = Properties.Resources.reservations;
            btnReservations.ImageAlign = ContentAlignment.MiddleLeft;
            btnReservations.Location = new Point(0, 260);
            btnReservations.Name = "btnReservations";
            btnReservations.Padding = new Padding(12, 0, 0, 0);
            btnReservations.Size = new Size(220, 60);
            btnReservations.TabIndex = 4;
            btnReservations.Text = "    Бронювання";
            btnReservations.TextAlign = ContentAlignment.MiddleLeft;
            btnReservations.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReservations.UseVisualStyleBackColor = true;
            btnReservations.Click += btnReservations_Click;
            // 
            // btnEquipment
            // 
            btnEquipment.Dock = DockStyle.Top;
            btnEquipment.FlatAppearance.BorderSize = 0;
            btnEquipment.FlatStyle = FlatStyle.Flat;
            btnEquipment.Font = new Font("Segoe UI", 10F);
            btnEquipment.ForeColor = Color.Gainsboro;
            btnEquipment.Image = Properties.Resources.equipment;
            btnEquipment.ImageAlign = ContentAlignment.MiddleLeft;
            btnEquipment.Location = new Point(0, 200);
            btnEquipment.Name = "btnEquipment";
            btnEquipment.Padding = new Padding(12, 0, 0, 0);
            btnEquipment.Size = new Size(220, 60);
            btnEquipment.TabIndex = 3;
            btnEquipment.Text = "    Обладнання";
            btnEquipment.TextAlign = ContentAlignment.MiddleLeft;
            btnEquipment.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEquipment.UseVisualStyleBackColor = true;
            btnEquipment.Click += btnEquipment_Click;
            // 
            // btnClients
            // 
            btnClients.Dock = DockStyle.Top;
            btnClients.FlatAppearance.BorderSize = 0;
            btnClients.FlatStyle = FlatStyle.Flat;
            btnClients.Font = new Font("Segoe UI", 10F);
            btnClients.ForeColor = Color.Gainsboro;
            btnClients.Image = Properties.Resources.clients;
            btnClients.ImageAlign = ContentAlignment.MiddleLeft;
            btnClients.Location = new Point(0, 140);
            btnClients.Name = "btnClients";
            btnClients.Padding = new Padding(12, 0, 0, 0);
            btnClients.Size = new Size(220, 60);
            btnClients.TabIndex = 2;
            btnClients.Text = "    Клієнти";
            btnClients.TextAlign = ContentAlignment.MiddleLeft;
            btnClients.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClients.UseVisualStyleBackColor = true;
            btnClients.Click += btnClients_Click;
            // 
            // btnMap
            // 
            btnMap.Dock = DockStyle.Top;
            btnMap.FlatAppearance.BorderSize = 0;
            btnMap.FlatStyle = FlatStyle.Flat;
            btnMap.Font = new Font("Segoe UI", 10F);
            btnMap.ForeColor = Color.Gainsboro;
            btnMap.Image = Properties.Resources.map;
            btnMap.ImageAlign = ContentAlignment.MiddleLeft;
            btnMap.Location = new Point(0, 80);
            btnMap.Name = "btnMap";
            btnMap.Padding = new Padding(12, 0, 0, 0);
            btnMap.Size = new Size(220, 60);
            btnMap.TabIndex = 1;
            btnMap.Text = "    Мапа";
            btnMap.TextAlign = ContentAlignment.MiddleLeft;
            btnMap.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMap.UseVisualStyleBackColor = true;
            btnMap.Click += btnMap_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            panelLogo.Controls.Add(label1);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(220, 80);
            panelLogo.TabIndex = 0;
            panelLogo.MouseDown += panelLogo_MouseDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.ForeColor = Color.Gainsboro;
            label1.Image = Properties.Resources.mountain;
            label1.ImageAlign = ContentAlignment.MiddleLeft;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(195, 56);
            label1.TabIndex = 0;
            label1.Text = "         \"Rock\"\r\n          Computer Club\r\n";
            label1.MouseDown += label1_MouseDown;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelTitleBar.Controls.Add(lblTitle);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(220, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(804, 80);
            panelTitleBar.TabIndex = 1;
            panelTitleBar.SizeChanged += panelTitleBar_SizeChanged;
            panelTitleBar.MouseDown += panelTitleBar_MouseDown;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("MS Reference Sans Serif", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblTitle.ForeColor = Color.Gainsboro;
            lblTitle.Location = new Point(357, 21);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(100, 35);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "HOME";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.MouseDown += lblTitle_MouseDown;
            // 
            // panelDesktop
            // 
            panelDesktop.BackColor = SystemColors.Control;
            panelDesktop.Dock = DockStyle.Fill;
            panelDesktop.Location = new Point(220, 80);
            panelDesktop.Name = "panelDesktop";
            panelDesktop.Size = new Size(804, 520);
            panelDesktop.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 39, 58);
            ClientSize = new Size(1024, 600);
            Controls.Add(panelDesktop);
            Controls.Add(panelTitleBar);
            Controls.Add(panelMenu);
            MinimumSize = new Size(1024, 600);
            Name = "MainForm";
            Load += MainForm_Load;
            panelMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            panelLogo.PerformLayout();
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private Panel panelLogo;
        private Button btnMap;
        private Button btnSettings;
        private Button btnReports;
        private Button btnSessions;
        private Button btnReservations;
        private Button btnEquipment;
        private Button btnClients;
        private Panel panelTitleBar;
        private Label lblTitle;
        private Label label1;
        private Panel panelDesktop;
    }
}