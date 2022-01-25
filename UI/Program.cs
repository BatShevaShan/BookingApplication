using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using BE;

namespace UI
{
    class Program
    {
        static void init()
        {
            #region initializGustList 
            GuestRequest gust = new GuestRequest()
            {
                EntryDate = DateTime.Parse("04/02/2021"),
                CollectionClearance = false,
                Adults = 5,
                area = Area.North,
                Children = 2,
                childrensAttractions = Request.Necessary,
                FamilyName = "alon",
                garden = Request.Necessary,
                GuestRequestKey = Configuration.staticGuestRequestKey,
                jacuzzi = Request.Necessary,
                MailAddress = "shira@gmail.com",
                pool = Request.NotInterested,
                PrivateName = "tal",
                ReleaseDate = DateTime.Parse("06/02/2021"),
                RegistrationDate =DateTime.Parse("06/03/2021"),
                statusGuestRequest = StatusGuestRequest.Open,
                SubArea = "shalom",
                type = TypeOfUnit.Hotel,
            }; 

            #endregion

            #region initializUnitList
            HostingUnit host = new HostingUnit()
            {
                HostingUnitKey = Configuration.staticHostingUnitKey,
                HostingUnitName = "dekel",
                poolHostingUnit = true,
                gardenHostingUnit = true,
                jacuzziHostingUnit = false,
                childrensAttractionsHostingUnit = false,
                areaHostingUnit = Area.North,
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
                    
                    FamilyName = "shalom",
                    FhoneNumber = 0532432312,
                    HostKey = 68888,
                    MailAddress = "bat7@gmail.com",
                    PrivateName = "shani"
                }
            };

            #endregion

            #region initializOrderList
            Order order = new Order()
            {
                GuestRequestKey = gust.GuestRequestKey,
                HostingUnitKey = host.HostingUnitKey,
                OrderKey = Configuration.staticOrderKey,

                statusOrder = StatusOrder.NotTreated,

                CreateDate = DateTime.Parse("06/02/2021"),
                OrderDate =DateTime.Parse("06/02/2021"),
            };

            #endregion
            //UI.test1.bl.addHostingUnit(host);
            UI.test1.bl.addGuestRequest(gust);
            //UI.test1.bl.addOrder(order);
            //UI.test1.bl.updateOrder(StatusOrder.NotTreated, order.OrderKey);
            //UI.test1.bl.updateOrder(StatusOrder.MailHasBeenSent, order.OrderKey);
            //UI.test1.bl.updateOrder(StatusOrder.ClosesWithResponse, order.OrderKey);
            //UI.test1.bl.updateOrder(StatusOrder.ClosesNoResponse, order.OrderKey);
            //UI.test1.bl.updategHostingUnit(host);
            UI.test1.bl.updateGuestRequest(StatusGuestRequest.Open, gust.GuestRequestKey);
            // UI.test1.bl.removeGuestRequest(gust.GuestRequestKey);
            //UI.test1.bl.removeOrder(order.OrderKey);
            //UI.test1.bl.removeHostingUnit(host.HostingUnitKey);

            var OL = UI.test1.bl.AllOrder();
            OL.ToList();
            foreach (var item in OL)
            {
                Console.WriteLine(item);
            }

            //var HL = UI.test1.bl.AllHostingUnit();
            //HL.ToList();
            //foreach (var item in HL)
            //{
            //    Console.WriteLine(item);
            //}
            var gu = UI.test1.bl.AllGuestRequest();
            gu.ToList();
            foreach (var item in gu)
            {
                Console.WriteLine(item);
            }
        }
        static void Main(string[] args)
        {
            init();
            Console.ReadKey();
        }
    }
}