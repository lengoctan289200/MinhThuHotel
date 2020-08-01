using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace MinhThuHotel.Utils
{
    class DBHelper
    {
        public static OleDbConnection OpenAccessConnection()
        {
            try
            {
                OleDbConnection con = new OleDbConnection();
                String path = @"MinhThuHotelDB.accdb";
                String s = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + path;

                con.ConnectionString = s;
                con.Open();
                
                return con;
            }
            catch (OleDbException ex)
            {
                Console.WriteLine("Error: Something wrong in openConnection _ OleDbException: " + ex.Message);
            }
            return null;
        }
    }
}
