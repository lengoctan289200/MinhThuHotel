using MinhThuHotel.Data;
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
        public PaymentCheckForm(Customer customer)
        {
            InitializeComponent();
            loadData(customer);
        }
        
        private void loadData(Customer customer)
        {
            txtName.Text = customer.cusName;
            txtIdentification.Text = customer.identification;
            txtRoom.Text = customer.roomID.ToString();
            txtTotal.Text = customer.price.ToString();
            
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
