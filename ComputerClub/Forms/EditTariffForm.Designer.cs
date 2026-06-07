namespace ComputerClub.Forms
{
    partial class EditTariffForm
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
            txtEditPrice = new TextBox();
            txtEditName = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // txtEditPrice
            // 
            txtEditPrice.Location = new Point(77, 91);
            txtEditPrice.Name = "txtEditPrice";
            txtEditPrice.Size = new Size(125, 27);
            txtEditPrice.TabIndex = 10;
            // 
            // txtEditName
            // 
            txtEditName.Location = new Point(77, 56);
            txtEditName.Name = "txtEditName";
            txtEditName.Size = new Size(125, 27);
            txtEditName.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 94);
            label3.Name = "label3";
            label3.Size = new Size(44, 20);
            label3.TabIndex = 8;
            label3.Text = "Ціна:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 59);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 7;
            label2.Text = "Назва:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 19);
            label1.Name = "label1";
            label1.Size = new Size(203, 20);
            label1.TabIndex = 6;
            label1.Text = "Редагувати поточний тариф";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(396, 192);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 12;
            btnSave.Text = "Зберегти";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(283, 192);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Скасувати";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // EditTariffForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(502, 233);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(txtEditPrice);
            Controls.Add(txtEditName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditTariffForm";
            Text = "EditTariffForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtEditPrice;
        private TextBox txtEditName;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnSave;
        private Button btnCancel;
    }
}