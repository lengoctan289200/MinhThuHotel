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

                    String sql2 = "SELECT roomID FROM Room WHERE RoomType= '" + cbxRoomType.SelectedValue.ToString() + "'";
                    OleDbDataAdapter adapter2 = new OleDbDataAdapter(sql2, con);
                    adapter2.Fill(roomTable);

                    cbxRoom.DataSource = roomTable;
                    cbxRoom.DisplayMember = "roomID";
                    cbxRoom.ValueMember = "roomID";
                }

            }
            catch (OleDbException ex)
            {
                Console.WriteLine("Error: BookingForm _ loadRoom() _ OleDbException: " + ex.Message);
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
            String Room = cbxRoom.SelectedValue.ToString();
            //try
            //{
            con = DBHelper.OpenAccessConnection();
            if (con != null)
            {
                String sql = "INSERT INTO CUSTOMER VALUES(?, ?, ?, ?, ?, ?, ?, ?)";
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
                cmd.Parameters.Add("@paymentStatus", OleDbType.Boolean).Value = false;
                if (cmd.ExecuteNonQuery() != 0)
                {
                    return true; 
                }

            }
            return false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MenuForm mn = new MenuForm();
            mn.Show();
            this.Hide();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            bool check = insertBooking();
            if (check)
            {
                Close();
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
            DataTable roomTable = new DataTable();

            OleDbConnection con = null;
            try
            {
                con = DBHelper.OpenAccessConnection();
                if (con != null)
                {
                    String sql2 = "SELECT roomID FROM Room WHERE RoomType= '" + cbxRoomType.SelectedValue.ToString() + "'";
                    OleDbDataAdapter adapter2 = new OleDbDataAdapter(sql2, con);
                    adapter2.Fill(roomTable);

                    cbxRoom.DataSource = roomTable;
                    cbxRoom.DisplayMember = "roomID";
                    cbxRoom.ValueMember = "roomID";
                }

            }
            catch (OleDbException ex)
            {
                Console.WriteLine("Error: BookingForm _ loadRoom() _ OleDbException: " + ex.Message);
            }
        }
    }
}
