using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MinhThuHotel
{
    public partial class PaymentCheckForm : Form
    {
        public PaymentCheckForm()
        {
            InitializeComponent();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            PaymentConfirmForm confirmForm = new PaymentConfirmForm();
            confirmForm.Show();
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            PaymentForm paymentForm = new PaymentForm();
            paymentForm.Show();
            this.Hide();
        }
    }
}
