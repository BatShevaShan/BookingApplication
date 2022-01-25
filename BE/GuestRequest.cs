using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace BE
{
    public class GuestRequest
    {//the values of the guest request 
        private long guestRequestKey;
        public long GuestRequestKey
        {
            get { return guestRequestKey; }
            set
            {
                guestRequestKey = value;
            }
        }
        private string privateName;
        public string PrivateName
        {
            get { return privateName; }
            set
            {
                Regex r = new Regex("^([^20]|[a-zA-Zא-ת]){2,35}$");
                if (!r.IsMatch(value))
                    throw new Exception("שם צריך להכיל 2-35 אותיות.");
                privateName = value;
            }
        }

        private string familyName;
        public string FamilyName
        {
            get { return familyName; }
            set
            {
                Regex r = new Regex("^([^20]|[a-zA-Zא-ת]){2,35}$");
                if (!r.IsMatch(value))
                    throw new Exception("שם צריך להכיל 2-35 אותיות.");
                familyName = value;
            }
        }
        private string mailAddress;
        public string MailAddress
        {
            get { return mailAddress; }
            set
            {
                try
                {
                    MailAddress m = new MailAddress(value);
                }
                catch (Exception)
                {
                    throw new Exception("the mail address is not ok");
                }
                mailAddress = value;
            }
        }
        
        public string SubArea { set; get; }
        public DateTime RegistrationDate;
        public DateTime EntryDate;
        public DateTime ReleaseDate;
        private int adults;
        public int Adults
        {
            get { return adults; }
            set
            {
                if (value < 0)
                    throw new Exception("מספר מבוגרים לא יכול להיות שלילי.");
                adults = value;
            }
        }
        
        private int children;
        public int Children
        {
            get { return children; }
            set
            {
                if (value < 0)
                    throw new Exception("מספר ילדים לא יכול להיות שלילי.");
                children = value;
            }
        }
        
        public Area area { set; get; }
        public Request pool { set; get; }
        public Request jacuzzi { set; get; }
        public Request garden { set; get; }
        public Request childrensAttractions { set; get; }
        public bool CollectionClearance { set; get; }
        public StatusGuestRequest statusGuestRequest { set; get; }
        public TypeOfUnit type { set; get; }

        public override string ToString()
        {//the tostring enturns the variables and their data
            return "GuestRequest [GuestRequestKey-" + GuestRequestKey + "PrivateName-" + PrivateName + ",FamilyName-" + FamilyName + ",MailAddress-" + MailAddress + ",SubArea-" + SubArea + ",RegistrationDate-" + RegistrationDate + ",EntryDate-" + EntryDate + ",ReleaseDate-" + ReleaseDate + ",Adults-" + Adults + ",Children-" + Children + ",area-" + area + ",pool-" + pool + ",jacuzzi-" + jacuzzi + ",garden-" + garden + ",childrensAttractions-" + childrensAttractions + "type-" + type + "statusGuestRequest-" + statusGuestRequest + ",CollectionClearance"+ CollectionClearance + "]";
        }

    }
}