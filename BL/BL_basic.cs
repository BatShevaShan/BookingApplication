using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using DAL;
using DS;

namespace BL
{
    public delegate bool conditionDelegate(GuestRequest x);
    public class BL_basic : IBL
    {
        DAL.Idal dal;
        public void initialization()
        {
            #region initializGustList
            DataSource.guestRequest = new List<GuestRequest>();
            DataSource.guestRequest.Add(new GuestRequest
            {
                EntryDate = DateTime.Parse("04/02/2020"),
                Adults = 5,
                area = Area.All,
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
            });
            DataSource.guestRequest.Add(new GuestRequest
            {
                EntryDate = DateTime.Parse("04/02/2020"),
                Adults = 5,
                area = Area.All,
                Children = 2,
                childrensAttractions = Request.Necessary,
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
            });
            DataSource.guestRequest.Add(new GuestRequest
            {
                EntryDate = DateTime.Parse("04/02/2020"),
                Adults = 5,
                area = Area.All,
                Children = 2,
                childrensAttractions = Request.Necessary,
                FamilyName = "alon",
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
            });
            #endregion

            #region initializUnitList
            DataSource.hostingUnit = new List<HostingUnit>();
            DataSource.hostingUnit.Add(new HostingUnit
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
                    CollectionClearance = false,
                    FamilyName = "shalom",
                    FhoneNumber = 0532432312,
                    HostKey = 68888,
                    MailAddress = "bat7@gmail.com",
                    PrivateName = "adi"
                }
            });
            DataSource.hostingUnit.Add(new HostingUnit
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
                    CollectionClearance = false,
                    FamilyName = "shalom",
                    FhoneNumber = 0532432312,
                    HostKey = 68888,
                    MailAddress = "bat7@gmail.com",
                    PrivateName = "shir"
                }
            });
            DataSource.hostingUnit.Add(new HostingUnit
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
                    CollectionClearance = false,
                    FamilyName = "shalom",
                    FhoneNumber = 0532432312,
                    HostKey = 68888,
                    MailAddress = "bat7@gmail.com",
                    PrivateName = "bat 7"
                }
            });
            #endregion

            #region initializOrderList
            DataSource.order = new List<Order>();
            DataSource.order.Add(new Order
            {
                CollectionClearance = false,
                CreateDate = DateTime.Today,
                GuestRequestKey = 10808080,
                HostingUnitKey = 989898,
                OrderDate = DateTime.Today.AddDays(6),
                OrderKey = 10000,
                statusOrder = StatusOrder.ClosesNoResponse

            });
            DataSource.order.Add(new Order
            {
                CollectionClearance = true,
                CreateDate = DateTime.Today,
                GuestRequestKey = 1077080,
                HostingUnitKey = 954698,
                OrderDate = DateTime.Today.AddDays(8),
                OrderKey = 1000022,
                statusOrder = StatusOrder.ClosesNoResponse
            });
            DataSource.order.Add(new Order
            {
                CollectionClearance = false,
                CreateDate = DateTime.Today,
                GuestRequestKey = 56563434,

                HostingUnitKey = 875858,
                OrderDate = DateTime.Today.AddDays(4),
                OrderKey = 100003,
                statusOrder = StatusOrder.MailHasBeenSent
            });
            #endregion
        }
        public BL_basic()
        {
            dal = DAL.FactoryDal.GetDal();
            initialization();

        }
        #region GuestRequest
        public void addGuestRequest(GuestRequest _guestRequest)
        {
            try
            {
                if (_guestRequest.PrivateName == null || _guestRequest.PrivateName == ""
                    || _guestRequest.FamilyName == null || _guestRequest.FamilyName == ""
                    || _guestRequest.MailAddress == null || _guestRequest.MailAddress == ""
                    || _guestRequest.MailAddress == null || _guestRequest.MailAddress == ""
                    || _guestRequest.EntryDate == default(DateTime) || _guestRequest.ReleaseDate == default(DateTime))
                    throw new Exception("חובה למלא את כל הפרטים");
                if (!CheckGuestRequest(_guestRequest.GuestRequestKey))
                    throw new Exception("בקשת האירוח כבר קיימת");
                if (_guestRequest.ReleaseDate < _guestRequest.EntryDate)
                    throw new Exception("התאריכים אינם תקינים");
                dal.addGuestRequest(_guestRequest);
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
        }
        public GuestRequest getGuestRequest(long GuestRequestKey)
        {
            return dal.getGuestRequest(GuestRequestKey);
        }
        public void removeGuestRequest(long GuestRequestKey)
        {
            try
            {
                int count = DataSource.guestRequest.RemoveAll(gust => gust.GuestRequestKey == GuestRequestKey);
                if (count == 0)
                    throw new Exception("בקשת האירוח לא קיימת");
                dal.removeGuestRequest(GuestRequestKey);
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
        }
        public void updateGuestRequest(StatusGuestRequest statusGuestRequest, long key)
        {
            GuestRequest g = getGuestRequest(key);
            if (g == null)
                throw new Exception("b");
            changeStatusGuestRequest(g, statusGuestRequest);
            dal.updateGuestRequest(key);
            //try
            //{
            //    int count = DataSource.guestRequest.RemoveAll(gust => gust.GuestRequestKey == key);
            //    if (count == 0)
            //        throw new Exception("בקשת האירוח לא קיימת");
            //    GuestRequest _guestRequest = getGuestRequest(key);
            //    changeStatusGuestRequest(_guestRequest, statusGuestRequest);
            //    dal.updateGuestRequest(statusGuestRequest, key);
            //}
            //catch (Exception x)
            //{
            //    Console.WriteLine(x.Message);
            //}
        }
        public bool CheckGuestRequest(long key)
        {
            return dal.CheckGuestRequest(key);
        }
        public void changeStatusGuestRequest(GuestRequest _guestRequest, StatusGuestRequest _statusGuestRequest)
        {
            try
            {
                if (_guestRequest.statusGuestRequest == StatusGuestRequest.CloseThroughTheSite || _guestRequest.statusGuestRequest == StatusGuestRequest.ClosedBecauseExpired)
                {
                    throw new Exception("ההזמנה נסגרה");
                }
                if (_statusGuestRequest == StatusGuestRequest.Open)
                    _guestRequest.statusGuestRequest = StatusGuestRequest.Open;
                if (_statusGuestRequest == StatusGuestRequest.CloseThroughTheSite)
                    _guestRequest.statusGuestRequest = StatusGuestRequest.CloseThroughTheSite;
                if (_statusGuestRequest == StatusGuestRequest.ClosedBecauseExpired)
                    _guestRequest.statusGuestRequest = StatusGuestRequest.ClosedBecauseExpired;
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
        }
        #endregion

        #region HostingUnit
        public void addHostingUnit(HostingUnit _hostingUnit)
        {
            try
            {
                if (!CheckHostingUnit(_hostingUnit.HostingUnitKey))
                    throw new Exception("יחידת האירוח כבר קיימת");
                if (_hostingUnit.Owner == null || _hostingUnit.HostingUnitName == null || _hostingUnit.HostingUnitName == "")
                    throw new Exception("חובה למלא את כל הפרטים");
                dal.addHostingUnit(_hostingUnit);
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
        }
        public HostingUnit getHostingUnit(long HostingUnitKey)
        {
            return dal.getHostingUnit(HostingUnitKey);
        }
        public void updategHostingUnit(HostingUnit _hostingUnit)
        {
            try
            {
                int count = DataSource.hostingUnit.RemoveAll(host => host.HostingUnitKey == _hostingUnit.HostingUnitKey);
                if (count == 0)
                    throw new Exception("יחידת האירוח לא קיימת");
                dal.updategHostingUnit(_hostingUnit);
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
        }
        public void removeHostingUnit(long HostingUnitKey)
        {
            try
            {
                int count = DataSource.hostingUnit.RemoveAll(host => host.HostingUnitKey == HostingUnitKey);
                if (count == 0)
                    throw new Exception("יחידת האירוח לא קיימת");
                foreach (var item in AllOrder())
                {
                    if (item.HostingUnitKey == HostingUnitKey && item.statusOrder == StatusOrder.NotTreated)
                        throw new Exception("לא ניתן למחוק יחידת אירוח כל עוד קיימת הצעה הקשורה אליה במצב פתוח");
                }
                dal.removeHostingUnit(HostingUnitKey);
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
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
                if (!CheckGuestRequest(_order.OrderKey))
                    throw new Exception("ההזמנה כבר קיימת");
                long l = _order.GuestRequestKey;
                GuestRequest g = getGuestRequest(l);
                if (g == null)
                    throw new Exception("לא ניתן להוסיף הזמנה כאשר לא קיימת בקשת אירוח");
                long lh = _order.HostingUnitKey;
                HostingUnit h = getHostingUnit(lh);
                if (h == null)
                    throw new Exception("לא ניתן להוסיף הזמנה כאשר לא קיימת יחידת אירוח");
                DateTime d1 = g.EntryDate;
                DateTime d2 = g.ReleaseDate;
                while (h.Diary[d1.Month, d1.Day] != h.Diary[d2.Month, d2.Day])
                {
                    if (h.Diary[d1.Month, d1.Day] == false)
                        throw new Exception("התאריכים המבוקשים אינם פנויים");
                    else
                        d1.AddDays(1);
                }
                dal.addOrder(_order);
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
        }
        public Order getOrder(long OrderKey)
        {
            return dal.getOrder(OrderKey);
        }
        public void updateOrder(StatusOrder statusOrder, long key)
        {
            try
            {
                Order _order = getOrder(key);
                if (_order == null)
                    throw new Exception("ההזמנה לא קיימת");
                changeStatusOrder(_order, statusOrder);
                dal.updateOrder(key);
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
        }
        public void removeOrder(long OrderKey)
        {
            try
            {
                int count = DataSource.order.RemoveAll(ord => ord.OrderKey == OrderKey);
                if (count == 0)
                    throw new Exception("ההזמנה לא קיימת");
                dal.removeOrder(OrderKey);
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
        }

        public bool CheckOrder(long key)
        {
            return dal.CheckOrder(key);
        }
        public void changeStatusOrder(Order _order, StatusOrder _statusOrder)
        {
            try { 
            if (_order.statusOrder == StatusOrder.ClosesNoResponse || _order.statusOrder == StatusOrder.ClosesWithResponse)
            {
                throw new Exception("ההזמנה נסגרה");
            }
            if (_statusOrder == StatusOrder.NotTreated)
                _order.statusOrder = StatusOrder.NotTreated;
            if (_statusOrder == StatusOrder.MailHasBeenSent)
            {
                if (_order.CollectionClearance == false)
                    throw new Exception("אין חתימה על הרשאה לחיוב חשבון");
                _order.statusOrder = StatusOrder.MailHasBeenSent;
                Console.WriteLine("נשלח מייל");
            }
            if (_statusOrder == StatusOrder.ClosesNoResponse)
                _order.statusOrder = StatusOrder.ClosesNoResponse;
            if (_statusOrder == StatusOrder.ClosesWithResponse)
            {
                _order.statusOrder = StatusOrder.ClosesWithResponse;
                long l = _order.GuestRequestKey;
                GuestRequest g = getGuestRequest(l);
                //g.statusGuestRequest = enums.StatusGuestRequest.CloseThroughTheSite;
                changeStatusGuestRequest(g, g.statusGuestRequest);
                foreach (var item in AllOrder())
                {
                    if (item.OrderKey == _order.OrderKey)
                    {
                        long l1 = _order.GuestRequestKey;
                        GuestRequest g1 = getGuestRequest(l1);
                        long l2 = item.GuestRequestKey;
                        GuestRequest g2 = getGuestRequest(l2);
                        if (g1.EntryDate == g2.EntryDate && g1.ReleaseDate == g2.ReleaseDate)
                            removeGuestRequest(l2);
                    }
                }
                long lh = _order.HostingUnitKey;
                HostingUnit h = getHostingUnit(lh);
                DateTime d1 = g.EntryDate;
                DateTime d2 = g.ReleaseDate;
                double dp = dayPast(d1, d2);
                for (double i = 0; i < dp; i++)
                {
                    h.Diary[d1.Month + (int)i, d1.Day + (int)i] = true;
                }
                Configuration.fee += (int)dp * 10;
            }
        }
              catch (Exception x)
            {
                Console.WriteLine(x.Message);
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
                o.CollectionClearance = false;
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
        }
        #endregion

        #region Lists
        public List<BankBranch> AllBankBranch()
        {
            List<BankBranch> bankBranch = new List<BankBranch>();
            bankBranch.Add(new BankBranch { BankName = "poalim", BankNumber = 11, BranchNumber = 290, BranchAddress = "bet hadfos", BranchCity = "jerusalem" });
            bankBranch.Add(new BankBranch { BankName = "poalim", BankNumber = 11, BranchNumber = 290, BranchAddress = "bet hadfos", BranchCity = "jerusalem" });
            bankBranch.Add(new BankBranch { BankName = "poalim", BankNumber = 11, BranchNumber = 290, BranchAddress = "bet hadfos", BranchCity = "jerusalem" });
            bankBranch.Add(new BankBranch { BankName = "poalim", BankNumber = 11, BranchNumber = 290, BranchAddress = "bet hadfos", BranchCity = "jerusalem" });
            bankBranch.Add(new BankBranch { BankName = "poalim", BankNumber = 11, BranchNumber = 290, BranchAddress = "bet hadfos", BranchCity = "jerusalem" });
            return bankBranch;
        }

        public IEnumerable<GuestRequest> AllGuestRequest()
        {
            return from gust in DataSource.guestRequest
                   select gust.Clone();
        }

        public IEnumerable<HostingUnit> AllHostingUnit()
        {
            return from unit in DataSource.hostingUnit
                   select unit.Clone();
        }

        public IEnumerable<Order> AllOrder()
        {
            return from ord in DataSource.order
                   select ord.Clone();
        }
        #endregion

        #region Other function
        public List<HostingUnit> freeUnit(DateTime date, int num)
        {
            List<HostingUnit> units = new List<HostingUnit>();
            bool flag = true;
            var v = from unit in DataSource.hostingUnit
                    where unit.Diary[date.Month - 1, date.Day - 1] == true
                    select unit.Clone();
            foreach (var unit in v)
            {
                for (int i = 0; i < num; i++)
                {
                    if (unit.Diary[date.Month + i, date.Day + i] == true)
                        flag = false;
                }
                if (flag == true)
                    units.Add(unit);
                flag = true;
            }
            return units;
        }
        public double dayPast(DateTime date1, DateTime? date2 = null)
        {
            if (date2 != null)
                return (date2 - date1).Value.TotalDays;
            return (DateTime.Today.Date - date1).TotalDays;
        }
        public IEnumerable<Order> orderDay(double numDay)
        {
            return from ord in DataSource.order
                   where ((DateTime.Today.Date - ord.CreateDate).TotalDays) >= numDay
                   select ord.Clone();
        }
        public IEnumerable<GuestRequest> request(Predicate<GuestRequest> cond)
        //public IEnumerable<GuestRequest> request(conditionDelegate cond)
        {
            return from gst in DataSource.guestRequest
                   where cond(gst)
                   select gst.Clone();
        }
        public long numOfOrder(GuestRequest x)
        {
            long num = 0;
            foreach (var item in AllOrder())
            {
                if (item.GuestRequestKey == x.GuestRequestKey)
                    num++;
            }
            return num;
        }
        public int numOfCloseOrder(HostingUnit x)
        {
            bool check = true;
            int num = 0;
            for (int i = 0; i < 12; ++i)
            {//Prints busy dates
                int numOfDay = DateTime.DaysInMonth(2020, i + 1);
                for (int j = 0; j < numOfDay; ++j)
                {
                    if (x.Diary[i, j] == true && check == true)
                    {
                        check = false;
                    }
                    if (x.Diary[i, j] == false && check == false)
                    {
                        check = true;
                        num++;
                    }
                }
            }
            return num;
        }
        public int sumOfPeople(Order o)
        {
            long l = o.GuestRequestKey;
            GuestRequest g = getGuestRequest(l);
            return g.Adults + g.Children;
        }
        public int sumOfPay(Order o)
        {
            long l = o.GuestRequestKey;
            GuestRequest g = getGuestRequest(l);
            return g.Adults * g.payAdults + g.Children * g.payChildren;
        }
        #endregion

        #region Grouping
        public IEnumerable<IGrouping<Area, GuestRequest>> GuestRequestByArea()
        {
            return from g in DataSource.guestRequest
                   group g by g.area;
        }
        public IEnumerable<IGrouping<int, GuestRequest>> GuestRequestByNumOfGuest()
        {
            return from g in DataSource.guestRequest
                   group g by (g.Adults + g.Children);
        }
        public IEnumerable<IGrouping<Host, HostingUnit>> HostByNumOfHostingUnits()
        {
            return from h in DataSource.hostingUnit
                   group h by h.Owner;
        }
        public IEnumerable<IGrouping<Area, HostingUnit>> HostingUnitByArea()
        {
            return from h in DataSource.hostingUnit
                   group h by h.areaHostingUnit;
        }

        #endregion
    }
}


