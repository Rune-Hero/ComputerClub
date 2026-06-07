namespace ComputerClub.Forms
{
    partial class ReportsForm
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
            panelTop = new Panel();
            cbPeriod = new ComboBox();
            panelKPI = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            pnlHours = new Panel();
            lblTotalHours = new Label();
            pnlRev = new Panel();
            lblTotalRevenue = new Label();
            pnlSessions = new Panel();
            lblTotalSessions = new Label();
            panelLineChart = new Panel();
            panelPieChart = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            panelTop.SuspendLayout();
            panelKPI.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            pnlHours.SuspendLayout();
            pnlRev.SuspendLayout();
            pnlSessions.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(cbPeriod);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(622, 60);
            panelTop.TabIndex = 0;
            // 
            // cbPeriod
            // 
            cbPeriod.FormattingEnabled = true;
            cbPeriod.Location = new Point(30, 12);
            cbPeriod.Name = "cbPeriod";
            cbPeriod.Size = new Size(151, 28);
            cbPeriod.TabIndex = 0;
            // 
            // panelKPI
            // 
            panelKPI.Controls.Add(tableLayoutPanel1);
            panelKPI.Dock = DockStyle.Top;
            panelKPI.Location = new Point(0, 60);
            panelKPI.Name = "panelKPI";
            panelKPI.Size = new Size(622, 80);
            panelKPI.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(pnlHours, 2, 0);
            tableLayoutPanel1.Controls.Add(pnlRev, 0, 0);
            tableLayoutPanel1.Controls.Add(pnlSessions, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(622, 80);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // pnlHours
            // 
            pnlHours.Controls.Add(lblTotalHours);
            pnlHours.Dock = DockStyle.Fill;
            pnlHours.Location = new Point(417, 3);
            pnlHours.Name = "pnlHours";
            pnlHours.Size = new Size(202, 74);
            pnlHours.TabIndex = 2;
            // 
            // lblTotalHours
            // 
            lblTotalHours.Dock = DockStyle.Fill;
            lblTotalHours.Location = new Point(0, 0);
            lblTotalHours.Name = "lblTotalHours";
            lblTotalHours.Size = new Size(202, 74);
            lblTotalHours.TabIndex = 5;
            lblTotalHours.Text = "label3";
            lblTotalHours.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlRev
            // 
            pnlRev.Controls.Add(lblTotalRevenue);
            pnlRev.Dock = DockStyle.Fill;
            pnlRev.Location = new Point(3, 3);
            pnlRev.Name = "pnlRev";
            pnlRev.Size = new Size(201, 74);
            pnlRev.TabIndex = 0;
            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.Dock = DockStyle.Fill;
            lblTotalRevenue.Location = new Point(0, 0);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(201, 74);
            lblTotalRevenue.TabIndex = 3;
            lblTotalRevenue.Text = "label1";
            lblTotalRevenue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlSessions
            // 
            pnlSessions.Controls.Add(lblTotalSessions);
            pnlSessions.Dock = DockStyle.Fill;
            pnlSessions.Location = new Point(210, 3);
            pnlSessions.Name = "pnlSessions";
            pnlSessions.Size = new Size(201, 74);
            pnlSessions.TabIndex = 1;
            // 
            // lblTotalSessions
            // 
            lblTotalSessions.Dock = DockStyle.Fill;
            lblTotalSessions.Location = new Point(0, 0);
            lblTotalSessions.Name = "lblTotalSessions";
            lblTotalSessions.Size = new Size(201, 74);
            lblTotalSessions.TabIndex = 4;
            lblTotalSessions.Text = "label2";
            lblTotalSessions.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelLineChart
            // 
            panelLineChart.Dock = DockStyle.Fill;
            panelLineChart.Location = new Point(3, 3);
            panelLineChart.Name = "panelLineChart";
            panelLineChart.Size = new Size(305, 304);
            panelLineChart.TabIndex = 2;
            // 
            // panelPieChart
            // 
            panelPieChart.Dock = DockStyle.Fill;
            panelPieChart.Location = new Point(314, 3);
            panelPieChart.Name = "panelPieChart";
            panelPieChart.Size = new Size(305, 304);
            panelPieChart.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(panelPieChart, 1, 0);
            tableLayoutPanel2.Controls.Add(panelLineChart, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 140);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(622, 310);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(622, 450);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(panelKPI);
            Controls.Add(panelTop);
            Name = "ReportsForm";
            Text = "ReportsForm";
            panelTop.ResumeLayout(false);
            panelKPI.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            pnlHours.ResumeLayout(false);
            pnlRev.ResumeLayout(false);
            pnlSessions.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private ComboBox cbPeriod;
        private Panel panelKPI;
        private Panel pnlHours;
        private Panel pnlSessions;
        private Panel pnlRev;
        private Panel panelLineChart;
        private Panel panelPieChart;
        private Label lblTotalRevenue;
        private Label lblTotalSessions;
        private Label lblTotalHours;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
    }
}