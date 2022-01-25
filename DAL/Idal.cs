using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
namespace DAL
{
    public interface Idal
    {
        #region GuestRequest
        void addGuestRequest(GuestRequest _guestRequest);
        GuestRequest getGuestRequest(long key);
        void updateGuestRequest(long key);
        void removeGuestRequest(long key);
        void changeStatusGuestRequest(GuestRequest _guestRequest, StatusGuestRequest _statusGuestRequest);
        bool CheckGuestRequest(long key);
        #endregion

        #region HostingUnit
        void addHostingUnit(HostingUnit _hostingUnit);
        HostingUnit getHostingUnit(long HostingUnitKey);
        void updategHostingUnit(HostingUnit _hostingUnit);
        void removeHostingUnit(long HostingUnitKey);
        bool CheckHostingUnit(long key);
        #endregion

        #region Order
        void addOrder(Order _order);
        Order getOrder(long Key);
        void updateOrder(Order o);
        void removeOrder(long Key);
        bool CheckOrder(long key);
        void changeStatusOrder(Order _order, StatusOrder _statusOrder);
        #endregion

        #region lists
        IEnumerable<Order> AllOrder();
        IEnumerable<HostingUnit> AllHostingUnit();
        IEnumerable<GuestRequest> AllGuestRequest();
        List<BankBranch> AllBankBranch();
        IEnumerable<GuestRequest> TheGuestRequest(long key);
        IEnumerable<HostingUnit> TheHostingUnit(long key);
        IEnumerable<Order> TheOrder(long key);
        #endregion

        #region Other function
        List<HostingUnit> freeUnit(DateTime date, int num);
        double dayPast(DateTime date1, DateTime? date2 = null);
        IEnumerable<Order> orderDay(double numDay);
        IEnumerable<GuestRequest> request(Predicate<GuestRequest> cond);
        long numOfOrder(GuestRequest x);
        int numOfCloseOrder(HostingUnit x);
        #endregion

        #region Grouping
        IEnumerable<IGrouping<Area, GuestRequest>> GuestRequestByArea();
        IEnumerable<IGrouping<int, GuestRequest>> GuestRequestByNumOfGuest();
        IEnumerable<IGrouping<Host, HostingUnit>> HostByNumOfHostingUnits();
        IEnumerable<IGrouping<Area, HostingUnit>> HostingUnitByArea();
        #endregion
    }
}


