using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinhThuHotel.Data
{
    class Customer
    {
        protected string cusID;
        protected string cusName;
        protected string identification;
        protected string phoneNumb;
        protected DateTime checkInDate;
        protected DateTime checkOutDate;
        protected int roomID;
        protected bool paymentStatus;

        public string CusID { get { return cusID; } set { cusID = value; } }
        public string CusName { get { return cusName; } set { cusName = value; } }
        public string Identification { get { return identification; } set { identification = value; } }
        public string PhoneNumb { get { return phoneNumb; } set { phoneNumb = value; } }
        public DateTime CheckinDate { get { return checkInDate; } set { checkInDate = value; } }
        public DateTime CheckoutDate { get { return checkOutDate; } set { checkOutDate = value; } }
        public int RoomID { get { return roomID; } set { roomID = value; } }
        public bool PaymentStatus { get { return paymentStatus; } set { paymentStatus = value; } }

        public Customer()
        {

        }

        public Customer(string CusID, string CusName, string Identification, string PhoneNumb, DateTime CheckinDate, DateTime CheckoutDate, int RoomID, bool PaymentStatus)
        {
            cusID = CusID;
            cusName = CusName;
            identification = Identification;
            phoneNumb = PhoneNumb;
            checkInDate = CheckinDate;
            checkOutDate = CheckoutDate;
            roomID = RoomID;
            paymentStatus = PaymentStatus;
        }
    }
}
