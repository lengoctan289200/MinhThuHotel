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
            Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            List<Form> forms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                if (f.Name == "BookingForm")
                    forms.Add(f);

            foreach (Form f in forms)
                f.Close();
            Close();            
        }
    }
}
