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
    public partial class ListCustomerForm : Form
    {
        public ListCustomerForm()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ListCustomerForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetCustomerList();
            dataGridView1.Columns["CusID"].Visible = false;
            dataGridView1.Columns["CusID"].HeaderText = "ID";
            dataGridView1.Columns["CusName"].HeaderText = "Họ tên";
            dataGridView1.Columns["Identification"].HeaderText = "CMND";
            dataGridView1.Columns["phoneNumb"].HeaderText = "SĐT";
            dataGridView1.Columns["checkInDate"].HeaderText = "Ngày nhận phòng";
            dataGridView1.Columns["checkOutDate"].HeaderText = "Ngày trả phòng";
            dataGridView1.Columns["roomID"].HeaderText = "Phòng";
            dataGridView1.Columns["paymentStatus"].HeaderText = "Thanh toán";
            dataGridView1.AllowUserToAddRows = false;
        }

        private DataTable GetCustomerList()
        {
            DataTable listCustomer = new DataTable();
            OleDbConnection con = null;
            try
            {
                con = DBHelper.OpenAccessConnection();
                if (con != null)
                {
                    String sql = "SELECT * FROM Customer WHERE paymentStatus = Yes";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(sql, con);
                    adapter.Fill(listCustomer);
                }
            }
            catch (OleDbException ex)
            {
                Console.WriteLine("Error: ListCustomerForm _ getCustomerList() _ OleDbException: " + ex.Message);
            }
            return listCustomer;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
