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

        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            Form form = (Form)Activator.CreateInstance(Type.GetType("MinhThuHotel.BookingForm"), new object[] { });
            form.ShowDialog();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {

        }

    }
}
