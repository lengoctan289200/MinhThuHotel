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
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            DataGridViewPayment.Columns.Add(btn);
            btn.HeaderText = "Xóa";
            btn.Text = "X";
            btn.Name = "btnDelete";
            btn.UseColumnTextForButtonValue = true;
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

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            DataGridViewPayment.DataSource = this.Search();
        }

        private DataTable Search()
        {
            string query = "SELECT CusID, CusName, Identification, phoneNumb, checkInDate, checkOutDate, roomID, paymentStatus FROM Customer";
            query += " WHERE paymentStatus = No";
            query += " AND (CusID LIKE '%' + @SearchTerm + '%'";
            query += " OR CusName LIKE '%' + @SearchTerm + '%'";
            query += " OR Identification LIKE '%' + @SearchTerm + '%'";
            query += " OR phoneNumb LIKE '%' + @SearchTerm + '%'";
            query += " OR checkInDate LIKE '%' + @SearchTerm + '%'";
            query += " OR checkOutDate LIKE '%' + @SearchTerm + '%'";
            query += " OR roomID LIKE '%' + @SearchTerm + '%'";
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

        private void DataGridViewPayment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                DataGridViewRow row = DataGridViewPayment.Rows[e.RowIndex];
                if (MessageBox.Show(string.Format("Bạn có chắc xóa khách hàng: {0}?", row.Cells["CusName"].Value), "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        using (OleDbConnection con = DBHelper.OpenAccessConnection())
                        {
                            using (OleDbCommand cmd = new OleDbCommand("DELETE FROM Customer WHERE CusID = @CustomerId", con))
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@CustomerId", row.Cells["CusID"].Value);
                                cmd.ExecuteNonQuery();
                                con.Close();
                                DataGridViewPayment.Rows.RemoveAt(row.Index);
                            }
                        }
                        this.GetPaymentList();
                    }
                    catch (OleDbException ex)
                    {

                        Console.WriteLine("Error: ListCustomerForm _ getCustomerList() _ OleDbException: " + ex.Message);
                    }
                }
            }
        }
    }
}
