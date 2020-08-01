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
    public partial class BookingForm : Form
    {
        public BookingForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MenuForm mn = new MenuForm();
            mn.Show();
            this.Hide();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            BookingConfirmForm confirmForm = new BookingConfirmForm();
            confirmForm.Show();
            this.Hide();
        }
    }
}
