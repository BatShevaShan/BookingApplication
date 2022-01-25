using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BE;
using DS;
namespace DAL
{
    class DalImp : Idal
    {

        #region GuestRequest
        public void addGuestRequest(GuestRequest _guestRequest)
        {
            try
            {
                if (CheckGuestRequest(_guestRequest.GuestRequestKey))
                    throw new Exception("the gust request is already exist");
                _guestRequest.GuestRequestKey = ++Configuration.staticGuestRequestKey;
                DataSource.guestRequest.Add(_guestRequest.Clone());
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }
        public GuestRequest getGuestRequest(long key)
        {
            GuestRequest gust = DataSource.guestRequest.FirstOrDefault(gst => gst.GuestRequestKey == key);
            return gust == null ? null : gust.Clone();
        }
        public void removeGuestRequest(long GuestRequestKey)
        {
            int count = DataSource.guestRequest.RemoveAll(gust => gust.GuestRequestKey == GuestRequestKey);
            if (count == 0)
                throw new Exception("דרישת האירוח לא קיימת");
            GuestRequest g = getGuestRequest(GuestRequestKey);
            DataSource.guestRequest.Remove(g);
        }
        public void updateGuestRequest(long key)
        {
            try
            {
                int index = DataSource.guestRequest.FindIndex(gust => gust.GuestRequestKey == key);
                if (index == -1)
                    throw new Exception("the gust request does not exist");
                DataSource.guestRequest[index] = getGuestRequest(key);

            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }
        public bool CheckGuestRequest(long key)
        {
            return DataSource.guestRequest.Any(gust => gust.GuestRequestKey == key);


        }
        public void changeStatusGuestRequest(GuestRequest _guestRequest, StatusGuestRequest _statusGuestRequest)
        {
            try
            {
                if (_guestRequest.statusGuestRequest == StatusGuestRequest.CloseThroughTheSite || _guestRequest.statusGuestRequest == StatusGuestRequest.ClosedBecauseExpired)
                {
                    throw new Exception("ההזמנה נסגרה");
                }
                int index = DataSource.guestRequest.FindIndex(gust => gust.GuestRequestKey == _guestRequest.GuestRequestKey);
                DataSource.guestRequest[index].statusGuestRequest = _statusGuestRequest;

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
                if (CheckHostingUnit(_hostingUnit.HostingUnitKey))
                    throw new Exception("the hosting unit is already exist");
                _hostingUnit.HostingUnitKey = ++Configuration.staticHostingUnitKey;
                DataSource.hostingUnit.Add(_hostingUnit.Clone());
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }
        public HostingUnit getHostingUnit(long HostingUnitKey)
        {
            HostingUnit host = DataSource.hostingUnit.FirstOrDefault(hst => hst.HostingUnitKey == HostingUnitKey);
            return host == null ? null : host.Clone();
        }
        public void updategHostingUnit(HostingUnit _hostingUnit)
        {
            try
            {
                int index = DataSource.hostingUnit.FindIndex(host => host.HostingUnitKey == _hostingUnit.HostingUnitKey);
                if (index == -1)
                    throw new Exception("the hosting unit does not exist");
                DataSource.hostingUnit[index] = _hostingUnit;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }
        public void removeHostingUnit(long HostingUnitKey)
        {
            int index = DataSource.hostingUnit.FindIndex(host => host.HostingUnitKey == HostingUnitKey);
            if (index == -1)
                throw new Exception("the hosting unit does not exist");
            HostingUnit h = getHostingUnit(HostingUnitKey);
            DataSource.hostingUnit.RemoveAll(host => host.HostingUnitKey == HostingUnitKey);
        }
        public bool CheckHostingUnit(long key)
        {
            return DataSource.hostingUnit.Any(host => host.HostingUnitKey == key);
        }
        #endregion

        #region Order
        public void addOrder(Order _order)
        {
            try
            {
                if (CheckOrder(_order.OrderKey))
                    throw new Exception("the order is already exist");
                _order.OrderKey = ++Configuration.staticOrderKey;
                DataSource.order.Add(_order.Clone());
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }
        public Order getOrder(long key)
        {
            Order ord = DataSource.order.FirstOrDefault(o => o.OrderKey == key);
            return ord == null ? null : ord.Clone();
        }
        public void updateOrder(Order o)
        {
            try
            {
                int index = DataSource.order.FindIndex(ord => ord.OrderKey == o.OrderKey);
                if (index == -1)
                    throw new Exception("the gust request does not exist");
                DataSource.order[index]=o;

            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }
        public void removeOrder(long key)
        {
            int count = DataSource.order.RemoveAll(ord => ord.OrderKey == key);
            if (count == 0)
                throw new Exception("the order dose not exit");
            Order o = getOrder(key);
            DataSource.order.Remove(o);
        }
        public bool CheckOrder(long key)
        {
            return DataSource.order.Any(order => order.OrderKey == key);
        }
        public void changeStatusOrder(Order _order, StatusOrder _statusOrder)
        {
            try
            {
                if (_order.statusOrder == StatusOrder.ClosesNoResponse || _order.statusOrder == StatusOrder.ClosesWithResponse)
                {
                    throw new Exception("The Order Closed Successfully ");
                }
                int index = DataSource.order.FindIndex(ord => ord.OrderKey == _order.OrderKey);

                if (_statusOrder == StatusOrder.ClosesNoResponse)
                    DataSource.order[index].statusOrder = _statusOrder;
                if (_statusOrder == StatusOrder.ClosesWithResponse)
                {
                    DataSource.order[index].statusOrder = _statusOrder;
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
                throw new Exception(x.Message);
            }
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

        public IEnumerable<GuestRequest> TheGuestRequest(long key)
        {
            return from guest in DataSource.guestRequest
                   where guest.GuestRequestKey==key
                   select guest.Clone();
        }

        public IEnumerable<HostingUnit> TheHostingUnit(long key)
        {
            return from unit in DataSource.hostingUnit
                   where unit.HostingUnitKey == key
                   select unit.Clone();
        }

        public IEnumerable<Order> TheOrder(long key)
        {
            return from ord in DataSource.order
                   where ord.OrderKey == key
                   select ord.Clone();
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

        public IEnumerable<IGrouping<int, Host>> hostabyHostingUnitCount()
        {
            var v = HostByNumOfHostingUnits();
            var w = from g in v
                    group g.Key by g.Count();
            return w;
        }
        public IEnumerable<IGrouping<Area, HostingUnit>> HostingUnitByArea()
        {
            return from h in DataSource.hostingUnit
                   group h by h.areaHostingUnit;
        }
    
        #endregion
    }
}


