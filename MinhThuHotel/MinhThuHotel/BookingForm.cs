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
        int count = 1;
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

                //cmd.Parameters.AddWithValue("@cusID", count);
                //cmd.Parameters.AddWithValue("@cusName", name);
                //cmd.Parameters.AddWithValue("@Identification", ID);
                //cmd.Parameters.AddWithValue("@phoneNumb", phone);
                //cmd.Parameters.AddWithValue("@checkInDate", chkIn);
                //cmd.Parameters.AddWithValue("@checkOutDate", chkOut);
                //cmd.Parameters.AddWithValue("@roomID", Room);
                //cmd.Parameters.AddWithValue("@paymentStatus", false);

                cmd.Parameters.Add("@cusID", OleDbType.Integer).Value = 1;
                cmd.Parameters.Add("@cusName", OleDbType.VarChar).Value = "1"/*name*/;
                cmd.Parameters.Add("@Identification", OleDbType.VarChar).Value = "1"/*ID*/;
                cmd.Parameters.Add("@phoneNumb", OleDbType.VarChar).Value = "1"/*phone*/;
                cmd.Parameters.Add("@checkInDate", OleDbType.Date).Value = chkIn;
                cmd.Parameters.Add("@checkOutDate", OleDbType.Date).Value = chkOut;
                cmd.Parameters.Add("@roomID", OleDbType.Integer).Value = Convert.ToInt32(Room);
                cmd.Parameters.Add("@paymentStatus", OleDbType.Boolean).Value = false;
                if (cmd.ExecuteNonQuery() != 0)
                {
                    count++;
                    return true;
                }

            }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MenuForm mn = new MenuForm();
            mn.Show();
            this.Hide();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            BookingConfirmForm confirmForm = new BookingConfirmForm();
            confirmForm.Show();
            this.Hide();
        }
    }
}
