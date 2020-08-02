namespace MinhThuHotel
{
    partial class PaymentConfirmForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnPay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thanh Toán Thành Công";
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(63, 91);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(129, 45);
            this.btnMenu.TabIndex = 3;
            this.btnMenu.Text = "Quay về Trang Chủ";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(198, 91);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(129, 45);
            this.btnPay.TabIndex = 4;
            this.btnPay.Text = "Tiếp tục Thanh Toán";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // PaymentConfirmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 152);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(405, 191);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(405, 191);
            this.Name = "PaymentConfirmForm";
            this.Text = "PaymentConfirmForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnPay;
    }
}