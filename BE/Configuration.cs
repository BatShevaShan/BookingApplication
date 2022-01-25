using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BE
{
    public class Configuration
    {// the statics numbers of the keys
        public static long staticGuestRequestKey;
        public static long staticBankNumber;
        public static long staticHostKey;
        public static long staticHostingUnitKey;
        public static long staticOrderKey;
        public static long free { set; get; }
        public static int fee { set; get; }
    }
}


