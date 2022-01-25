using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using BE;

namespace PL
{
    class Program
    {
        static void init()
        {
            #region initializGustList 
            GuestRequest gust = new GuestRequest()
            {
                EntryDate = DateTime.Today,
                Adults = 5,
                area = Area.All,
                Children = 2,
                childrensAttractions = Request.Necessary,
                FamilyName = "alon",
                garden = Request.Necessary,
                GuestRequestKey = 10000,
                jacuzzi = Request.Necessary,
                MailAddress = "shira@gmail.com",
                pool = Request.NotInterested,
                PrivateName = "shira",
                ReleaseDate = DateTime.Now.AddDays(5),
                RegistrationDate = DateTime.Today.AddDays(-5),
                statusGuestRequest = StatusGuestRequest.CloseThroughTheSite,
                SubArea = "shalom",
                type = TypeOfUnit.Hotel
            }; Configuration.staticGuestRequestKey++;

            #endregion

            #region initializUnitList
            HostingUnit host = new HostingUnit()
            {
                Diary = { },
                HostingUnitKey = 100000,
                HostingUnitName = "dekel",
                Owner = new Host
                {
                    BankAccountNumber = 124,
                    BankBranchDetails = new BankBranch
                    {
                        BankBranchKey = 1999,
                        BankName = "hello",
                        BankNumber = 133,
                        BranchAddress = "yasmin",
                        BranchCity = "keryat8",
                        BranchNumber = 80
                    },
                    CollectionClearance = false,
                    FamilyName = "shalom",
                    FhoneNumber = 0532432312,
                    HostKey = 68888,
                    MailAddress = "bat7@gmail.com",
                    PrivateName = "adi"
                }
            }; Configuration.staticHostingUnitKey++;

            #endregion

            #region initializOrderList
            Order order = new Order()
            {
                CollectionClearance = false,
                CreateDate = DateTime.Today,
                GuestRequestKey = 10808080,
                HostingUnitKey = 989898,
                OrderDate = DateTime.Today.AddDays(6),
                OrderKey = 10000,
                statusOrder = StatusOrder.ClosesNoResponse
            };

            #endregion
            Configuration.staticOrderKey++;
            PL.test.bl.addHostingUnit(host);
            PL.test.bl.addGuestRequest(gust);
            PL.test.bl.addOrder(order);
            PL.test.bl.updateOrder(StatusOrder.NotTreated, order.OrderKey);
            PL.test.bl.updateOrder(StatusOrder.MailHasBeenSent, 123);
            PL.test.bl.updateOrder(StatusOrder.ClosesWithResponse, order.OrderKey);
            PL.test.bl.updateOrder(StatusOrder.ClosesNoResponse, order.OrderKey);
            var OL = PL.test.bl.AllOrder();
            foreach (var item in OL)
            {
                Console.WriteLine(item);
            }
            PL.test.bl.removeHostingUnit(host.HostingUnitKey);
            var HL = PL.test.bl.AllHostingUnit();
            HL.ToList();
            foreach (var item in HL)
            {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            init();
        }
       
    }

}