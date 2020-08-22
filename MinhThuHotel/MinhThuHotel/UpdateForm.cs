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

        private bool updateCustomer()
        {
            OleDbConnection con = null;

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
                    cmd.Parameters.Add("@checkOutDate", OleDbType.Double).Value = Convert.ToDouble(txtPrice.Text);
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

        private void dateTimePickerCheckIn_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerCheckOut_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
