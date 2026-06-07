namespace ComputerClub.Forms
{
    partial class SessionsForm
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tableLayoutPanel1 = new TableLayoutPanel();
            dgvSessions = new DataGridView();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel1 = new Panel();
            btnStartSession = new Button();
            nudDuration = new NumericUpDown();
            lblTotalPrice = new Label();
            cbEquipment = new ComboBox();
            txtClientName = new TextBox();
            flpTariffs = new FlowLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSessions).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudDuration).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(dgvSessions, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvSessions
            // 
            dgvSessions.AllowUserToAddRows = false;
            dgvSessions.AllowUserToDeleteRows = false;
            dgvSessions.AllowUserToResizeRows = false;
            dgvSessions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSessions.BackgroundColor = SystemColors.Control;
            dgvSessions.BorderStyle = BorderStyle.None;
            dgvSessions.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvSessions.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvSessions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSessions.ColumnHeadersHeight = 40;
            dgvSessions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvSessions.Dock = DockStyle.Fill;
            dgvSessions.EnableHeadersVisualStyles = false;
            dgvSessions.GridColor = Color.FromArgb(235, 235, 235);
            dgvSessions.Location = new Point(3, 183);
            dgvSessions.MultiSelect = false;
            dgvSessions.Name = "dgvSessions";
            dgvSessions.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(45, 52, 54);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(225, 242, 250);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvSessions.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvSessions.RowHeadersVisible = false;
            dgvSessions.RowHeadersWidth = 51;
            dgvSessions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSessions.Size = new Size(794, 264);
            dgvSessions.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(panel1, 0, 0);
            tableLayoutPanel2.Controls.Add(flpTariffs, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(794, 174);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnStartSession);
            panel1.Controls.Add(nudDuration);
            panel1.Controls.Add(lblTotalPrice);
            panel1.Controls.Add(cbEquipment);
            panel1.Controls.Add(txtClientName);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(391, 168);
            panel1.TabIndex = 0;
            // 
            // btnStartSession
            // 
            btnStartSession.Location = new Point(211, 121);
            btnStartSession.Name = "btnStartSession";
            btnStartSession.Size = new Size(144, 29);
            btnStartSession.TabIndex = 4;
            btnStartSession.Text = "Запустити сеанс";
            btnStartSession.UseVisualStyleBackColor = true;
            btnStartSession.Click += btnStartSession_Click;
            // 
            // nudDuration
            // 
            nudDuration.Location = new Point(23, 104);
            nudDuration.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            nudDuration.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudDuration.Name = "nudDuration";
            nudDuration.Size = new Size(150, 27);
            nudDuration.TabIndex = 3;
            nudDuration.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudDuration.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // lblTotalPrice
            // 
            lblTotalPrice.AutoSize = true;
            lblTotalPrice.Location = new Point(23, 16);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.Size = new Size(77, 20);
            lblTotalPrice.TabIndex = 2;
            lblTotalPrice.Text = "total price";
            // 
            // cbEquipment
            // 
            cbEquipment.FormattingEnabled = true;
            cbEquipment.Location = new Point(183, 58);
            cbEquipment.Name = "cbEquipment";
            cbEquipment.Size = new Size(151, 28);
            cbEquipment.TabIndex = 1;
            // 
            // txtClientName
            // 
            txtClientName.Location = new Point(23, 59);
            txtClientName.Name = "txtClientName";
            txtClientName.Size = new Size(125, 27);
            txtClientName.TabIndex = 0;
            // 
            // flpTariffs
            // 
            flpTariffs.Dock = DockStyle.Fill;
            flpTariffs.Location = new Point(400, 3);
            flpTariffs.Name = "flpTariffs";
            flpTariffs.Size = new Size(391, 168);
            flpTariffs.TabIndex = 1;
            // 
            // SessionsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "SessionsForm";
            Text = "SessionsForm";
            Load += SessionsForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSessions).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudDuration).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel1;
        private TextBox txtClientName;
        private ComboBox cbEquipment;
        private FlowLayoutPanel flpTariffs;
        private Button btnStartSession;
        private NumericUpDown nudDuration;
        private Label lblTotalPrice;
        private DataGridView dgvSessions;
    }
}