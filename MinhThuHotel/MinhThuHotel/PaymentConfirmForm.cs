﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MinhThuHotel
{
    public partial class PaymentConfirmForm : Form
    {
        public PaymentConfirmForm()
        {
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            MenuForm mn = new MenuForm();
            mn.Show();
            this.Hide();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            PaymentForm paymentForm = new PaymentForm();
            paymentForm.Show();
            this.Hide();
        }
    }
}