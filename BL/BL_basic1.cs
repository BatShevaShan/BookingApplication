using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using DAL;
namespace BL
{
    public delegate bool conditionDelegate(GuestRequest x);
    public class BL_basic1 : IBL
    {
        DAL.Idal dal;
        public void initialization()
        {
            #region initializGustList
            GuestRequest g = new GuestRequest
            {
                EntryDate = DateTime.Parse("04/02/2020"),
                Adults = 5,
                area = Area.All,
                CollectionClearance = false,
                Children = 2,
                childrensAttractions = Request.Necessary,
                FamilyName = "alon",
                garden = Request.Necessary,
                GuestRequestKey = Configuration.staticGuestRequestKey,
                jacuzzi = Request.Necessary,
                MailAddress = "shira@gmail.com",
                pool = Request.NotInterested,
                PrivateName = "shira",
                ReleaseDate = DateTime.Parse("04/03/2020"),
                RegistrationDate = DateTime.Parse("04/01/2020"),
                statusGuestRequest = StatusGuestRequest.CloseThroughTheSite,
                SubArea = "shalom",
                type = TypeOfUnit.Hotel,
            };

            GuestRequest g1 = new GuestRequest
            {
                EntryDate = DateTime.Parse("04/02/2020"),
                Adults = 5,
                area = Area.All,
                Children = 2,
                childrensAttractions = Request.Necessary,
                CollectionClearance = false,
                FamilyName = "alon",
                garden = Request.Necessary,
                GuestRequestKey = Configuration.staticGuestRequestKey,
                jacuzzi = Request.Necessary,
                MailAddress = "shira@gmail.com",
                pool = Request.NotInterested,
                PrivateName = "bat 7",
                ReleaseDate = DateTime.Parse("04/03/2020"),
                RegistrationDate = DateTime.Parse("04/01/2020"),
                statusGuestRequest = StatusGuestRequest.CloseThroughTheSite,
                SubArea = "shalom",
                type = TypeOfUnit.Hotel,
            };
            GuestRequest g2 = new GuestRequest
            {
                EntryDate = DateTime.Parse("04/02/2020"),
                Adults = 5,
                area = Area.All,
                Children = 2,
                childrensAttractions = Request.Necessary,
                FamilyName = "alon",
                CollectionClearance = false,
                garden = Request.Necessary,
                GuestRequestKey = Configuration.staticGuestRequestKey,
                jacuzzi = Request.Necessary,
                MailAddress = "shira@gmail.com",
                pool = Request.NotInterested,
                PrivateName = "shir",
                ReleaseDate = DateTime.Parse("04/03/2020"),
                RegistrationDate = DateTime.Parse("04/01/2020"),
                statusGuestRequest = StatusGuestRequest.CloseThroughTheSite,
                SubArea = "shalom",
                type = TypeOfUnit.Hotel,
            };
            try
            {
                this.addGuestRequest(g);
                
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
            try
            {
                this.addGuestRequest(g1);
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
            try
            {
                this.addGuestRequest(g2);
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
            #endregion

            #region initializUnitList
            HostingUnit h=new HostingUnit
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
                        BankBranchKey = 6666,
                        BankName = "hello",
                        BankNumber = Configuration.staticBankNumber,
                        BranchAddress = "yasmin",
                        BranchCity = "keryat8",
                        BranchNumber = 80
                    },
                    FamilyName = "shalom",
                    FhoneNumber = 0532432312,
                    HostKey = Configuration.staticHostKey,
                    MailAddress = "bat7@gmail.com",
                    PrivateName = "adi"
                }
            };
            HostingUnit h1 = new HostingUnit
            {
                HostingUnitKey = Configuration.staticHostingUnitKey,
                HostingUnitName = "shalom",
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
                        BankNumber = Configuration.staticBankNumber,
                        BranchAddress = "yasmin",
                        BranchCity = "keryat8",
                        BranchNumber = 80
                    },
                    FamilyName = "shalom",
                    FhoneNumber = 0532432312,
                    HostKey = Configuration.staticHostKey,
                    MailAddress = "bat7@gmail.com",
                    PrivateName = "shir"
                }
            };
            HostingUnit h2 = new HostingUnit
            {
                HostingUnitKey = Configuration.staticHostingUnitKey,
                HostingUnitName = "Yael",
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
                        BankNumber = Configuration.staticBankNumber,
                        BranchAddress = "yasmin",
                        BranchCity = "keryat8",
                        BranchNumber = 80
                    },
                    FamilyName = "shalom",
                    FhoneNumber = 0532432312,
                    HostKey = Configuration.staticHostKey,
                    MailAddress = "bat7@gmail.com",
                    PrivateName = "bat 7"
                }
            };
            try
            {
                this.addHostingUnit(h);
                this.addHostingUnit(h1);
                this.addHostingUnit(h2);
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
            #endregion

            #region initializOrderList
            Order o=new Order
            {
                CreateDate = DateTime.Today,
                GuestRequestKey = Configuration.staticGuestRequestKey,
                HostingUnitKey = Configuration.staticHostingUnitKey,
                OrderDate = DateTime.Parse("04/03/2020"),
                OrderKey = Configuration.staticOrderKey,
                statusOrder = StatusOrder.ClosesNoResponse

            };
            Order o1 = new Order
            {
                CreateDate = DateTime.Today,
                GuestRequestKey = Configuration.staticGuestRequestKey,
                HostingUnitKey = Configuration.staticHostingUnitKey,
                OrderDate = DateTime.Parse("04/03/2020"),
                OrderKey = Configuration.staticOrderKey,
                statusOrder = StatusOrder.ClosesNoResponse
            };
            Order o2 = new Order
            {
                CreateDate = DateTime.Today,
                GuestRequestKey = Configuration.staticGuestRequestKey,
                HostingUnitKey = Configuration.staticHostingUnitKey,
                OrderDate = DateTime.Parse("04/03/2020"),
                OrderKey = Configuration.staticOrderKey,
                statusOrder = StatusOrder.MailHasBeenSent
            };
            try
            {
                this.addOrder(o);
                this.addOrder(o1);
                this.addOrder(o2);
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
            #endregion
        }
        public BL_basic1()//c-tor
        {
            dal = DAL.FactoryDal.GetDal();
            initialization();

        }
        #region GuestRequest
        public void addGuestRequest(GuestRequest _guestRequest)
        {
            try
            {
                if (CheckGuestRequest(_guestRequest.GuestRequestKey))//check if the guest request is already exist
                    throw new Exception("דרישת האירוח כבר קיימת");
                if (_guestRequest.ReleaseDate < _guestRequest.EntryDate)//check if the release date is smaller than the entry date
                    throw new Exception("התאריכים אינם תקינים");
                _guestRequest.statusGuestRequest = StatusGuestRequest.Open;//change the status of the guest request
                dal.addGuestRequest(_guestRequest);//add the guest request
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }
        public GuestRequest getGuestRequest(long GuestRequestKey)
        {
            return dal.getGuestRequest(GuestRequestKey);//get the guest request by is key
        }
        public void removeGuestRequest(long GuestRequestKey)
        {
            try
            {
                dal.removeGuestRequest(GuestRequestKey);
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }
        public void updateGuestRequest(StatusGuestRequest statusGuestRequest, long key)
        {
            try
            {
                
                dal.updateGuestRequest(key);//update the guest request
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }
        public bool CheckGuestRequest(long key)
        {
            return dal.CheckGuestRequest(key);//check if the guest request is already exist
        }
        public void changeStatusGuestRequest(GuestRequest _guestRequest, StatusGuestRequest _statusGuestRequest)
        {//change the status of the guest request 
            try
            {
                dal.changeStatusGuestRequest(_guestRequest, _statusGuestRequest);
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }
        #endregion

        #region HostingUnit
        public void addHostingUnit(HostingUnit _hostingUnit)
        {
            try
            {
                if (CheckHostingUnit(_hostingUnit.HostingUnitKey))//check if the hosting unit is already exist
                    throw new Exception("יחידת האירוח כבר קיימת");
                dal.addHostingUnit(_hostingUnit);//add hosting unit
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }
        public HostingUnit getHostingUnit(long HostingUnitKey)
        {//get the hosting unit by is key
            return dal.getHostingUnit(HostingUnitKey);
        }
        public void updategHostingUnit(HostingUnit hostingUnit)
        {//update the hosting unit by the name anf the family name of the host
            try
            {
               dal.updategHostingUnit(hostingUnit);
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }
        public void removeHostingUnit(long HostingUnitKey)
        {
            try
            {
                foreach (var item in AllOrder())
                {//if the status of the hosting unit is not treatad, 
                    if (item.HostingUnitKey == HostingUnitKey && item.statusOrder == StatusOrder.NotTreated)
                        throw new Exception("לא ניתן למחוק יחידת אירוח כל עוד קיימת הצעה הקשורה אליה במצב פתוח");
                }
                dal.removeHostingUnit(HostingUnitKey);
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }
        public bool CheckHostingUnit(long key)
        {
            return dal.CheckHostingUnit(key);
        }
        #endregion

        #region Order
        public void addOrder(Order _order)
        {
            try
            {
                if (CheckOrder(_order.OrderKey))
                    throw new Exception("the order is already exit");
                long l = _order.GuestRequestKey;
                GuestRequest g = getGuestRequest(l);
                if (g.statusGuestRequest == StatusGuestRequest.Open)
                    _order.statusOrder = StatusOrder.NotTreated;
                else
                {
                  if (g.statusGuestRequest == StatusGuestRequest.CloseThroughTheSite)
                        _order.statusOrder = StatusOrder.MailHasBeenSent;
                }
                if (g == null)
                    throw new Exception("it's impassibale to add order when there is no gust request");
                long lh = _order.HostingUnitKey;
                HostingUnit h = getHostingUnit(lh);
                if (h == null)
                    throw new Exception("it's impassibale to add order when there is no hosting unit");
                _order.CreateDate = g.RegistrationDate;
                _order.OrderDate = DateTime.Today;
                DateTime d1 = g.EntryDate;
                DateTime d2 = g.ReleaseDate;
                while (h.Diary[d1.Month, d1.Day] != h.Diary[d2.Month, d2.Day])
                {
                    if (h.Diary[d1.Month, d1.Day] == false)
                        throw new Exception("the wanted date's is not free");
                    else
                        d1.AddDays(1);
                }
                if (_order.statusOrder == StatusOrder.MailHasBeenSent)
                {
                    if (getGuestRequest(_order.GuestRequestKey).CollectionClearance == false)
                        throw new Exception("You can not make a reservation, there is no signature on debit a bank account");
                }
                dal.addOrder(_order);
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }
        public Order getOrder(long key)
        {
            return dal.getOrder(key);
        }
        public void updateOrder(Order o)
        {
            try
            {
                
                dal.updateOrder(o);
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }
        public void removeOrder(long OrderKey)
        {
            try
            {
               
                dal.removeOrder(OrderKey);
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }

        public bool CheckOrder(long key)
        {
            return dal.CheckOrder(key);
        }
        public void changeStatusOrder(Order _order, StatusOrder _statusOrder)
        {
            try
            {
                dal.changeStatusOrder(_order, _statusOrder);
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }

        public void cancelCollectionClearance(long OrderKey)
        {
            try
            {
                foreach (var item in AllOrder())
                {
                    if (item.OrderKey == OrderKey && item.statusOrder == StatusOrder.NotTreated)
                        throw new Exception("לא ניתן לבטל הרשאה לחיוב חשבון כל עוד קיימת הצעה הקשורה אליה במצב פתוח");
                }
                Order o = getOrder(OrderKey);
                getGuestRequest(o.GuestRequestKey).CollectionClearance = false;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }
        #endregion

        #region Lists
        public List<BankBranch> AllBankBranch()
        {
            return dal.AllBankBranch();
        }

        public IEnumerable<GuestRequest> AllGuestRequest()
        {
            return dal.AllGuestRequest();
        }
        public IEnumerable<GuestRequest> TheGuestRequest (long key)
        {
            return dal.TheGuestRequest(key);
        }
        public IEnumerable<HostingUnit> TheHostingUnit(long key)
        {
            return dal.TheHostingUnit(key);
        }
        public IEnumerable<Order> TheOrder(long key)
        {
            return dal.TheOrder(key);
        }
        public IEnumerable<HostingUnit> AllHostingUnit()
        {
            return dal.AllHostingUnit();
        }

        public IEnumerable<Order> AllOrder()
        {
            return dal.AllOrder();
        }
        #endregion

        #region Other function
        public List<HostingUnit> freeUnit(DateTime date, int num)
        {
            
            return dal.freeUnit(date,num);
        }
        public double dayPast(DateTime date1, DateTime? date2 = null)
        {
            return dal.dayPast(date1, date2);
        }
        public IEnumerable<Order> orderDay(double numDay)
        {
            return dal.orderDay(numDay);
        }
        public IEnumerable<GuestRequest> request(Predicate<GuestRequest> cond)
        //public IEnumerable<GuestRequest> request(conditionDelegate cond)
        {
            return dal.request(cond);
        }
        public long numOfOrder(GuestRequest x)
        {
            return dal.numOfOrder(x);
        }
        public int numOfCloseOrder(HostingUnit x)
        {
            
            return dal.numOfCloseOrder(x);
        }
        public int sumOfPeople(Order o)
        {
            return sumOfPeople(o);
        }
        #endregion

        #region Grouping
        public IEnumerable<IGrouping<Area, GuestRequest>> GuestRequestByArea()
        {
            return dal.GuestRequestByArea();
        }
        public IEnumerable<IGrouping<int, GuestRequest>> GuestRequestByNumOfGuest()
        {
            return dal.GuestRequestByNumOfGuest();
        }
        public IEnumerable<IGrouping<Host, HostingUnit>> HostByNumOfHostingUnits()
        {
            return dal.HostByNumOfHostingUnits();
        }
        public IEnumerable<IGrouping<Area, HostingUnit>> HostingUnitByArea()
        {
            return dal.HostingUnitByArea();
        }

        #endregion
    }
}



