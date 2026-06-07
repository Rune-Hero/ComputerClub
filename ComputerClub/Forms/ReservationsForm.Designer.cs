namespace ComputerClub.Forms
{
    partial class ReservationsForm
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
            tableLayoutPanel2 = new TableLayoutPanel();
            flpTariffs = new FlowLayoutPanel();
            pnlInputs = new Panel();
            btnBook = new Button();
            dtpTime = new DateTimePicker();
            dtpDate = new DateTimePicker();
            cbEquipment = new ComboBox();
            txtName = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dgvReservations = new DataGridView();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            pnlInputs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservations).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel1.Controls.Add(dgvReservations, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(882, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Controls.Add(flpTariffs, 0, 0);
            tableLayoutPanel2.Controls.Add(pnlInputs, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(532, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tableLayoutPanel2.Size = new Size(347, 444);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // flpTariffs
            // 
            flpTariffs.AutoScroll = true;
            flpTariffs.Dock = DockStyle.Fill;
            flpTariffs.Location = new Point(3, 3);
            flpTariffs.Name = "flpTariffs";
            flpTariffs.Size = new Size(341, 171);
            flpTariffs.TabIndex = 0;
            // 
            // pnlInputs
            // 
            pnlInputs.Controls.Add(btnBook);
            pnlInputs.Controls.Add(dtpTime);
            pnlInputs.Controls.Add(dtpDate);
            pnlInputs.Controls.Add(cbEquipment);
            pnlInputs.Controls.Add(txtName);
            pnlInputs.Controls.Add(label4);
            pnlInputs.Controls.Add(label3);
            pnlInputs.Controls.Add(label2);
            pnlInputs.Controls.Add(label1);
            pnlInputs.Dock = DockStyle.Fill;
            pnlInputs.Location = new Point(3, 180);
            pnlInputs.Name = "pnlInputs";
            pnlInputs.Size = new Size(341, 261);
            pnlInputs.TabIndex = 1;
            // 
            // btnBook
            // 
            btnBook.Location = new Point(166, 216);
            btnBook.Name = "btnBook";
            btnBook.Size = new Size(121, 29);
            btnBook.TabIndex = 8;
            btnBook.Text = "Забронювати";
            btnBook.UseVisualStyleBackColor = true;
            btnBook.Click += btnBook_Click;
            // 
            // dtpTime
            // 
            dtpTime.Format = DateTimePickerFormat.Time;
            dtpTime.Location = new Point(152, 165);
            dtpTime.Name = "dtpTime";
            dtpTime.Size = new Size(110, 27);
            dtpTime.TabIndex = 7;
            // 
            // dtpDate
            // 
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(19, 165);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(110, 27);
            dtpDate.TabIndex = 6;
            // 
            // cbEquipment
            // 
            cbEquipment.FormattingEnabled = true;
            cbEquipment.Location = new Point(154, 81);
            cbEquipment.Name = "cbEquipment";
            cbEquipment.Size = new Size(151, 28);
            cbEquipment.TabIndex = 5;
            // 
            // txtName
            // 
            txtName.Location = new Point(19, 82);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 132);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 3;
            label4.Text = "Дата/час";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(166, 58);
            label3.Name = "label3";
            label3.Size = new Size(96, 20);
            label3.TabIndex = 2;
            label3.Text = "Обладнання";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 58);
            label2.Name = "label2";
            label2.Size = new Size(33, 20);
            label2.TabIndex = 1;
            label2.Text = "ПІБ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(48, 12);
            label1.Name = "label1";
            label1.Size = new Size(227, 28);
            label1.TabIndex = 0;
            label1.Text = "Створити бронування";
            // 
            // dgvReservations
            // 
            dgvReservations.AllowUserToAddRows = false;
            dgvReservations.AllowUserToDeleteRows = false;
            dgvReservations.AllowUserToResizeColumns = false;
            dgvReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservations.BackgroundColor = SystemColors.Control;
            dgvReservations.BorderStyle = BorderStyle.None;
            dgvReservations.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvReservations.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvReservations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvReservations.ColumnHeadersHeight = 40;
            dgvReservations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvReservations.Dock = DockStyle.Fill;
            dgvReservations.EnableHeadersVisualStyles = false;
            dgvReservations.GridColor = Color.FromArgb(235, 235, 235);
            dgvReservations.Location = new Point(3, 3);
            dgvReservations.MultiSelect = false;
            dgvReservations.Name = "dgvReservations";
            dgvReservations.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(45, 52, 54);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(225, 242, 250);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvReservations.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvReservations.RowHeadersVisible = false;
            dgvReservations.RowHeadersWidth = 51;
            dgvReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservations.Size = new Size(523, 444);
            dgvReservations.TabIndex = 1;
            dgvReservations.CellContentClick += dgvReservations_CellContentClick;
            // 
            // ReservationsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "ReservationsForm";
            Text = "ReservationsForm";
            Load += ReservationsForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            pnlInputs.ResumeLayout(false);
            pnlInputs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservations).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private FlowLayoutPanel flpTariffs;
        private Panel pnlInputs;
        private DataGridView dgvReservations;
        private ComboBox cbEquipment;
        private TextBox txtName;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DateTimePicker dtpDate;
        private DateTimePicker dtpTime;
        private Button btnBook;
    }
}