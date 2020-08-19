namespace MinhThuHotel
{
    partial class PaymentCheckForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdentification = new System.Windows.Forms.TextBox();
            this.txtRoom = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbxWater = new System.Windows.Forms.CheckBox();
            this.cbxC2 = new System.Windows.Forms.CheckBox();
            this.cbxRedBull = new System.Windows.Forms.CheckBox();
            this.cbxSting = new System.Windows.Forms.CheckBox();
            this.cbxPepsi = new System.Windows.Forms.CheckBox();
            this.cbxCoca = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(223, 301);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(200, 41);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(12, 301);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(198, 41);
            this.btnPay.TabIndex = 1;
            this.btnPay.Text = "Thanh Toán";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Khách hàng:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(155, 45);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(176, 20);
            this.txtName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(80, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "CMND:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tiền Phòng:";
            // 
            // txtIdentification
            // 
            this.txtIdentification.Location = new System.Drawing.Point(155, 69);
            this.txtIdentification.Name = "txtIdentification";
            this.txtIdentification.Size = new System.Drawing.Size(143, 20);
            this.txtIdentification.TabIndex = 7;
            // 
            // txtRoom
            // 
            this.txtRoom.Location = new System.Drawing.Point(155, 92);
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.Size = new System.Drawing.Size(143, 20);
            this.txtRoom.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 171);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(414, 54);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbxWater);
            this.panel2.Controls.Add(this.cbxC2);
            this.panel2.Controls.Add(this.cbxRedBull);
            this.panel2.Controls.Add(this.cbxSting);
            this.panel2.Controls.Add(this.cbxPepsi);
            this.panel2.Controls.Add(this.cbxCoca);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(408, 48);
            this.panel2.TabIndex = 2;
            // 
            // cbxWater
            // 
            this.cbxWater.AutoSize = true;
            this.cbxWater.Location = new System.Drawing.Point(329, 26);
            this.cbxWater.Name = "cbxWater";
            this.cbxWater.Size = new System.Drawing.Size(76, 17);
            this.cbxWater.TabIndex = 6;
            this.cbxWater.Text = "Nước Suối";
            this.cbxWater.UseVisualStyleBackColor = true;
            // 
            // cbxC2
            // 
            this.cbxC2.AutoSize = true;
            this.cbxC2.Location = new System.Drawing.Point(329, 3);
            this.cbxC2.Name = "cbxC2";
            this.cbxC2.Size = new System.Drawing.Size(39, 17);
            this.cbxC2.TabIndex = 5;
            this.cbxC2.Text = "C2";
            this.cbxC2.UseVisualStyleBackColor = true;
            // 
            // cbxRedBull
            // 
            this.cbxRedBull.AutoSize = true;
            this.cbxRedBull.Location = new System.Drawing.Point(171, 26);
            this.cbxRedBull.Name = "cbxRedBull";
            this.cbxRedBull.Size = new System.Drawing.Size(63, 17);
            this.cbxRedBull.TabIndex = 4;
            this.cbxRedBull.Text = "RedBull";
            this.cbxRedBull.UseVisualStyleBackColor = true;
            // 
            // cbxSting
            // 
            this.cbxSting.AutoSize = true;
            this.cbxSting.Location = new System.Drawing.Point(171, 3);
            this.cbxSting.Name = "cbxSting";
            this.cbxSting.Size = new System.Drawing.Size(50, 17);
            this.cbxSting.TabIndex = 3;
            this.cbxSting.Text = "Sting";
            this.cbxSting.UseVisualStyleBackColor = true;
            // 
            // cbxPepsi
            // 
            this.cbxPepsi.AutoSize = true;
            this.cbxPepsi.Location = new System.Drawing.Point(3, 26);
            this.cbxPepsi.Name = "cbxPepsi";
            this.cbxPepsi.Size = new System.Drawing.Size(52, 17);
            this.cbxPepsi.TabIndex = 2;
            this.cbxPepsi.Text = "Pepsi";
            this.cbxPepsi.UseVisualStyleBackColor = true;
            // 
            // cbxCoca
            // 
            this.cbxCoca.AutoSize = true;
            this.cbxCoca.Location = new System.Drawing.Point(3, 3);
            this.cbxCoca.Name = "cbxCoca";
            this.cbxCoca.Size = new System.Drawing.Size(71, 17);
            this.cbxCoca.TabIndex = 1;
            this.cbxCoca.Text = "Cocacola";
            this.cbxCoca.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(170, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 22);
            this.label4.TabIndex = 10;
            this.label4.Text = "Dịch Vụ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(84, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 22);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tổng Cộng:";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(197, 261);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(143, 20);
            this.txtTotal.TabIndex = 12;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(155, 116);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(143, 20);
            this.textBox1.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(87, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 21);
            this.label6.TabIndex = 13;
            this.label6.Text = "Phòng:";
            // 
            // PaymentCheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 354);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtRoom);
            this.Controls.Add(this.txtIdentification);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.btnCancel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(454, 393);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(454, 393);
            this.Name = "PaymentCheckForm";
            this.Text = "Xác nhận Thanh Toán";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdentification;
        private System.Windows.Forms.TextBox txtRoom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox cbxCoca;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbxWater;
        private System.Windows.Forms.CheckBox cbxC2;
        private System.Windows.Forms.CheckBox cbxRedBull;
        private System.Windows.Forms.CheckBox cbxSting;
        private System.Windows.Forms.CheckBox cbxPepsi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
    }
}