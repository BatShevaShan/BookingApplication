using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace BE
{
    public class Order
    {
        public long GuestRequestKey { set; get; }
        public long HostingUnitKey { set; get; }
        public long OrderKey { set; get; }
        public DateTime CreateDate { set; get; }
        public DateTime OrderDate { set; get; }
        public StatusOrder statusOrder { set; get; }
        public override string ToString()
        {//the tostring enturns the variables and their data
            return "Order [HostingUnitKey-" + HostingUnitKey + "OrderKey-" + OrderKey + "GuestRequestKey-" + GuestRequestKey + "CreateDate-" + CreateDate + ", OrderDate-" + OrderDate + ", statusOrder-" + statusOrder + "]";
        }
    }
}

