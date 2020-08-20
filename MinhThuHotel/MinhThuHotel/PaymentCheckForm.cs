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
    public partial class PaymentCheckForm : Form
    {        

        public PaymentCheckForm(Customer customer)
        {
            InitializeComponent();
            loadData(customer);
        }
        String cusID;
        private void loadData(Customer customer)
        {
            cusID = customer.cusID;
            txtName.Text = customer.cusName;
            txtIdentification.Text = customer.identification;
            txtRoom.Text = customer.roomID.ToString();
            txtPrice.Text = customer.price.ToString();
            txtTotal.Text = customer.price.ToString();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            bool result = checkOut();
            if (result)
            {
                Close();
                Form form = (Form)Activator.CreateInstance(Type.GetType("MinhThuHotel.PaymentConfirmForm"), new object[] { });
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra, vui lòng thử lại!!!");
                Close();
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private double getTotalPrice() {
            txtTotal.Text = (Convert.ToInt32(txtPrice.Text) +
                Convert.ToInt32(numericUpDownWater.Value * 10000)
                + Convert.ToInt32(numericUpDownCoke.Value * 15000)
                + Convert.ToInt32(numericUpDownBeer.Value * 20000)
                + Convert.ToInt32(numericUpDownNoodle.Value * 15000)).ToString();
            return Convert.ToDouble(txtTotal.Text);
        }
        private void numericUpDownWater_ValueChanged(object sender, EventArgs e)
        {
            getTotalPrice();
        }

        private void numericUpDownCoke_ValueChanged(object sender, EventArgs e)
        {
            getTotalPrice();
        }

        private void numericUpDownBeer_ValueChanged(object sender, EventArgs e)
        {
            getTotalPrice();
        }

        private void numericUpDownNoodle_ValueChanged(object sender, EventArgs e)
        {
            getTotalPrice();
        }

        private bool checkOut()
        {
            OleDbConnection con = null;
            try
            {
                con = DBHelper.OpenAccessConnection();
                if (con != null)
                {
                    String sql = "UPDATE Customer SET paymentStatus = YES, price = ? WHERE cusID = ?";

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;

                    cmd.Parameters.Add("@price", OleDbType.Double).Value = getTotalPrice();
                    cmd.Parameters.Add("@cusID", OleDbType.VarChar).Value = cusID;
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        return true;
                    }

                }
            }catch(OleDbException ex)
            {
                Console.WriteLine("PaymentCheckForm _ checkOut() _ OleDbException: " + ex.Message);
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
    }
}
