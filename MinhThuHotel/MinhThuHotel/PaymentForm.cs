using MinhThuHotel.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MinhThuHotel
{
    public partial class PaymentForm : Form
    {
        public PaymentForm()
        {
            InitializeComponent();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            Form form = (Form)Activator.CreateInstance(Type.GetType("MinhThuHotel.PaymentCheckForm"), new object[] { });
            form.ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            DataGridViewPayment.DataSource = GetPaymentList();
            DataGridViewPayment.Columns["CusID"].Visible = false;
            DataGridViewPayment.Columns["CusID"].HeaderText = "ID";
            DataGridViewPayment.Columns["CusName"].HeaderText = "Họ tên";
            DataGridViewPayment.Columns["Identification"].HeaderText = "CMND";
            DataGridViewPayment.Columns["phoneNumb"].HeaderText = "SĐT";
            DataGridViewPayment.Columns["checkInDate"].HeaderText = "Ngày nhận phòng";
            DataGridViewPayment.Columns["checkOutDate"].HeaderText = "Ngày trả phòng";
            DataGridViewPayment.Columns["roomID"].HeaderText = "Phòng";
            DataGridViewPayment.Columns["paymentStatus"].HeaderText = "Thanh toán";
            DataGridViewPayment.AllowUserToAddRows = false;
        }

        private DataTable GetPaymentList()
        {
            DataTable dtPayment = new DataTable();
            OleDbConnection con = null;
            try
            {
                con = DBHelper.OpenAccessConnection();
                if (con != null)
                {
                    String sql = "SELECT * FROM Customer WHERE paymentStatus = 0";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(sql, con);
                    adapter.Fill(dtPayment);                    
                }
            }
            catch (OleDbException ex)
            {
                Console.WriteLine("Error: ListCustomerForm _ getCustomerList() _ OleDbException: " + ex.Message);
            }
            return dtPayment;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.DataGridViewPayment.SelectedRows)
            {
                DataGridViewPayment.Rows.RemoveAt(item.Index);
            }
        }
    }
}
