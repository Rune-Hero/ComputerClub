namespace ComputerClub.Forms
{
    partial class TariffsForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            dgvTariffs = new DataGridView();
            panel1 = new Panel();
            btnAddTariff = new Button();
            txtPrice = new TextBox();
            txtName = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTariffs).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(dgvTariffs, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.Size = new Size(482, 553);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvTariffs
            // 
            dgvTariffs.AllowUserToAddRows = false;
            dgvTariffs.AllowUserToDeleteRows = false;
            dgvTariffs.AllowUserToResizeRows = false;
            dgvTariffs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTariffs.BackgroundColor = SystemColors.Control;
            dgvTariffs.BorderStyle = BorderStyle.None;
            dgvTariffs.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTariffs.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvTariffs.ColumnHeadersHeight = 29;
            dgvTariffs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvTariffs.Dock = DockStyle.Fill;
            dgvTariffs.EnableHeadersVisualStyles = false;
            dgvTariffs.Location = new Point(3, 168);
            dgvTariffs.MultiSelect = false;
            dgvTariffs.Name = "dgvTariffs";
            dgvTariffs.ReadOnly = true;
            dgvTariffs.RowHeadersVisible = false;
            dgvTariffs.RowHeadersWidth = 51;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(45, 52, 54);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(225, 242, 250);
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dgvTariffs.RowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvTariffs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTariffs.Size = new Size(476, 382);
            dgvTariffs.TabIndex = 0;
            dgvTariffs.CellContentClick += dgvTariffs_CellContentClick;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnAddTariff);
            panel1.Controls.Add(txtPrice);
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(476, 159);
            panel1.TabIndex = 1;
            // 
            // btnAddTariff
            // 
            btnAddTariff.Location = new Point(22, 120);
            btnAddTariff.Name = "btnAddTariff";
            btnAddTariff.Size = new Size(94, 29);
            btnAddTariff.TabIndex = 5;
            btnAddTariff.Text = "Додати";
            btnAddTariff.UseVisualStyleBackColor = true;
            btnAddTariff.Click += btnAddTariff_Click;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(82, 83);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(125, 27);
            txtPrice.TabIndex = 4;
            // 
            // txtName
            // 
            txtName.Location = new Point(82, 48);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 86);
            label3.Name = "label3";
            label3.Size = new Size(44, 20);
            label3.TabIndex = 2;
            label3.Text = "Ціна:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 51);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 1;
            label2.Text = "Назва:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 16);
            label1.Name = "label1";
            label1.Size = new Size(153, 20);
            label1.TabIndex = 0;
            label1.Text = "Додати новий тариф";
            // 
            // TariffsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 553);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(500, 600);
            Name = "TariffsForm";
            Text = "TarrifsForm";
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTariffs).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dgvTariffs;
        private Panel panel1;
        private TextBox txtPrice;
        private TextBox txtName;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnAddTariff;
    }
}