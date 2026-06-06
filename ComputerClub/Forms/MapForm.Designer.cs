namespace ComputerClub.Forms
{
    partial class MapForm
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
            panelStatistics = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            lblTotalDevices = new Label();
            lblBooked = new Label();
            lblOccupied = new Label();
            lblAvaible = new Label();
            flowPanelPC = new FlowLayoutPanel();
            flowPanelPS = new FlowLayoutPanel();
            flowPanelXbox = new FlowLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panelStatistics.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelStatistics
            // 
            panelStatistics.Controls.Add(tableLayoutPanel2);
            panelStatistics.Dock = DockStyle.Top;
            panelStatistics.Location = new Point(0, 0);
            panelStatistics.Name = "panelStatistics";
            panelStatistics.Size = new Size(800, 50);
            panelStatistics.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.Gainsboro;
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Controls.Add(lblTotalDevices, 0, 0);
            tableLayoutPanel2.Controls.Add(lblBooked, 3, 0);
            tableLayoutPanel2.Controls.Add(lblOccupied, 2, 0);
            tableLayoutPanel2.Controls.Add(lblAvaible, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(800, 50);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // lblTotalDevices
            // 
            lblTotalDevices.AutoSize = true;
            lblTotalDevices.BackColor = Color.Gainsboro;
            lblTotalDevices.Dock = DockStyle.Fill;
            lblTotalDevices.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalDevices.Location = new Point(3, 0);
            lblTotalDevices.Name = "lblTotalDevices";
            lblTotalDevices.Size = new Size(194, 50);
            lblTotalDevices.TabIndex = 3;
            lblTotalDevices.Text = "label1";
            lblTotalDevices.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBooked
            // 
            lblBooked.AutoSize = true;
            lblBooked.BackColor = Color.Gainsboro;
            lblBooked.Dock = DockStyle.Fill;
            lblBooked.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBooked.Location = new Point(603, 0);
            lblBooked.Name = "lblBooked";
            lblBooked.Size = new Size(194, 50);
            lblBooked.TabIndex = 2;
            lblBooked.Text = "label3";
            lblBooked.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblOccupied
            // 
            lblOccupied.AutoSize = true;
            lblOccupied.BackColor = Color.Gainsboro;
            lblOccupied.Dock = DockStyle.Fill;
            lblOccupied.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblOccupied.Location = new Point(403, 0);
            lblOccupied.Name = "lblOccupied";
            lblOccupied.Size = new Size(194, 50);
            lblOccupied.TabIndex = 1;
            lblOccupied.Text = "label2";
            lblOccupied.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAvaible
            // 
            lblAvaible.AutoSize = true;
            lblAvaible.BackColor = Color.Gainsboro;
            lblAvaible.Dock = DockStyle.Fill;
            lblAvaible.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAvaible.Location = new Point(203, 0);
            lblAvaible.Name = "lblAvaible";
            lblAvaible.Size = new Size(194, 50);
            lblAvaible.TabIndex = 0;
            lblAvaible.Text = "label1";
            lblAvaible.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowPanelPC
            // 
            flowPanelPC.AutoScroll = true;
            flowPanelPC.AutoSize = true;
            flowPanelPC.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowPanelPC.Dock = DockStyle.Fill;
            flowPanelPC.Location = new Point(3, 3);
            flowPanelPC.Name = "flowPanelPC";
            flowPanelPC.Size = new Size(794, 202);
            flowPanelPC.TabIndex = 1;
            // 
            // flowPanelPS
            // 
            flowPanelPS.AutoScroll = true;
            flowPanelPS.AutoSize = true;
            flowPanelPS.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowPanelPS.Dock = DockStyle.Fill;
            flowPanelPS.Location = new Point(3, 211);
            flowPanelPS.Name = "flowPanelPS";
            flowPanelPS.Size = new Size(794, 202);
            flowPanelPS.TabIndex = 2;
            // 
            // flowPanelXbox
            // 
            flowPanelXbox.AutoScroll = true;
            flowPanelXbox.AutoSize = true;
            flowPanelXbox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowPanelXbox.Dock = DockStyle.Fill;
            flowPanelXbox.Location = new Point(3, 419);
            flowPanelXbox.Name = "flowPanelXbox";
            flowPanelXbox.Size = new Size(794, 203);
            flowPanelXbox.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(flowPanelPS, 0, 1);
            tableLayoutPanel1.Controls.Add(flowPanelXbox, 0, 2);
            tableLayoutPanel1.Controls.Add(flowPanelPC, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 50);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Size = new Size(800, 625);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // MapForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 675);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panelStatistics);
            Name = "MapForm";
            Text = "MapForm";
            Load += MapForm_Load;
            panelStatistics.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelStatistics;
        private FlowLayoutPanel flowPanelPC;
        private FlowLayoutPanel flowPanelPS;
        private FlowLayoutPanel flowPanelXbox;
        private Label lblBooked;
        private Label lblOccupied;
        private Label lblAvaible;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label lblTotalDevices;
    }
}