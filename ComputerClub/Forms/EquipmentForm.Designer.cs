namespace ComputerClub.Forms
{
    partial class EquipmentForm
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
            dgvEquipment = new DataGridView();
            panelSearchContainer = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            txtSearch = new TextBox();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            cmbAddType = new ComboBox();
            btnCreateEquipment = new Button();
            txtAddSpecifications = new TextBox();
            lblSpecifications = new Label();
            lblType = new Label();
            txtAddNumber = new TextBox();
            lblNumber = new Label();
            lblAddTitle = new Label();
            tableMain.SuspendLayout();
            tableDGV_search.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEquipment).BeginInit();
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
            tableMain.TabIndex = 1;
            // 
            // tableDGV_search
            // 
            tableDGV_search.ColumnCount = 1;
            tableDGV_search.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableDGV_search.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableDGV_search.Controls.Add(dgvEquipment, 0, 1);
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
            // dgvEquipment
            // 
            dgvEquipment.AllowUserToAddRows = false;
            dgvEquipment.AllowUserToDeleteRows = false;
            dgvEquipment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEquipment.BackgroundColor = SystemColors.Control;
            dgvEquipment.BorderStyle = BorderStyle.None;
            dgvEquipment.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvEquipment.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 148, 200);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = Color.Gainsboro;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvEquipment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvEquipment.ColumnHeadersHeight = 40;
            dgvEquipment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvEquipment.Dock = DockStyle.Fill;
            dgvEquipment.EnableHeadersVisualStyles = false;
            dgvEquipment.GridColor = SystemColors.ButtonFace;
            dgvEquipment.Location = new Point(3, 50);
            dgvEquipment.Margin = new Padding(3, 0, 0, 0);
            dgvEquipment.MultiSelect = false;
            dgvEquipment.Name = "dgvEquipment";
            dgvEquipment.RowHeadersVisible = false;
            dgvEquipment.RowHeadersWidth = 51;
            dgvEquipment.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dgvEquipment.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 242, 255);
            dgvEquipment.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvEquipment.RowTemplate.Height = 40;
            dgvEquipment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEquipment.Size = new Size(551, 394);
            dgvEquipment.TabIndex = 0;
            dgvEquipment.CellContentClick += dgvEquipment_CellContentClick;
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
            panel1.Controls.Add(cmbAddType);
            panel1.Controls.Add(btnCreateEquipment);
            panel1.Controls.Add(txtAddSpecifications);
            panel1.Controls.Add(lblSpecifications);
            panel1.Controls.Add(lblType);
            panel1.Controls.Add(txtAddNumber);
            panel1.Controls.Add(lblNumber);
            panel1.Controls.Add(lblAddTitle);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(563, 0);
            panel1.Margin = new Padding(3, 0, 0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(237, 450);
            panel1.TabIndex = 1;
            // 
            // cmbAddType
            // 
            cmbAddType.FormattingEnabled = true;
            cmbAddType.Location = new Point(14, 221);
            cmbAddType.Name = "cmbAddType";
            cmbAddType.Size = new Size(193, 28);
            cmbAddType.TabIndex = 8;
            // 
            // btnCreateEquipment
            // 
            btnCreateEquipment.BackColor = Color.FromArgb(46, 204, 113);
            btnCreateEquipment.FlatAppearance.BorderSize = 0;
            btnCreateEquipment.Location = new Point(33, 382);
            btnCreateEquipment.Margin = new Padding(0);
            btnCreateEquipment.Name = "btnCreateEquipment";
            btnCreateEquipment.Size = new Size(156, 29);
            btnCreateEquipment.TabIndex = 7;
            btnCreateEquipment.Text = "Додати обладнання";
            btnCreateEquipment.UseVisualStyleBackColor = false;
            btnCreateEquipment.Click += btnCreateEquipment_Click;
            // 
            // txtAddSpecifications
            // 
            txtAddSpecifications.Location = new Point(14, 317);
            txtAddSpecifications.Name = "txtAddSpecifications";
            txtAddSpecifications.Size = new Size(193, 27);
            txtAddSpecifications.TabIndex = 6;
            // 
            // lblSpecifications
            // 
            lblSpecifications.AutoSize = true;
            lblSpecifications.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblSpecifications.ForeColor = Color.Gainsboro;
            lblSpecifications.Location = new Point(14, 270);
            lblSpecifications.Name = "lblSpecifications";
            lblSpecifications.Size = new Size(192, 31);
            lblSpecifications.TabIndex = 5;
            lblSpecifications.Text = "Характеристики\r\n";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblType.ForeColor = Color.Gainsboro;
            lblType.Location = new Point(14, 174);
            lblType.Name = "lblType";
            lblType.Size = new Size(194, 31);
            lblType.TabIndex = 3;
            lblType.Text = "Тип обладнання";
            // 
            // txtAddNumber
            // 
            txtAddNumber.Location = new Point(14, 128);
            txtAddNumber.Name = "txtAddNumber";
            txtAddNumber.Size = new Size(193, 27);
            txtAddNumber.TabIndex = 2;
            // 
            // lblNumber
            // 
            lblNumber.AutoSize = true;
            lblNumber.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblNumber.ForeColor = Color.Gainsboro;
            lblNumber.Location = new Point(14, 81);
            lblNumber.Name = "lblNumber";
            lblNumber.Size = new Size(90, 31);
            lblNumber.TabIndex = 1;
            lblNumber.Text = "Номер";
            // 
            // lblAddTitle
            // 
            lblAddTitle.AutoSize = true;
            lblAddTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblAddTitle.ForeColor = Color.Gainsboro;
            lblAddTitle.Location = new Point(24, 6);
            lblAddTitle.Name = "lblAddTitle";
            lblAddTitle.Size = new Size(237, 31);
            lblAddTitle.TabIndex = 0;
            lblAddTitle.Text = "Додати обладнання";
            // 
            // EquipmentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableMain);
            Name = "EquipmentForm";
            Text = "EquipmentForm";
            Load += EquipmentForm_Load;
            tableMain.ResumeLayout(false);
            tableDGV_search.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEquipment).EndInit();
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
        private DataGridView dgvEquipment;
        private Panel panelSearchContainer;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox txtSearch;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Button btnCreateEquipment;
        private TextBox txtAddSpecifications;
        private Label lblSpecifications;
        private Label lblType;
        private TextBox txtAddNumber;
        private Label lblNumber;
        private Label lblAddTitle;
        private ComboBox cmbAddType;
    }
}