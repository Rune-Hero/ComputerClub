namespace ComputerClub.Forms
{
    partial class ClientsForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            tableMain = new TableLayoutPanel();
            tableDGV_search = new TableLayoutPanel();
            dgvClients = new DataGridView();
            panelSearchContainer = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            txtSearch = new TextBox();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            btnCreateClient = new Button();
            txtAddEmail = new TextBox();
            label4 = new Label();
            txtAddPhone = new TextBox();
            label2 = new Label();
            txtAddFullName = new TextBox();
            label3 = new Label();
            lblAddTitle = new Label();
            tableMain.SuspendLayout();
            tableDGV_search.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            panelSearchContainer.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableMain
            // 
            tableMain.ColumnCount = 2;
            tableMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableMain.Controls.Add(tableDGV_search, 0, 0);
            tableMain.Controls.Add(panel1, 1, 0);
            tableMain.Dock = DockStyle.Fill;
            tableMain.Location = new Point(0, 0);
            tableMain.Name = "tableMain";
            tableMain.RowCount = 1;
            tableMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableMain.Size = new Size(800, 450);
            tableMain.TabIndex = 0;
            // 
            // tableDGV_search
            // 
            tableDGV_search.ColumnCount = 1;
            tableDGV_search.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableDGV_search.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableDGV_search.Controls.Add(dgvClients, 0, 1);
            tableDGV_search.Controls.Add(panelSearchContainer, 0, 0);
            tableDGV_search.Dock = DockStyle.Fill;
            tableDGV_search.Location = new Point(3, 3);
            tableDGV_search.Name = "tableDGV_search";
            tableDGV_search.RowCount = 2;
            tableDGV_search.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableDGV_search.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableDGV_search.Size = new Size(554, 444);
            tableDGV_search.TabIndex = 0;
            // 
            // dgvClients
            // 
            dgvClients.AllowUserToAddRows = false;
            dgvClients.AllowUserToDeleteRows = false;
            dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClients.BackgroundColor = SystemColors.Control;
            dgvClients.BorderStyle = BorderStyle.None;
            dgvClients.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvClients.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 148, 200);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = Color.Gainsboro;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvClients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvClients.ColumnHeadersHeight = 40;
            dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvClients.Dock = DockStyle.Fill;
            dgvClients.EnableHeadersVisualStyles = false;
            dgvClients.GridColor = SystemColors.ButtonFace;
            dgvClients.Location = new Point(3, 50);
            dgvClients.Margin = new Padding(3, 0, 0, 0);
            dgvClients.MultiSelect = false;
            dgvClients.Name = "dgvClients";
            dgvClients.RowHeadersVisible = false;
            dgvClients.RowHeadersWidth = 51;
            dgvClients.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dgvClients.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 242, 255);
            dgvClients.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvClients.RowTemplate.Height = 40;
            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClients.Size = new Size(551, 394);
            dgvClients.TabIndex = 0;
            dgvClients.CellContentClick += dgvClients_CellContentClick;
            // 
            // panelSearchContainer
            // 
            panelSearchContainer.Controls.Add(tableLayoutPanel1);
            panelSearchContainer.Dock = DockStyle.Fill;
            panelSearchContainer.Location = new Point(3, 3);
            panelSearchContainer.Name = "panelSearchContainer";
            panelSearchContainer.Padding = new Padding(2);
            panelSearchContainer.Size = new Size(548, 44);
            panelSearchContainer.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 31F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(txtSearch, 1, 0);
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(2, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(544, 40);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Location = new Point(34, 3);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(507, 27);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.loop;
            pictureBox1.ImageLocation = "";
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(25, 27);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(51, 51, 76);
            panel1.Controls.Add(btnCreateClient);
            panel1.Controls.Add(txtAddEmail);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtAddPhone);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtAddFullName);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(lblAddTitle);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(563, 0);
            panel1.Margin = new Padding(3, 0, 0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(237, 450);
            panel1.TabIndex = 1;
            // 
            // btnCreateClient
            // 
            btnCreateClient.BackColor = Color.FromArgb(46, 204, 113);
            btnCreateClient.FlatAppearance.BorderSize = 0;
            btnCreateClient.Location = new Point(33, 382);
            btnCreateClient.Margin = new Padding(0);
            btnCreateClient.Name = "btnCreateClient";
            btnCreateClient.Size = new Size(156, 29);
            btnCreateClient.TabIndex = 7;
            btnCreateClient.Text = "Додати клієнта";
            btnCreateClient.UseVisualStyleBackColor = false;
            btnCreateClient.Click += btnCreateClient_Click;
            // 
            // txtAddEmail
            // 
            txtAddEmail.Location = new Point(14, 317);
            txtAddEmail.Name = "txtAddEmail";
            txtAddEmail.Size = new Size(193, 27);
            txtAddEmail.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.ForeColor = Color.Gainsboro;
            label4.Location = new Point(14, 270);
            label4.Name = "label4";
            label4.Size = new Size(219, 31);
            label4.TabIndex = 5;
            label4.Text = "Електронна пошта";
            // 
            // txtAddPhone
            // 
            txtAddPhone.Location = new Point(14, 221);
            txtAddPhone.Name = "txtAddPhone";
            txtAddPhone.Size = new Size(193, 27);
            txtAddPhone.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.Gainsboro;
            label2.Location = new Point(14, 174);
            label2.Name = "label2";
            label2.Size = new Size(202, 31);
            label2.TabIndex = 3;
            label2.Text = "Номер телефону";
            // 
            // txtAddFullName
            // 
            txtAddFullName.Location = new Point(14, 128);
            txtAddFullName.Name = "txtAddFullName";
            txtAddFullName.Size = new Size(193, 27);
            txtAddFullName.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.ForeColor = Color.Gainsboro;
            label3.Location = new Point(14, 81);
            label3.Name = "label3";
            label3.Size = new Size(144, 31);
            label3.TabIndex = 1;
            label3.Text = "ПІБ Клієнта";
            // 
            // lblAddTitle
            // 
            lblAddTitle.AutoSize = true;
            lblAddTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblAddTitle.ForeColor = Color.Gainsboro;
            lblAddTitle.Location = new Point(24, 6);
            lblAddTitle.Name = "lblAddTitle";
            lblAddTitle.Size = new Size(183, 31);
            lblAddTitle.TabIndex = 0;
            lblAddTitle.Text = "Додати клієнта";
            // 
            // ClientsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableMain);
            Name = "ClientsForm";
            Text = "ClientsForm";
            Load += ClientsForm_Load;
            tableMain.ResumeLayout(false);
            tableDGV_search.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            panelSearchContainer.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableMain;
        private TableLayoutPanel tableDGV_search;
        private DataGridView dgvClients;
        private Panel panel1;
        private TextBox txtAddFullName;
        private Label label3;
        private Label lblAddTitle;
        private TextBox txtAddPhone;
        private Label label2;
        private TextBox txtAddEmail;
        private Label label4;
        private Button btnCreateClient;
        private Panel panelSearchContainer;
        private TextBox txtSearch;
        private PictureBox pictureBox1;
        private TableLayoutPanel tableLayoutPanel1;
    }
}