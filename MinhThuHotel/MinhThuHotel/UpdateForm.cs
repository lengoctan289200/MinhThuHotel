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
    public partial class UpdateForm : Form
    {
        String cusID;
        public UpdateForm(Customer customer)
        {
            InitializeComponent();
            loadData(customer);
            cusID = customer.cusID;
        }

        public void loadData(Customer customer)
        {
            txtName.Text = customer.cusName;
            txtID.Text = customer.identification;
            txtPhone.Text = customer.phoneNumb;
            txtPrice.Text = customer.price.ToString();            
            txtRoom.Text = customer.roomID.ToString();
            dateTimePickerCheckIn.Value = customer.checkInDate;
            dateTimePickerCheckOut.Value = customer.checkOutDate;            
        }

        private double getPrice()
        {
            OleDbConnection con = null;
            try
            {
                con = DBHelper.OpenAccessConnection();
                if (con != null)
                {
                    String sql = "SELECT price FROM RoomType WHERE ID=?";

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;

                    cmd.Parameters.Add("@ID", OleDbType.VarChar).Value = getRoomType();
                    object result = cmd.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return 0;
        }

        private Object getRoomType()
        {
            OleDbConnection con = null;
            try
            {
                con = DBHelper.OpenAccessConnection();
                if (con != null)
                {
                    String sql = "SELECT roomType FROM Room WHERE roomID=?";
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;

                    cmd.Parameters.Add("@roomID", OleDbType.VarChar).Value = Convert.ToInt32(txtRoom.Text);
                    object result = cmd.ExecuteScalar();
                    return result;
                }
            }
            catch (OleDbException ex)
            {
                Console.WriteLine("UpdateForm _ getRoomType() _ OleDbException: " + ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return null;
        }

        private bool updateCustomer()
        {
            OleDbConnection con = null;
            String name = txtName.Text;
            String ID = txtID.Text;
            String phone = txtPhone.Text;
            String price = txtPrice.Text;
            if (name == "")
            {
                MessageBox.Show("Vui lòng nhập họ tên!");
                txtName.Focus();
            }
            else if (ID == "")
            {
                MessageBox.Show("Vui lòng nhập CMND!");
                txtID.Focus();
            }
            else if (txtID.Text.Length <= 0 || txtID.Text.Length > 12)
            {
                MessageBox.Show("Vui lòng nhập CMND trong khoảng 0-12 ký tự số!");
                txtID.Focus();
            }
            else if (phone == "")
            {
                MessageBox.Show("Vui lòng nhập SĐT!");
                txtPhone.Focus();
            }
            else if (txtPhone.Text.Length <= 0 || txtPhone.Text.Length > 15)
            {
                MessageBox.Show("Vui lòng nhập SĐT trong khoảng 0-15 ký tự số!");
                txtPhone.Focus();
            }
            else if (price == "")
            {
                MessageBox.Show("Vui lòng nhập giá tiền!");
                txtID.Focus();
            }
            else
            {
                try
                {
                    con = DBHelper.OpenAccessConnection();
                    if (con != null)
                    {
                        String sql = "UPDATE Customer " +
                            "SET cusName = ?, Identification = ?, phoneNumb = ?, checkInDate = ?, checkOutDate = ?, price = ? " +
                            "WHERE cusID = ?";

                        OleDbCommand cmd = new OleDbCommand();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = sql;

                        cmd.Parameters.Add("@cusName", OleDbType.VarChar).Value = txtName.Text;
                        cmd.Parameters.Add("@Identification", OleDbType.VarChar).Value = txtID.Text;
                        cmd.Parameters.Add("@phoneNumb", OleDbType.VarChar).Value = txtPhone.Text;
                        cmd.Parameters.Add("@checkInDate", OleDbType.Date).Value = dateTimePickerCheckIn.Value;
                        cmd.Parameters.Add("@checkOutDate", OleDbType.Date).Value = dateTimePickerCheckOut.Value;
                        cmd.Parameters.Add("@price", OleDbType.Double).Value = Convert.ToDouble(txtPrice.Text);
                        cmd.Parameters.Add("@cusID", OleDbType.VarChar).Value = cusID;
                        if (cmd.ExecuteNonQuery() != 0)
                        {
                            return true;
                        }
                    }
                }
                catch (OleDbException ex)
                {
                    Console.WriteLine("UpdateForm _ updateCustomer() _ OleDbException: " + ex.Message);

                }
                finally
                {
                    if (con != null)
                    {
                        con.Close();
                    }
                }
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool result = updateCustomer();
            if (result)
            {
                MessageBox.Show("Chỉnh sửa thành công!");
                Close();
            }
            else
            {
                MessageBox.Show("Chỉnh sửa thất bại!");
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dateTimePickerCheckOut_ValueChanged(object sender, EventArgs e)
        {
            DateTime chkIn = dateTimePickerCheckIn.Value;
            DateTime chkOut = dateTimePickerCheckOut.Value;
            int daytotal = (int)((chkOut - chkIn).TotalDays) + 1;
            double roomPrice = getPrice();
            txtPrice.Text = (daytotal * (int)roomPrice).ToString();
        }

        private void dateTimePickerCheckIn_ValueChanged(object sender, EventArgs e)
        {
            DateTime chkIn = dateTimePickerCheckIn.Value;
            DateTime chkOut = dateTimePickerCheckOut.Value;
            int daytotal = (int)((chkOut - chkIn).TotalDays) + 1;
            double roomPrice = getPrice();
            txtPrice.Text = (daytotal * (int)roomPrice).ToString();
        }
    }
}
