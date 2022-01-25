using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using BE;
using BL;
namespace UI
{
    public class test1
    {
        public void addOrder(Order o)
        {
            try { bl.addOrder(o); }
            catch (Exception josh)
            { Console.WriteLine(josh.Message); }

        }
        public void addGuestRequest(GuestRequest g)
        {
            try { bl.addGuestRequest(g); }
            catch (Exception josh)
            { Console.WriteLine(josh.Message); }
        }
        public void updateOrder(StatusOrder stat, int num)
        {
            try { bl.updateOrder(stat, num); }
            catch (Exception josh)
            { Console.WriteLine(josh.HelpLink); }
        }

        public IEnumerable<Order> AllOrder()
        {
            return bl.AllOrder().ToList();
        }

        public void addHostingUnit(HostingUnit host)
        {
            try { bl.addHostingUnit(host); }
            catch (Exception josh)
            { Console.WriteLine(josh.Message); }
        }

        public void removeHostingUnit(long num)
        {
            try
            { bl.removeHostingUnit(num); }
            catch (Exception josh)
            { Console.WriteLine(josh.Message); }
        }

        public IEnumerable<HostingUnit> AllHostingUnit()
        {
            return bl.AllHostingUnit().ToList();
        }

        bool chekOptions(Request wanted, bool thereIs)
        {
            if (wanted == Request.Necessary && thereIs == false)
                return false;
            if (wanted == Request.NotInterested && thereIs == true)
                return false;
            return true;
        }

        bool funcCheckHostUnit(GuestRequest Gu, HostingUnit Ho)
        {
            //if (!bl.checkDiary(Gu.EntryDate, Gu.ReleaseDate, Ho))
            //    return false;
            if (Gu.area != Ho.areaHostingUnit)
                return false;
            if (!chekOptions(Gu.pool, Ho.poolHostingUnit))
                return false;
            if (!chekOptions(Gu.jacuzzi, Ho.jacuzziHostingUnit))
                return false;
            if (!chekOptions(Gu.garden, Ho.gardenHostingUnit))
                return false;
            return true;
        }

