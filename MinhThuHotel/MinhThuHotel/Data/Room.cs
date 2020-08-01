using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinhThuHotel.Data
{
    class Room
    {
        protected int roomID;
        protected bool available;
        protected string roomType;

        public int RoomID { get { return roomID; } set { roomID = value; } }
        public bool Available { get { return available; } set { available = value; } }
        public string RoomType { get { return roomType; } set { roomType = value; } }

        public Room()
        {

        }

        public Room(int RoomID, bool Available, String RoomType)
        {
            roomID = RoomID;
            available = Available;
            roomType = RoomType;
        }
    }
}
