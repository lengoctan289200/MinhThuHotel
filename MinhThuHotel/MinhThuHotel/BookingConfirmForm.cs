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
    public partial class BookingConfirmForm : Form
    {
        public BookingConfirmForm()
        {
            InitializeComponent();
        }

        private void btnBookingPage_Click(object sender, EventArgs e)
        {
            BookingForm form = new BookingForm();
            form.Show();
            Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
