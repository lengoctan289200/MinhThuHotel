using MinhThuHotel.Data;
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
            DataGridViewPayment.Columns["price"].HeaderText = "Giá tiền";
            DataGridViewPayment.Columns["paymentStatus"].HeaderText = "Thanh toán";
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            DataGridViewPayment.Columns.Add(btn);
            btn.HeaderText = "Xóa";
            btn.Text = "X";
            btn.Name = "btnDelete";
            btn.UseColumnTextForButtonValue = true;
            DataGridViewPayment.AllowUserToAddRows = false;
        }

        public DataTable GetPaymentList()
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
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
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

        private void updateStatus(String value)
        {
            OleDbConnection con = null;
            try
            {
                con = DBHelper.OpenAccessConnection();
                if (con != null)
                {
                    String sql = "UPDATE Room " +
                        "SET Available= Yes WHERE roomID= ?";
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;

                    cmd.Parameters.Add("@roomID", OleDbType.Integer).Value = Convert.ToInt32(value);
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        return;
                    }
                }
            }
            catch (AccessViolationException ex)
            {
                Console.WriteLine("PaymentForm _ updateStatus() _ OleDbException: " + ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();

                }
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

        private void DataGridViewPayment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                DataGridViewRow row = DataGridViewPayment.Rows[e.RowIndex];
                if (MessageBox.Show(string.Format("Bạn có chắc xóa khách hàng: {0}?", row.Cells["CusName"].Value), "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    String room = row.Cells["roomID"].Value.ToString();
                    bool result = deleteCustomer(row.Cells["CusID"].Value);
                    if (result)
                    {
                        DataGridViewPayment.Rows.RemoveAt(row.Index);
                        updateStatus(room);
                    }
                }
                GetPaymentList();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void DataGridViewPayment_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = DataGridViewPayment.Rows[e.RowIndex];
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
            Form form = (Form)Activator.CreateInstance(Type.GetType("MinhThuHotel.UpdateForm"), new object[] { customer });
            form.ShowDialog();
        }
    }
}
