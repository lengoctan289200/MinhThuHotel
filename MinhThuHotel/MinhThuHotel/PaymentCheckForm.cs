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
            Close();
            Form form = (Form)Activator.CreateInstance(Type.GetType("MinhThuHotel.PaymentConfirmForm"), new object[] { });
            form.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
