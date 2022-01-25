using System;
using System.IO;
using BE;
namespace DAL
{

    public static class Cloning
    {
        public static HostingUnit Clone(this HostingUnit original)
        {
            HostingUnit target = new HostingUnit();
            target.Diary = original.Diary.Clone() as bool[,];
            target.HostingUnitKey = original.HostingUnitKey;
            target.Owner.FamilyName = original.Owner.FamilyName;
            target.Owner.FhoneNumber = original.Owner.FhoneNumber;
            target.Owner.BankBranchDetails.BankNumber = original.Owner.BankBranchDetails.BankNumber;
            target.Owner.BankBranchDetails.BankBranchKey = original.Owner.BankBranchDetails.BankBranchKey;
            target.Owner.BankBranchDetails.BankName = original.Owner.BankBranchDetails.BankName;
            target.Owner.BankBranchDetails.BranchAddress = original.Owner.BankBranchDetails.BranchAddress;
            target.Owner.BankBranchDetails.BranchCity = original.Owner.BankBranchDetails.BranchCity;
            target.Owner.BankBranchDetails.BranchNumber = original.Owner.BankBranchDetails.BranchNumber;
            target.Owner.BankAccountNumber = original.Owner.BankAccountNumber;
            target.Owner.HostKey = original.Owner.HostKey;
            target.Owner.MailAddress = original.Owner.MailAddress;
            target.Owner.PrivateName = original.Owner.PrivateName;
            target.HostingUnitName = original.HostingUnitName;
            target.areaHostingUnit = original.areaHostingUnit;
            target.poolHostingUnit = original.poolHostingUnit;
            target.jacuzziHostingUnit = original.jacuzziHostingUnit;
            target.gardenHostingUnit = original.gardenHostingUnit;
            target.childrensAttractionsHostingUnit = original.childrensAttractionsHostingUnit;
            target.typeHostingUnit = original.typeHostingUnit;
            return target;
        }
        public static BankBranch Clone(this BankBranch original)
        {
            BankBranch target = new BankBranch();
            target.BankBranchKey = original.BankBranchKey;
            target.BankName = original.BankName;
            target.BankNumber = original.BankNumber;
            target.BranchAddress = original.BranchAddress;
            target.BranchCity = original.BranchCity;
            target.BranchNumber = original.BranchNumber;
            return target;
        }
        public static GuestRequest Clone(this GuestRequest original)
        {
            GuestRequest target = new GuestRequest();
            target.Adults = original.Adults;
            target.area = original.area;
            target.Children = original.Children;
            target.childrensAttractions = original.childrensAttractions;
            var v = new DateTime (original.EntryDate.ToBinary());
            target.EntryDate = v;
            target.CollectionClearance = original.CollectionClearance;
            target.FamilyName = original.FamilyName;
            target.garden = original.garden;
            target.GuestRequestKey = original.GuestRequestKey;
            target.jacuzzi = original.jacuzzi;
            target.MailAddress = original.MailAddress;
            target.pool = original.pool;
            target.PrivateName = original.PrivateName;
            v= new DateTime(original.RegistrationDate.ToBinary());
            target.RegistrationDate = v;
            v = new DateTime(original.ReleaseDate.ToBinary());
            target.ReleaseDate = v;
            target.statusGuestRequest = original.statusGuestRequest;
            target.SubArea = original.SubArea;
            target.type = original.type;
            return target;
        }
        public static Host Clone(this Host original)
        {
            Host target = new Host();
            target.BankAccountNumber = original.BankAccountNumber;
            target.BankBranchDetails = original.BankBranchDetails;
            target.FamilyName = original.FamilyName;
            target.FhoneNumber = original.FhoneNumber;
            target.HostKey = original.HostKey;
            target.MailAddress = original.MailAddress;
            target.PrivateName = original.PrivateName;
            return target;
        }
        public static Order Clone(this Order original)
        {
            Order target = new Order();
            target.CreateDate = original.CreateDate;
            target.GuestRequestKey = original.GuestRequestKey;
            target.HostingUnitKey = original.HostingUnitKey;
            target.OrderDate = original.OrderDate;
            target.OrderKey = original.OrderKey;
            target.statusOrder = original.statusOrder;
            return target;
        }
    }
}