        Request funcChoice()
        {
            int pick = 0;
            Console.WriteLine("enter 1 if Necessary, 2 if NotInterested, 3 if Possible");
            pick = int.Parse(Console.ReadLine());
            return (Request)pick;
        }
        BankBranch chooseBankBranch()
        {
            List<BankBranch> bbl;
            bbl = new List<BankBranch>()
            {
                new BankBranch()
                {
                    BankNumber=70,
                    BankName="bank hapoalim",
                    BranchAddress="canfey nesharim",
                    BranchNumber=123,
                    BranchCity="Jerusalem",
                },
                new BankBranch()
                {
                    BankNumber=70,
                    BankName="bank hapoalim",
                    BranchAddress="hamoshva",
                    BranchNumber=234,
                    BranchCity="Jerusalem",
                },
                new BankBranch()
                {
                    BankNumber=70,
                    BankName="bank hapoalim",
                    BranchAddress="pissgat zevaev",
                    BranchNumber=345,
                    BranchCity="Jerusalem",
                },
                new BankBranch()
                {
                    BankNumber=50,
                    BankName="mizrachi",
                    BranchAddress="kiryat moshe",
                    BranchNumber=567,
                    BranchCity="Jerusalem",
                },
                new BankBranch()
                {
                    BankNumber=50,
                    BankName="mizrachi",
                    BranchAddress="beyit hacrem",
                    BranchNumber=678,
                    BranchCity="Jerusalem",
                }
            };
            Random rand = new Random(DateTime.Now.Millisecond);
            int num = rand.Next(0, 5);
            return bbl[num];

        }
        bool transateStringToBool(string s)
        {
            if (s == "yes")
                return true;
            return false;
        }
        public static BL.IBL bl = FactoryBL.GetBL();
        public void UI()
        {
            int choice = 0;
            Console.WriteLine("different choices, pick what you want to do: ");
            Console.WriteLine("1: add a new request");
            Console.WriteLine("2: add a  new host and hosting unit");
            Console.WriteLine("3: update a request");
            Console.WriteLine("4: updte a hosting unit");
            Console.WriteLine("5: delete a hosting unit");
            Console.WriteLine("6: create an order");

            choice = int.Parse(Console.ReadLine());
            Console.WriteLine(choice);
            while (choice != 0)
            {
                switch (choice)
                {
                    case 1:
                        GuestRequest Gu = new GuestRequest();
                        Console.WriteLine("enter first name: ");
                        Gu.PrivateName = Console.ReadLine();
                        Console.WriteLine("enter famaly name: ");
                        Gu.FamilyName = Console.ReadLine();
                        Console.WriteLine("enter the type of vacation you want: ");
                        Console.WriteLine("1: Zimmer, 2: Hotel, 3: Camping");
                        int pick = int.Parse(Console.ReadLine());
                        Gu.type = (TypeOfUnit)pick;
                        Console.WriteLine("enter the area in Israel you want: ");
                        Console.WriteLine("1: North, 2: South, 3: Center, 4: Jerusalem");
                        pick = int.Parse(Console.ReadLine());
                        Gu.area = (Area)pick;
                        Console.WriteLine("enter number of adults vacationers ");
                        Gu.Adults = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter number of children vacationers ");
                        Gu.Children = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter entry date: ");
                        Gu.EntryDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("enter release date: ");
                        Gu.ReleaseDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("do you want a pool? ");
                        Gu.pool = funcChoice();
                        Console.WriteLine("do you want a jacuzzi? ");
                        Gu.jacuzzi = funcChoice();
                        Console.WriteLine("do you want a garden? ");
                        Gu.garden = funcChoice();
                        Console.WriteLine("enter e-mail adress: ");
                        Gu.MailAddress = Console.ReadLine();
                        Gu.GuestRequestKey = Configuration.staticGuestRequestKey;
                        Configuration.staticGuestRequestKey++;
                        try { bl.addGuestRequest(Gu); }
                        catch (Exception ex1)
                        { Console.WriteLine(ex1.Message); }
                        break;

                    case 2:
                        Host h = new Host();
                        h.HostKey = Configuration.staticGuestRequestKey++;
                        Console.WriteLine("enter first name");
                        h.PrivateName = Console.ReadLine();
                        Console.WriteLine("enter family name");
                        h.FamilyName = Console.ReadLine();
                        Console.WriteLine("enter bank account number name");
                        h.BankAccountNumber = Console.Read();
                        Console.WriteLine("enter phone number name");
                        h.FhoneNumber = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter mail adress name");
                        h.MailAddress = Console.ReadLine();
                        Console.WriteLine("are you have permission to acess the bank account");
                        
                        h.BankBranchDetails = chooseBankBranch();

                        HostingUnit u = new HostingUnit();
                        u.Owner = h;
                        Console.WriteLine("the hosting unit name");
                        u.HostingUnitName = Console.ReadLine();
                        Console.WriteLine("1:North, 2:South, 3:Center, 4:Jerusalem");
                        int p = int.Parse(Console.ReadLine());
                        u.areaHostingUnit = (Area)p;
                        Console.WriteLine("do you have a pool? ");
                        u.poolHostingUnit = transateStringToBool(Console.ReadLine());
                        Console.WriteLine("do you have childrens attractions?");
                        u.childrensAttractionsHostingUnit = transateStringToBool(Console.ReadLine());
                        Console.WriteLine("do you have a jacuzzi? ");
                        u.jacuzziHostingUnit = transateStringToBool(Console.ReadLine());
                        Console.WriteLine("do you have a garden? ");
                        u.gardenHostingUnit = transateStringToBool(Console.ReadLine());
                        u.HostingUnitKey = Configuration.staticHostingUnitKey;
                        Configuration.staticHostingUnitKey++;
                        try { bl.addHostingUnit(u); }
                        catch (Exception ex2)
                        { Console.WriteLine(ex2.Message); }
                        break;
                    case 3:
                        GuestRequest GuUpdate = new GuestRequest();
                        Console.WriteLine("enter guest request key: ");
                        GuUpdate.GuestRequestKey = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter first name: ");
                        GuUpdate.PrivateName = Console.ReadLine();
                        Console.WriteLine("enter famaly name: ");
                        GuUpdate.FamilyName = Console.ReadLine();
                        Console.WriteLine("enter the type of vacation you want: ");
                        Console.WriteLine("1: Zimmer, 2: HostingApartment, 3: RoomInHotel, 4: Tent");
                        pick = int.Parse(Console.ReadLine());
                        GuUpdate.type = (TypeOfUnit)pick;
                        Console.WriteLine("enter the area in Israel you want: ");
                        Console.WriteLine("1: North, 2: South, 3: Center, 4: Jerusalem");
                        pick = int.Parse(Console.ReadLine());
                        GuUpdate.area = (Area)pick;
                        Console.WriteLine("enter number of adults vacationers ");
                        GuUpdate.Adults = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter number of children vacationers ");
                        GuUpdate.Children = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter entry date: ");
                        GuUpdate.EntryDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("enter release date: ");
                        GuUpdate.ReleaseDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("do you want a pool? ");
                        GuUpdate.pool = funcChoice();
                        Console.WriteLine("do you want childrens attractions?");
                        GuUpdate.childrensAttractions = funcChoice();
                        Console.WriteLine("do you want a jacuzzi? ");
                        GuUpdate.jacuzzi = funcChoice();
                        Console.WriteLine("do you want a garden? ");
                        GuUpdate.garden = funcChoice();
                        Console.WriteLine("enter e-mail adress: ");
                        GuUpdate.MailAddress = Console.ReadLine();
                        try { bl.updateGuestRequest(GuUpdate.statusGuestRequest, GuUpdate.GuestRequestKey); }
                        catch (Exception ex3)
                        { Console.WriteLine(ex3.Message); }
                        break;
                    case 4:
                        Host ho = new Host();
                        Console.WriteLine("enter the hosts key");
                        ho.HostKey = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter first name");
                        ho.PrivateName = Console.ReadLine();
                        Console.WriteLine("enter family name");
                        ho.FamilyName = Console.ReadLine();
                        Console.WriteLine("enter bank account number name");
                        ho.BankAccountNumber = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter phone number name");
                        ho.FhoneNumber = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter mail adress name");
                        ho.MailAddress = Console.ReadLine();
                        Console.WriteLine("do you give permission to acess the bank account");

                        ho.BankBranchDetails = chooseBankBranch();

                        HostingUnit unit = new HostingUnit();
                        Console.WriteLine("enter the hosting units key: ");
                        unit.HostingUnitKey = Console.Read();
                        unit.Owner = ho;
                        Console.WriteLine("the hosting unit name");
                        unit.HostingUnitName = Console.ReadLine();
                        Console.WriteLine("1:North, 2:South, 3:Center, 4:Jerusalem");
                        int p1 = int.Parse(Console.ReadLine());
                        unit.areaHostingUnit = (Area)p1;
                        Console.WriteLine("do you have a pool? ");
                        unit.poolHostingUnit = transateStringToBool(Console.ReadLine());
                        Console.WriteLine("do you have childrens attractions?");
                        unit.childrensAttractionsHostingUnit = transateStringToBool(Console.ReadLine());
                        Console.WriteLine("do you have a jacuzzi? ");
                        unit.jacuzziHostingUnit = transateStringToBool(Console.ReadLine());
                        Console.WriteLine("do you have a garden? ");
                        unit.gardenHostingUnit = transateStringToBool(Console.ReadLine());
                        unit.HostingUnitKey = Configuration.staticHostingUnitKey;
                        try { bl.updategHostingUnit(unit); }
                        catch (Exception ex4)
                        { Console.WriteLine(ex4.Message); }
                        break;
                    case 5:
                        Console.WriteLine("enter the hosting unit key unit");
                        int num1 = int.Parse(Console.ReadLine());
                        try { bl.removeHostingUnit(num1); }
                        catch (Exception ex5)
                        { Console.WriteLine(ex5.Source); }
                        break;
                    case 6:
                        Console.WriteLine("enter the guest request number: ");
                        int num = int.Parse(Console.ReadLine());
                        GuestRequest gu = bl.getGuestRequest(num);
                        int i = 0;
                        bool flag = true;
                        Configuration.staticOrderKey++;
                        while (flag && i < bl.AllHostingUnit().ToList().Count)
                        {
                            flag = false;
                            try
                            {
                                if (funcCheckHostUnit(gu, bl.AllHostingUnit().ToList()[i]))
                                {
                                    Order or = new Order();
                                    or.GuestRequestKey = gu.GuestRequestKey;
                                    or.HostingUnitKey = bl.AllHostingUnit().ToList()[i].HostingUnitKey;
                                    or.OrderDate = DateTime.Now;
                                    or.OrderKey = Configuration.staticOrderKey;
                                    or.statusOrder = StatusOrder.NotTreated;
                                    bl.addOrder(or);
                                }
                            }
                            catch
                            {
                                i++;
                                flag = true;
                            }
                        }
                        if (i == bl.AllHostingUnit().ToList().Count)
                        {
                            Configuration.staticOrderKey--;
                            Console.WriteLine("no hosting unit fits your requirement, no order built");
                        }
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
                Console.WriteLine("Enter a new choice: ");
                choice = int.Parse(Console.ReadLine());
            }

        }
    }
}
