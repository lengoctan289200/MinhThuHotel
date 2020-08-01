using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinhThuHotel.Data
{
    class Bill
    {
        protected string billID;
        protected string cusID;
        protected DateTime checkInDate;
        protected DateTime checkOutDate;
        protected double total;
        protected double cusMoney;
        protected double change;        

        public string BillID { get { return billID; } set { billID = value; } }
        public string CusID { get { return cusID; } set { cusID = value; } }
        public DateTime CheckInDate { get { return checkInDate; } set { checkInDate = value; } }
        public DateTime CheckOutDate { get { return checkOutDate; } set { checkOutDate = value; } }
        public double Total { get { return total; } set { total = value; } }
        public double CusMoney { get { return cusMoney; } set { cusMoney = value; } }
        public double Change { get { return change; } set { change = value; } }

        public Bill()
        {

        }

        public Bill(string BillID, string CusID, DateTime CheckInDate, DateTime CheckOutDate, double Total, double CusMoney, double Change)
        {
            billID = BillID;
            cusID = CusID;
            checkInDate = CheckInDate;
            checkOutDate = CheckOutDate;
            total = Total;
            cusMoney = CusMoney;
            change = Change;
        }
    }
}
