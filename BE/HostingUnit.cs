using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace BE
{
    public class HostingUnit
    {

        public long HostingUnitKey { set; get; }
        public Host Owner;
        private string hostingUnitName;
        public string HostingUnitName
        {
            get { return hostingUnitName; }
            set
            {
                Regex r = new Regex("^([^20]|[a-zA-Zא-ת]){2,35}$");
                if (!r.IsMatch(value))
                    throw new Exception("שם צריך להכיל 2-35 אותיות.");
                hostingUnitName = value;
            }
        }
        public bool[,] Diary = new bool[12, 31];
        public Area areaHostingUnit { set; get; }
        public bool poolHostingUnit { set; get; }
        public bool jacuzziHostingUnit { set; get; }
        public bool gardenHostingUnit { set; get; }
        public bool childrensAttractionsHostingUnit { set; get; }
        public TypeOfUnit typeHostingUnit { set; get; }
        public override string ToString()
        {//the tostring enturns the variables and their data
            return("HostingUnit -Owner-" + Owner.ToString() + ",Diary-"+ Diary + ", HostingUnitName-" + HostingUnitName + ",areaHostingUnit-" + areaHostingUnit+ ",poolHostingUnit-"+ poolHostingUnit+ ",jacuzziHostingUnit-"+ jacuzziHostingUnit+ ",gardenHostingUnit-"+ gardenHostingUnit+ ",childrensAttractionsHostingUnit-"+ childrensAttractionsHostingUnit+ ",typeHostingUnit-" +typeHostingUnit);
        }
    }

}

