using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinhThuHotel.Data
{
    class Services
    {
        protected int id;
        protected string serviceName;
        protected string serviceType;
        protected double price;

        public int ID { get { return id; } set { id = value; } }
        public string ServiceName { get { return serviceName; } set { serviceName = value; } }
        public string ServiceType { get { return serviceType; } set { serviceType = value; } }
        public double Price { get { return price; } set { price = value; } }

        public Services()
        {

        }

        public Services(int ID, string ServiceName, string serviceType, double Price)
        {
            id = ID;
            serviceName = ServiceName;
            serviceType = ServiceType;
            price = Price;
        }
    }
}
