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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms["ListCustomerForm"] as ListCustomerForm) != null)
            {
                MessageBox.Show("Danh sách khách hàng đang được bật!");
            } else
            {
                ListCustomerForm listCustomer = new ListCustomerForm();
                listCustomer.Show();
            }            
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms["BookingForm"] as BookingForm) != null)
            {
                MessageBox.Show("Form đặt phòng đang được bật!");
            }
            else
            {
                BookingForm bookingForm = new BookingForm();
                bookingForm.Show();
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms["PaymentForm"] as PaymentForm) != null)
            {
                MessageBox.Show("Danh sách thanh toán đang được bật!");
            }
            else
            {
                PaymentForm listPayment = new PaymentForm();
                listPayment.Show();
            }            
        }
    }
}
