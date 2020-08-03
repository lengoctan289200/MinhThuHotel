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
            Form form = (Form)Activator.CreateInstance(Type.GetType("MinhThuHotel.BookingForm"), new object[] { });
            form.ShowDialog();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
