namespace MinhThuHotel
{
    partial class BookingConfirmForm
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnBookingPage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(131, 67);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(746, 77);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đặt Phòng Thành Công!";
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(533, 217);
            this.btnMenu.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(344, 107);
            this.btnMenu.TabIndex = 1;
            this.btnMenu.Text = "Quay lại Trang Chủ";
            this.btnMenu.UseVisualStyleBackColor = true;
            // 
            // btnBookingPage
            // 
            this.btnBookingPage.Location = new System.Drawing.Point(144, 217);
            this.btnBookingPage.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnBookingPage.Name = "btnBookingPage";
            this.btnBookingPage.Size = new System.Drawing.Size(344, 107);
            this.btnBookingPage.TabIndex = 2;
            this.btnBookingPage.Text = "Tiếp tục Đặt Phòng";
            this.btnBookingPage.UseVisualStyleBackColor = true;
            // 
            // BookingConfirmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 417);
            this.Controls.Add(this.btnBookingPage);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "BookingConfirmForm";
            this.Text = "BookingConfirmForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnBookingPage;
    }
}