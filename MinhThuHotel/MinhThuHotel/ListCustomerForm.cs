﻿using MinhThuHotel.Data;
using MinhThuHotel.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
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
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridView1.DataSource = GetCustomerList();
            dataGridView1.Columns["CusID"].Visible = false;
            dataGridView1.Columns["paymentStatus"].Visible = false;
            dataGridView1.Columns["CusID"].HeaderText = "ID";
            dataGridView1.Columns["CusName"].HeaderText = "Họ tên";
            dataGridView1.Columns["Identification"].HeaderText = "CMND";
            dataGridView1.Columns["phoneNumb"].HeaderText = "SĐT";
            dataGridView1.Columns["checkInDate"].HeaderText = "Ngày nhận phòng";
            dataGridView1.Columns["checkOutDate"].HeaderText = "Ngày trả phòng";
            dataGridView1.Columns["roomID"].HeaderText = "Phòng";
            dataGridView1.Columns["price"].HeaderText = "Giá tiền";
            dataGridView1.Columns["paymentStatus"].HeaderText = "Thanh toán";
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(btn);
            btn.HeaderText = "Xóa";
            btn.Text = "X";
            btn.Name = "btnDelete";
            btn.UseColumnTextForButtonValue = true;
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

        private DataTable Search() {
            string query = "SELECT CusID, CusName, Identification, phoneNumb, checkInDate, checkOutDate, roomID, paymentStatus FROM Customer";
            query += " WHERE paymentStatus = Yes";
            query += " AND (CusID LIKE '%' + @SearchTerm + '%'";
            query += " OR CusName LIKE '%' + @SearchTerm + '%'";
            query += " OR Identification LIKE '%' + @SearchTerm + '%'";
            query += " OR phoneNumb LIKE '%' + @SearchTerm + '%'";
            query += " OR checkInDate LIKE '%' + @SearchTerm + '%'";
            query += " OR checkOutDate LIKE '%' + @SearchTerm + '%'";
            query += " OR roomID LIKE '%' + @SearchTerm + '%'";            
            query += " OR price LIKE '%' + @SearchTerm + '%'";            
            query += " OR @SearchTerm = '')";
            using (OleDbConnection con = DBHelper.OpenAccessConnection())
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@SearchTerm", txtSearch.Text.Trim());
                    using (OleDbDataAdapter sda = new OleDbDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
         }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView1.DataSource = this.Search();
        }

        private bool deleteCustomer(object value)
        {
            OleDbConnection con = null;
            try
            {
                con = DBHelper.OpenAccessConnection();
                if (con != null)
                {
                    String sql = "DELETE FROM Customer WHERE CusID = ?";
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;

                    cmd.Parameters.Add("@CustomerId", OleDbType.Char).Value = value;
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        return true;
                    }
                }
            }
            catch (OleDbException ex)
            {
                Console.WriteLine("PaymentForm _ deleteCustomer() _ OleDbException: " + ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                if (MessageBox.Show(string.Format("Bạn có chắc xóa khách hàng: {0}?", row.Cells["CusName"].Value), "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    String room = row.Cells["roomID"].Value.ToString();
                    bool result = deleteCustomer(row.Cells["CusID"].Value);
                    if (result)
                    {
                        dataGridView1.Rows.RemoveAt(row.Index);
                    }
                }
                GetCustomerList();
            }
        }        

        Customer customer;
        private Customer getCurCustomer(DataGridViewCellMouseEventArgs e)
        {            
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                String cusID = row.Cells["cusID"].Value.ToString();
                String cusName = row.Cells["cusName"].Value.ToString();
                String identification = row.Cells["Identification"].Value.ToString();
                String phoneNumb = row.Cells["phoneNumb"].Value.ToString();
                DateTime checkInDate = Convert.ToDateTime(row.Cells["checkInDate"].Value);
                DateTime checkOutDate = Convert.ToDateTime(row.Cells["checkOutDate"].Value);
                int roomID = Convert.ToInt32(row.Cells["roomID"].Value);
                double price = Convert.ToDouble(row.Cells["price"].Value);
                bool paymentStatus = Convert.ToBoolean(row.Cells["paymentStatus"].Value);
                Customer customer = new Customer(cusID, cusName, identification, phoneNumb, checkInDate, checkOutDate, roomID, price, paymentStatus);
                return customer;
            }
            else
            {
                return null;
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            customer = getCurCustomer(e);
            if (customer != null)
            {
                Form form = (Form)Activator.CreateInstance(Type.GetType("MinhThuHotel.UpdateForm"), new object[] { customer });
                form.ShowDialog();
            }
            else
            {
                return;
            }
            dataGridView1.DataSource = GetCustomerList();
            customer = null;
        }
    }
}
