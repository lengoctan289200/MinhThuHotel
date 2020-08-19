using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinhThuHotel.Data
{
    public class Customer
    {
        public String cusID { get; set; }
        public String cusName { get; set; }
        public String identification { get; set; }
        public String phoneNumb { get; set; }
        public DateTime checkInDate { get; set; }
        public DateTime checkOutDate { get; set; }
        public int roomID { get; set; }
        public double price { get; set; }
        public bool paymentStatus { get; set; }

        public Customer()
        {

        }

        public Customer(string CusID, string CusName, string Identification, string PhoneNumb, DateTime CheckinDate, DateTime CheckoutDate, int RoomID, double Price, bool PaymentStatus)
        {
            cusID = CusID;
            cusName = CusName;
            identification = Identification;
            phoneNumb = PhoneNumb;
            checkInDate = CheckinDate;
            checkOutDate = CheckoutDate;
            roomID = RoomID;
            price = Price;
            paymentStatus = PaymentStatus;
        }
    }
}
