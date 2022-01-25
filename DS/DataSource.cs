using System;
using System.Collections.Generic;
using System.Linq;
using BE;
namespace DS
{
    public class DataSource
    {
        public static List<GuestRequest> guestRequest = new List<GuestRequest>();
        public static List<HostingUnit> hostingUnit = new List<HostingUnit>();
        public static List<Order> order = new List<Order>();
        public override string ToString()
        {//the tostring enturns the variables and their data
            return "DataSource [guestRequest" + guestRequest + ",hostingUnit" + hostingUnit + ",order" + order + "]";
        }

    }
}
