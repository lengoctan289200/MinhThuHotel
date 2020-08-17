using MinhThuHotel.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Windows.Forms;

namespace MinhThuHotel
{
    public partial class BookingForm : Form
    {
        public BookingForm()
        {
            InitializeComponent();
            loadRoom();
        }
        private void loadRoom()
        {
            DataTable roomTable = new DataTable();
            DataTable roomTypeTable = new DataTable();

            OleDbConnection con = null;
            try
            {
                con = DBHelper.OpenAccessConnection();
                if (con != null)
                {
                    String sql = "SELECT ID FROM RoomType";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(sql, con);
                    adapter.Fill(roomTypeTable);

                    cbxRoomType.DataSource = roomTypeTable;
                    cbxRoomType.DisplayMember = "ID";
                    cbxRoomType.ValueMember = "ID";

                    String sql2 = "SELECT price FROM RoomType WHERE ID = '" + cbxRoomType.SelectedValue.ToString() + "'";
                    OleDbCommand cmd = new OleDbCommand(sql2, con);
                    object result = cmd.ExecuteScalar();
                    txtPrice.Text = result.ToString();

                    String sql3 = "SELECT roomID FROM Room WHERE RoomType= '" + cbxRoomType.SelectedValue.ToString() + "' AND Available= Yes";
                    OleDbDataAdapter adapter3 = new OleDbDataAdapter(sql3, con);
                    adapter3.Fill(roomTable);

                    cbxRoom.DataSource = roomTable;
                    cbxRoom.DisplayMember = "roomID";
                    cbxRoom.ValueMember = "roomID";
                }

            }
            catch (OleDbException ex)
            {
                Console.WriteLine("Error: BookingForm _ loadRoom() _ OleDbException: " + ex.Message);
                if (ex.Message.Contains("'RoomType' is already opened exclusively by another user"))
                {
                    MessageBox.Show("Vui lòng tắt bảng RoomType trên MS Access trước khi truy cập");
                }
            }
            finally
            {
                if (con != null)
                {
                    con.Close();

                }
            }
        }
        private bool insertBooking()
        {
            OleDbConnection con = null;

            String bookingID = Guid.NewGuid().ToString();
            String name = txtName.Text;
            String ID = txtIdentification.Text;
            String phone = txtPhone.Text;
            DateTime chkIn = dateTimePickerCheckIn.Value;
            DateTime chkOut = dateTimePickerCheckOut.Value;
            String Room;
            double price = Convert.ToDouble(txtPrice.Text);
            if (name == "")
            {
                MessageBox.Show("Vui lòng nhập họ tên!");
                txtName.Focus();
            }
            else if (ID == "")
            {
                MessageBox.Show("Vui lòng nhập CMND!");
                txtIdentification.Focus();
            }
            else if (txtIdentification.Text.Length <= 0 || txtIdentification.Text.Length > 12)
            {
                MessageBox.Show("Vui lòng nhập CMND trong khoảng 0-12 ký tự số!");
                txtIdentification.Focus();
            }
            else if (phone == "")
            {
                MessageBox.Show("Vui lòng nhập SĐT!");
                txtPhone.Focus();
            }
            else if (txtPhone.Text.Length <= 0 || txtPhone.Text.Length > 15)
            {
                MessageBox.Show("Vui lòng nhập SĐT trong khoảng 0-15 ký tự số!");
                txtIdentification.Focus();
            }
            else if (cbxRoom.SelectedValue == null)
            {
                MessageBox.Show("Đã hết phòng loại " + cbxRoomType.SelectedValue.ToString() + "!");
                return false;
            }
            else if (price == 0)
            {
                MessageBox.Show("Ngày trả phòng phải đặt sau ngày nhận phòng!!!");
                dateTimePickerCheckOut.Focus();
            }
            else
            {
                Room = cbxRoom.SelectedValue.ToString();
                try
                {
                    con = DBHelper.OpenAccessConnection();
                    if (con != null)
                    {
                        String sql = "INSERT INTO CUSTOMER VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?)";
                        OleDbCommand cmd = new OleDbCommand();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = sql;

                        cmd.Parameters.Add("@cusID", OleDbType.VarChar).Value = bookingID;
                        cmd.Parameters.Add("@cusName", OleDbType.VarChar).Value = name;
                        cmd.Parameters.Add("@Identification", OleDbType.VarChar).Value = ID;
                        cmd.Parameters.Add("@phoneNumb", OleDbType.VarChar).Value = phone;
                        cmd.Parameters.Add("@checkInDate", OleDbType.Date).Value = chkIn;
                        cmd.Parameters.Add("@checkOutDate", OleDbType.Date).Value = chkOut;
                        cmd.Parameters.Add("@roomID", OleDbType.Integer).Value = Convert.ToInt32(Room);
                        cmd.Parameters.Add("@price", OleDbType.Double).Value = Math.Round(price);
                        cmd.Parameters.Add("@paymentStatus", OleDbType.Boolean).Value = false;
                        if (cmd.ExecuteNonQuery() != 0)
                        {
                            return true;
                        }
                    }
                }
                catch (OleDbException ex)
                {
                    Console.WriteLine("OleDbException _ BookingForm _ insertBooking(): " + ex.Message);
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

        private void updateStatus()
        {
            OleDbConnection con = null;
            String Room = cbxRoom.SelectedValue.ToString();
            try
            {
                con = DBHelper.OpenAccessConnection();
                if (con != null)
                {
                    String sql = "UPDATE Room " +
                        "SET Available= No WHERE roomID= ?";
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;

                    cmd.Parameters.Add("@roomID", OleDbType.Integer).Value = Convert.ToInt32(Room);
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        return;
                    }
                }
            }
            catch (OleDbException ex)
            {
                Console.WriteLine("OleDbException _ BookingForm _ updateStatus(): " + ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            bool check = insertBooking();
            if (check)
            {
                updateStatus();
                Form form = (Form)Activator.CreateInstance(Type.GetType("MinhThuHotel.BookingConfirmForm"), new object[] { });
                form.ShowDialog();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtIdentification.Text = "";
            txtPhone.Text = "";
            txtName.Focus();
        }

        private void cbxRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.priceChange();
        }

        private void dateTimePickerCheckOut_ValueChanged(object sender, EventArgs e)
        {
            this.priceChange();
        }

        private void priceChange()
        {
            DataTable roomTable = new DataTable();

            DateTime chkIn = dateTimePickerCheckIn.Value;
            DateTime chkOut = dateTimePickerCheckOut.Value;
            double price;

            OleDbConnection con = null;
            try
            {
                con = DBHelper.OpenAccessConnection();
                if (con != null)
                {
                    String sql = "SELECT roomID FROM Room WHERE RoomType= '" + cbxRoomType.SelectedValue.ToString() + "' AND Available= Yes";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(sql, con);
                    adapter.Fill(roomTable);

                    cbxRoom.DataSource = roomTable;
                    cbxRoom.DisplayMember = "roomID";
                    cbxRoom.ValueMember = "roomID";

                    String sql2 = "SELECT price FROM RoomType WHERE ID = '" + cbxRoomType.SelectedValue.ToString() + "'";
                    OleDbCommand cmd = new OleDbCommand(sql2, con);
                    object result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        txtPrice.Text = "";
                    }
                    else
                    {
                        price = Convert.ToDouble(result.ToString());
                        int daytotal = (int)((chkOut - chkIn).TotalDays) + 1;
                        txtPrice.Text = (daytotal * price).ToString();
                    }
                }

            }
            catch (OleDbException ex)
            {
                Console.WriteLine("Error: BookingForm _ loadRoom() _ OleDbException: " + ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void dateTimePickerCheckIn_ValueChanged(object sender, EventArgs e)
        {
            this.priceChange();
        }

        private void txtIdentification_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
