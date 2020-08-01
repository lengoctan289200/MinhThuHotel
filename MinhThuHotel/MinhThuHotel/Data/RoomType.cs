using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinhThuHotel.Data
{
    class RoomType
    {
        protected string id;
        protected string roomType;
        protected double price;

        public string ID { get { return id; } set { id = value; } }
        public string Type { get { return roomType; } set { roomType = value; } }
        public double Price { get { return price; } set { price = value; } }

        public RoomType()
        {

        }

        public RoomType(string ID, string RoomType, double Price)
        {
            id = ID;
            roomType = RoomType;
            price = Price;
        }
    }
}
