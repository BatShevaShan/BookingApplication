//using BE;
//using System.ComponentModel;
//using System.Reflection;
//using System.Xml.Linq;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using DS;
//using System.Xml.Serialization;
//using System.Net;
//using System.Threading;
//using System.Net.Mail;

//namespace DAL
//{
//    class DALIMP_XML : Idal
//    {
//        static DALIMP_XML instance = new DALIMP_XML();
//        public static DALIMP_XML Instance { get { return instance; } }

//        //Flag for config update
//        public volatile bool updated = false;

//        XElement guestRequestRoot;
//        string guestRequestPath = @"guestRequestXml.xml";
//        public static List<BE.GuestRequest> guestRequests = new List<GuestRequest>();
//        XElement hostingUnitRoot;
//        string hostingUnitPath = @" hostingUnitXml.xml";
//        public static List<BE.HostingUnit> hostingUnits = new List<HostingUnit>();
//        XElement orderRoot;
//        string orderPath = @"orderXml.xml";
//        public static List<BE.Order> orders = new List<Order>();
//        static readonly string ProjectPath = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory.ToString()).FullName).FullName;//path of xml files
//        XElement configRoot;
//        private readonly string configPath = ProjectPath + "/Data/config.xml";
//        public DALIMP_XML()
//        {

//            if (!File.Exists(guestRequestPath))
//            {
//                CreateFiles();
//                List<HostingUnit> hostingUnitList = new List<HostingUnit>();//empty list for start
//                SaveToXML<List<HostingUnit>>(hostingUnitList, hostingUnitPath);
//            }
//            else
//                LoadData();
//            if (!File.Exists(orderPath))
//            {
//                List<Order> orderList = new List<Order>();//empty list for start
//                SaveToXML<List<Order>>(orderList, orderPath);
//            }
//            const string xmlLocalPath = @"atm.xml";
//            WebClient wc = new WebClient();
//            try
//            {
//                string xmlServerPath =
//               @"http://www.boi.org.il/he/BankingSupervision/BanksAndBranchLocations/Lists/BoiBankBranchesDocs/atm.xml";
//                wc.DownloadFile(xmlServerPath, xmlLocalPath);
//            }
//            catch (Exception)
//            {
//                string xmlServerPath = @"http://www.jct.ac.il/~coshri/atm.xml";
//                wc.DownloadFile(xmlServerPath, xmlLocalPath);
//            }
//            finally
//            {
//                wc.Dispose();
//            }
//        }
//        private void bank()
//        {
//            const string xmlLocalPath = @"atm.xml";
//            WebClient wc = new WebClient();
//            try
//            {
//                string xmlServerPath =
//               @"http://www.boi.org.il/he/BankingSupervision/BanksAndBranchLocations/Lists/BoiBankBranchesDocs/atm.xml";
//                wc.DownloadFile(xmlServerPath, xmlLocalPath);
//            }
//            catch (Exception)
//            {
//                string xmlServerPath = @"http://www.jct.ac.il/~coshri/atm.xml";
//                wc.DownloadFile(xmlServerPath, xmlLocalPath);
//            }
//            finally
//            {
//                wc.Dispose();
//            }
//        }
//        private void CreateFiles()
//        {
//            guestRequestRoot = new XElement("guestRequest");
//            guestRequestRoot.Save(guestRequestPath);
//            hostingUnitRoot = new XElement("hostingUnit");
//            hostingUnitRoot.Save(hostingUnitPath);
//            orderRoot = new XElement("order");
//            orderRoot.Save(orderPath);
//        }
//        private void LoadData()
//        {
//            try
//            {
//                guestRequestRoot = XElement.Load(guestRequestPath);
//                hostingUnitRoot = XElement.Load(hostingUnitPath);
//                orderRoot = XElement.Load(orderPath);
//                //const string xmlLocalPath = @"atm.xml";
//                //WebClient wc = new WebClient();
//                //    try
//                //    {
//                //        string xmlServerPath =
//                //       @"http://www.boi.org.il/he/BankingSupervision/BanksAndBranchLocations/Lists/BoiBankBranchesDocs/atm.xml";
//                //        wc.DownloadFile(xmlServerPath, xmlLocalPath);
//                //    }
//                //    catch (Exception)
//                //    {
//                //        string xmlServerPath = @"http://www.jct.ac.il/~coshri/atm.xml";
//                //        wc.DownloadFile(xmlServerPath, xmlLocalPath);
//                //    }
//                //    finally
//                //    {
//                //        wc.Dispose();
//                //    }
//                //}
//            }
//            catch
//            {
//                throw new Exception("File upload problem");
//            }
//        }
//        public static void SaveToXML<T>(T source, string path)
//        {
//            FileStream file = new FileStream(path, FileMode.Create);
//            XmlSerializer xmlSerializer = new XmlSerializer(source.GetType());
//            xmlSerializer.Serialize(file, source);
//            file.Close();
//        }
//        public static T LoadFromXML<T>(string path)
//        {
//            FileStream file = new FileStream(path, FileMode.Open);
//            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
//            T result = (T)xmlSerializer.Deserialize(file);
//            file.Close();
//            return result;
//        }
//        private static string remeinderEmailHTML;
//        public static string RemeinderEmailHTML
//        {
//            get
//            {
//                if (remeinderEmailHTML == null)
//                    remeinderEmailHTML = File.ReadAllText(ProjectPath + "/Data/emails/TestRemeinder.html");
//                return remeinderEmailHTML;
//            }
//        }
//        private static string AddedEmailHTML;
//        public static string addedEmailHTML
//        {
//            get
//            {
//                if (AddedEmailHTML == null)
//                    AddedEmailHTML = File.ReadAllText(ProjectPath + "/Data/emails/AddedTest.html");
//                return AddedEmailHTML;
//            }
//        }
//        private static string CancelationEmailHTML;
//        public static string cancelationEmailHTML
//        {
//            get
//            {
//                if (CancelationEmailHTML == null)
//                    CancelationEmailHTML = File.ReadAllText(ProjectPath + "/Data/emails/TestCancelation.html");
//                return CancelationEmailHTML;
//            }
//        }
//        private static string UpdateResultsEmailHTML;
//        public static string updateResultsEmailHTML
//        {
//            get
//            {
//                if (UpdateResultsEmailHTML == null)
//                    UpdateResultsEmailHTML = File.ReadAllText(ProjectPath + "/Data/emails/UpdateTestResult.html");
//                return UpdateResultsEmailHTML;
//            }
//        }
//        private static string appealEmailHTML;
//        public static string AppealEmailHTML
//        {
//            get
//            {
//                if (appealEmailHTML == null)
//                    appealEmailHTML = File.ReadAllText(ProjectPath + "/Data/emails/Appeal.html");
//                return appealEmailHTML;
//            }
//        }
//        public string GetEmailTemltateHTML(EmailType emailType)
//        {
//            switch (emailType)
//            {
//                case EmailType.Reminder:
//                    return RemeinderEmailHTML;
//                case EmailType.Added:
//                    return AddedEmailHTML;
//                case EmailType.Cancelation:
//                    return CancelationEmailHTML;
//                case EmailType.UpdateResults:
//                    return UpdateResultsEmailHTML;
//                case EmailType.Appeal:
//                    return AppealEmailHTML;
//                default:
//                    return "";
//            }
//        }


//        XElement ConvertGuestRequest(BE.GuestRequest guestRequest)
//        {
//            XElement guestRequestElement = new XElement("guestRequest");

//            foreach (PropertyInfo item in typeof(BE.GuestRequest).GetProperties())
//                guestRequestElement.Add
//                    (
//                    new XElement(item.Name, item.GetValue(guestRequest, null).ToString())
//                    );

//            return guestRequestElement;
//        }
//        BE.GuestRequest ConvertGuestRequest(XElement element)
//        {
//            GuestRequest guestRequest = new GuestRequest();

//            foreach (PropertyInfo item in typeof(BE.GuestRequest).GetProperties())
//            {
//                TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
//                object convertValue = typeConverter.ConvertFromString(element.Element(item.Name).Value);

//                if (item.CanWrite)
//                    item.SetValue(guestRequest, convertValue);
//            }

//            return guestRequest;
//        }
//        void LoadConfigs()
//        {
//            try
//            {
//                configRoot = XElement.Load(configPath);

//            }
//            catch
//            {
//                throw new FileLoadException("Unable to open config file");
//            }
//        }


//        void SaveConfigs()
//        {
//            try
//            {
//                configRoot.Save(configPath);
//            }
//            catch
//            {
//                throw new FileNotFoundException("Unable to save configs in Xml file");
//            }
//        }
//        #region GuestRequest
//        public void addGuestRequest(GuestRequest _guestRequest)
//        {
//            try
//            {
//                if (CheckGuestRequest(_guestRequest.GuestRequestKey))
//                    throw new Exception("the gust request is already exist");

//                XElement GuestRequestKey = new XElement("GuestRequestKey", _guestRequest.GuestRequestKey);
//                XElement PrivateName = new XElement("PrivateName", _guestRequest.PrivateName);
//                XElement FamilyName = new XElement("FamilyName", _guestRequest.FamilyName);
//                XElement MailAddress = new XElement("MailAddress", _guestRequest.MailAddress);
//                XElement SubArea = new XElement("SubArea", _guestRequest.SubArea);
//                XElement RegistrationDate = new XElement("RegistrationDate", _guestRequest.RegistrationDate);
//                XElement EntryDate = new XElement("EntryDate", _guestRequest.EntryDate);
//                XElement ReleaseDate = new XElement("ReleaseDate", _guestRequest.ReleaseDate);
//                XElement Adults = new XElement("Adults", _guestRequest.Adults);
//                XElement Children = new XElement("Children", _guestRequest.Children);
//                XElement area = new XElement("area", _guestRequest.area);
//                XElement pool = new XElement("pool", _guestRequest.pool);
//                XElement jacuzzi = new XElement("jacuzzi", _guestRequest.jacuzzi);
//                XElement garden = new XElement("garden", _guestRequest.garden);
//                XElement childrensAttractions = new XElement("childrensAttractions", _guestRequest.childrensAttractions);
//                XElement CollectionClearance = new XElement("CollectionClearance", _guestRequest.CollectionClearance);
//                XElement statusGuestRequest = new XElement("statusGuestRequest", _guestRequest.statusGuestRequest);
//                XElement type = new XElement("type", _guestRequest.type);

//                guestRequestRoot.Add(ConvertGuestRequest(_guestRequest));
//                Console.WriteLine(guestRequestRoot);
//                guestRequestRoot.Save(guestRequestPath);
//            }
//            catch (Exception x)
//            {
//                throw new Exception(x.Message);
//            }
//        }
//        public GuestRequest getGuestRequest(long key)
//        {
//            XElement gu = null;

//            try
//            {
//                gu = (from item in guestRequestRoot.Elements()
//                      where long.Parse(item.Element("GuestRequestKey").Value) == key
//                      select item).FirstOrDefault();
//            }
//            catch (Exception)
//            {
//                return null;
//            }

//            if (gu == null)
//                return null;

//            return ConvertGuestRequest(gu);
//        }
//        public void removeGuestRequest(long GuestRequestKey)
//        {
//            XElement toRemove = (from item in guestRequestRoot.Elements()
//                                 where int.Parse(item.Element("GuestRequestKey").Value) == GuestRequestKey
//                                 select item).FirstOrDefault();

//            if (toRemove == null)
//                throw new Exception("GuestRequest with the same id not found...");

//            toRemove.Remove();

//            guestRequestRoot.Save(guestRequestPath);
//        }
//        public void updateGuestRequest(long key)
//        {
//            GuestRequest g = getGuestRequest(key);
//            XElement toUpdate = (from item in guestRequestRoot.Elements()
//                                 where int.Parse(item.Element("GuestRequestKey").Value) == key
//                                 select item).FirstOrDefault();

//            if (toUpdate == null)
//                throw new Exception("GuestRequest with the same id not found...");

//            foreach (PropertyInfo item in typeof(BE.GuestRequest).GetProperties())
//                toUpdate.Element(item.Name).SetValue(item.GetValue(g).ToString());

//            guestRequestRoot.Save(guestRequestPath);
//        }
//        public bool CheckGuestRequest(long key)
//        {
//            return DataSource.guestRequest.Any(gust => gust.GuestRequestKey == key);


//        }
//        public void changeStatusGuestRequest(GuestRequest _guestRequest, StatusGuestRequest _statusGuestRequest)
//        {
//            try
//            {
//                if (_guestRequest.statusGuestRequest == StatusGuestRequest.CloseThroughTheSite || _guestRequest.statusGuestRequest == StatusGuestRequest.ClosedBecauseExpired)
//                {
//                    throw new Exception("ההזמנה נסגרה");
//                }
//                int index = DataSource.guestRequest.FindIndex(gust => gust.GuestRequestKey == _guestRequest.GuestRequestKey);
//                DataSource.guestRequest[index].statusGuestRequest = _statusGuestRequest;

//            }
//            catch (Exception x)
//            {
//                throw new Exception(x.Message);
//            }
//        }
//        #endregion

//        #region HostingUnit
//        XElement ConvertHostingUnit(BE.HostingUnit hostingUnit)
//        {
//            XElement hostingUnitElement = new XElement("hostingUnit");

//            foreach (PropertyInfo item in typeof(BE.HostingUnit).GetProperties())
//                hostingUnitElement.Add
//                    (
//                    new XElement(item.Name, item.GetValue(hostingUnit, null).ToString())
//                    );

//            return hostingUnitElement;
//        }

//        BE.HostingUnit ConvertHostingUnit(XElement element)
//        {
//            HostingUnit hostingUnit = new HostingUnit();

//            foreach (PropertyInfo item in typeof(BE.HostingUnit).GetProperties())
//            {

//                TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
//                object convertValue = typeConverter.ConvertFromString(element.Element(item.Name).Value);

//                if (item.CanWrite)
//                    item.SetValue(hostingUnit, convertValue);
//            }

//            return hostingUnit;
//        }
//        public void addHostingUnit(HostingUnit _hostingUnit)
//        {
//            //try
//            //{
//            //    if (CheckHostingUnit(_hostingUnit.HostingUnitKey))
//            //        throw new Exception("the hosting unit is already exist");
//            //    //_hostingUnit.HostingUnitKey = ++Configuration.staticHostingUnitKey;
//            //    //DataSource.hostingUnit.Add(_hostingUnit.Clone());
//            //    //SaveToXML<List<HostingUnit>>(hostingUnits, hostingUnitPath);
//            //    XElement help = XElement.Load(@"configXml.xml");
//            //    help.Save(@"configXml.xml");

//            //    SaveToXML<List<HostingUnit>>(hostingUnits, hostingUnitPath);//save in file
//            //    hostingUnits.Add(_hostingUnit);
//            //   // LoadFromXML(hostingUnits, hostingUnitPath);
//            //}
//            //catch (Exception x)
//            //{
//            //    throw new Exception(x.Message);
//            //}
//            //try
//            //{
//            //    if (CheckHostingUnit(_hostingUnit.HostingUnitKey))
//            //        throw new Exception("the gust request is already exist");

//            //    XElement HostingUnitKey = new XElement("HostingUnitKey", _hostingUnit.HostingUnitKey);
//            //    XElement HostingUnitName = new XElement("hostingUnitName", _hostingUnit.HostingUnitName);
//            //    XElement jacuzziHostingUnit = new XElement("jacuzziHostingUnit", _hostingUnit.jacuzziHostingUnit);
//            //    XElement gardenHostingUnit = new XElement("gardenHostingUnit", _hostingUnit.gardenHostingUnit);
//            //    XElement areaHostingUnit = new XElement("childrensAttractions", _hostingUnit.areaHostingUnit);
//            //    XElement typeHostingUnit = new XElement("typeHostingUnit", _hostingUnit.typeHostingUnit);
//            //    XElement poolHostingUnit = new XElement("poolHostingUnit", _hostingUnit.poolHostingUnit);
//            //    //XElement typeHostingUnit = new XElement("typeHostingUnit", _hostingUnit.typeHostingUnit);

//            //    hostingUnitRoot.Add(ConvertHostingUnit(_hostingUnit));

//            //    hostingUnitRoot.Save(hostingUnitPath);
//            //}
//            //catch (Exception x)
//            //{
//            //    throw new Exception(x.Message);
//            //}

//            HostingUnit hos = getHostingUnit(_hostingUnit.HostingUnitKey);
//            if (hos != null)//Checks whether the tester already exists in the system
//                throw new Exception("tester with the same id already exists...");

//            List<HostingUnit> hostingUnitList = LoadFromXML<List<HostingUnit>>(hostingUnitPath);//we are sure there is file cause created once in ctor
//            hostingUnitList.Add(_hostingUnit);
//            SaveToXML<List<HostingUnit>>(hostingUnitList, hostingUnitPath);//save in file
//        }
//        public HostingUnit getHostingUnit(long HostingUnitKey)
//        {
//            //return hostingUnits.FirstOrDefault(t => t.HostingUnitKey == HostingUnitKey);
//            XElement ho = null;

//            try
//            {
//                ho = (from item in hostingUnitRoot.Elements()
//                      where int.Parse(item.Element("HostingUnitKey").Value) == HostingUnitKey
//                      select item).FirstOrDefault();
//            }
//            catch (Exception)
//            {
//                return null;
//            }

//            if (ho == null)
//                return null;

//            return ConvertHostingUnit(ho);
//        }
//        public BE.HostingUnit getHostingUnitCopy(long key)
//        {
//            return getHostingUnit(key).Clone();
//        }
//        public void updategHostingUnit(HostingUnit _hostingUnit)
//        {
//            //try
//            //{
//            //    int index = hostingUnits.FindIndex(host => host.HostingUnitKey == _hostingUnit.HostingUnitKey);
//            //    if (index == -1)
//            //        throw new Exception("the gust request does not exist");


//            //    hostingUnits[index] = _hostingUnit.Clone();
//            //    SaveToXML<List<HostingUnit>>(hostingUnits, hostingUnitPath);
//            //}
//            //catch (Exception x)
//            //{
//            //    throw new Exception(x.Message);
//            //}
//            // HostingUnit h = getHostingUnit(key);
//            XElement toUpdate = (from item in hostingUnitRoot.Elements()
//                                 where int.Parse(item.Element("HostingUnitKey").Value) == _hostingUnit.HostingUnitKey
//                                 select item).FirstOrDefault();

//            if (toUpdate == null)
//                throw new Exception("HostingUnit with the same id not found...");

//            foreach (PropertyInfo item in typeof(BE.HostingUnit).GetProperties())
//                toUpdate.Element(item.Name).SetValue(item.GetValue(_hostingUnit).ToString());

//            hostingUnitRoot.Save(hostingUnitPath);








//        }
//        public void removeHostingUnit(long HostingUnitKey)
//        {

//            //HostingUnit h = getHostingUnit(HostingUnitKey);
//            //hostingUnits.Remove(h);
//            //SaveToXML<List<HostingUnit>>(hostingUnits, hostingUnitPath);
//            XElement toRemove = (from item in hostingUnitRoot.Elements()
//                                 where int.Parse(item.Element("HostingUnitKey").Value) == HostingUnitKey
//                                 select item).FirstOrDefault();

//            if (toRemove == null)
//                throw new Exception("HostingUnit with the same id not found...");

//            toRemove.Remove();

//            hostingUnitRoot.Save(hostingUnitPath);
//        }
//        public bool CheckHostingUnit(long key)
//        {
//            return DataSource.hostingUnit.Any(host => host.HostingUnitKey == key);
//        }
//        #endregion

//        #region Order
//        XElement ConvertOrder(BE.Order order)
//        {
//            XElement orderElement = new XElement("order");

//            foreach (PropertyInfo item in typeof(BE.Order).GetProperties())
//                orderElement.Add
//                    (
//                    new XElement(item.Name, item.GetValue(order, null).ToString())
//                    );

//            return orderElement;
//        }
//        BE.Order ConvertOrder(XElement element)
//        {
//            Order order = new Order();

//            foreach (PropertyInfo item in typeof(BE.Order).GetProperties())
//            {
//                TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
//                object convertValue = typeConverter.ConvertFromString(element.Element(item.Name).Value);

//                if (item.CanWrite)
//                    item.SetValue(order, convertValue);
//            }

//            return order;
//        }
//        public void addOrder(Order _order)
//        {
//            //    try
//            //    {
//            //        if (CheckOrder(_order.OrderKey))
//            //            throw new Exception("the order is already exist");
//            //        _order.OrderKey = ++Configuration.staticOrderKey;
//            //        XElement help = XElement.Load(@"configXml.xml");
//            //        help.Save(@"configXml.xml");
//            //        DataSource.order.Add(_order.Clone());
//            //        SaveToXML<List<Order>>(orders, orderPath);




//            //}
//            //    catch (Exception x)
//            //    {
//            //        throw new Exception(x.Message);
//            //    }
//            try
//            {
//                if (CheckOrder(_order.OrderKey))
//                    throw new Exception("the order is already exist");
//                // _order.OrderKey = ++Configuration.staticOrderKey;
//                //DataSource.order.Add(_order.Clone());
//                //if (CheckOrder(_order.OrderKey))
//                //    throw new Exception("the order is already exist");

//                XElement HostingUnitKey = new XElement("HostingUnitKey", _order.HostingUnitKey);
//                XElement GuestRequestKey = new XElement("GuestRequestKey", _order.GuestRequestKey);
//                XElement OrderKey = new XElement("OrderKey", _order.OrderKey);
//                XElement CreateDate = new XElement("CreateDate", _order.CreateDate);
//                XElement OrderDate = new XElement("OrderDate", _order.OrderDate);
//                XElement statusOrder = new XElement("statusOrder", _order.statusOrder);


//                orderRoot.Add(ConvertOrder(_order));

//                orderRoot.Save(orderPath);
//            }
//            catch (Exception x)
//            {
//                throw new Exception(x.Message);
//            }
//        }
//        public Order getOrder(long key)
//        {
//            // return orders.FirstOrDefault(t => t.OrderKey == key);

//            XElement or = null;

//            try
//            {
//                or = (from item in orderRoot.Elements()
//                      where int.Parse(item.Element("key").Value) == key
//                      select item).FirstOrDefault();
//            }
//            catch (Exception)
//            {
//                return null;
//            }

//            if (or == null)
//                return null;

//            return ConvertOrder(or);
//        }
//        public BE.Order getOrderCopy(long key)
//        {
//            return getOrder(key).Clone();
//        }
//        public void updateOrder(long key)
//        {
//            //try
//            //{
//            //    int index = DataSource.order.FindIndex(ord => ord.OrderKey == key);
//            //    if (index == -1)
//            //        throw new Exception("the gust request does not exist");

//            //    orders[index] = (getOrder(key)).Clone();
//            //    SaveToXML<List<Order>>(orders, orderPath);
//            //}
//            //catch (Exception x)
//            //{
//            //    throw new Exception(x.Message);
//            //}
//            Order o = getOrder(key);
//            XElement toUpdate = (from item in orderRoot.Elements()
//                                 where int.Parse(item.Element("key").Value) == key
//                                 select item).FirstOrDefault();

//            if (toUpdate == null)
//                throw new Exception("Order with the same id not found...");

//            foreach (PropertyInfo item in typeof(BE.HostingUnit).GetProperties())
//                toUpdate.Element(item.Name).SetValue(item.GetValue(o).ToString());

//            hostingUnitRoot.Save(orderPath);

//        }
//        public void removeOrder(long key)
//        {
//            //Order o = getOrder(key);
//            //orders.Remove(o);
//            //SaveToXML<List<Order>>(orders, orderPath);
//            XElement toRemove = (from item in orderRoot.Elements()
//                                 where int.Parse(item.Element("Key").Value) == key
//                                 select item).FirstOrDefault();

//            if (toRemove == null)
//                throw new Exception("Order with the same id not found...");

//            toRemove.Remove();

//            orderRoot.Save(orderPath);
//        }
//        public bool CheckOrder(long key)
//        {
//            return DataSource.order.Any(order => order.OrderKey == key);
//        }
//        public void changeStatusOrder(Order _order, StatusOrder _statusOrder)
//        {
//            try
//            {
//                if (_order.statusOrder == StatusOrder.ClosesNoResponse || _order.statusOrder == StatusOrder.ClosesWithResponse)
//                {
//                    throw new Exception("The Order Closed Successfully ");
//                }
//                int index = DataSource.order.FindIndex(ord => ord.OrderKey == _order.OrderKey);

//                if (_statusOrder == StatusOrder.ClosesNoResponse)
//                    DataSource.order[index].statusOrder = _statusOrder;
//                if (_statusOrder == StatusOrder.ClosesWithResponse)
//                {
//                    DataSource.order[index].statusOrder = _statusOrder;
//                    long l = _order.GuestRequestKey;
//                    GuestRequest g = getGuestRequest(l);
//                    //g.statusGuestRequest = enums.StatusGuestRequest.CloseThroughTheSite;
//                    changeStatusGuestRequest(g, g.statusGuestRequest);
//                    foreach (var item in AllOrder())
//                    {
//                        if (item.OrderKey == _order.OrderKey)
//                        {
//                            long l1 = _order.GuestRequestKey;
//                            GuestRequest g1 = getGuestRequest(l1);
//                            long l2 = item.GuestRequestKey;
//                            GuestRequest g2 = getGuestRequest(l2);
//                            if (g1.EntryDate == g2.EntryDate && g1.ReleaseDate == g2.ReleaseDate)
//                                removeGuestRequest(l2);
//                        }
//                    }
//                    long lh = _order.HostingUnitKey;
//                    HostingUnit h = getHostingUnit(lh);
//                    DateTime d1 = g.EntryDate;
//                    DateTime d2 = g.ReleaseDate;
//                    double dp = dayPast(d1, d2);
//                    for (double i = 0; i < dp; i++)
//                    {
//                        h.Diary[d1.Month + (int)i, d1.Day + (int)i] = true;
//                    }
//                    Configuration.fee += (int)dp * 10;
//                }
//            }
//            catch (Exception x)
//            {
//                throw new Exception(x.Message);
//            }
//        }
//        #endregion

//        #region Other function
//        public List<HostingUnit> freeUnit(DateTime date, int num)
//        {
//            List<HostingUnit> units = new List<HostingUnit>();
//            bool flag = true;
//            var v = from unit in DataSource.hostingUnit
//                    where unit.Diary[date.Month - 1, date.Day - 1] == true
//                    select unit.Clone();
//            foreach (var unit in v)
//            {
//                for (int i = 0; i < num; i++)
//                {
//                    if (unit.Diary[date.Month + i, date.Day + i] == true)
//                        flag = false;
//                }
//                if (flag == true)
//                    units.Add(unit);
//                flag = true;
//            }
//            return units;
//        }
//        public double dayPast(DateTime date1, DateTime? date2 = null)
//        {
//            if (date2 != null)
//                return (date2 - date1).Value.TotalDays;
//            return (DateTime.Today.Date - date1).TotalDays;
//        }
//        public IEnumerable<Order> orderDay(double numDay)
//        {
//            return from ord in DataSource.order
//                   where ((DateTime.Today.Date - ord.CreateDate).TotalDays) >= numDay
//                   select ord.Clone();
//        }
//        public IEnumerable<GuestRequest> request(Predicate<GuestRequest> cond)
//        //public IEnumerable<GuestRequest> request(conditionDelegate cond)
//        {
//            return from gst in DataSource.guestRequest
//                   where cond(gst)
//                   select gst.Clone();
//        }
//        public long numOfOrder(GuestRequest x)
//        {
//            long num = 0;
//            foreach (var item in AllOrder())
//            {
//                if (item.GuestRequestKey == x.GuestRequestKey)
//                    num++;
//            }
//            return num;
//        }
//        public int numOfCloseOrder(HostingUnit x)
//        {
//            bool check = true;
//            int num = 0;
//            for (int i = 0; i < 12; ++i)
//            {//Prints busy dates
//                int numOfDay = DateTime.DaysInMonth(2020, i + 1);
//                for (int j = 0; j < numOfDay; ++j)
//                {
//                    if (x.Diary[i, j] == true && check == true)
//                    {
//                        check = false;
//                    }
//                    if (x.Diary[i, j] == false && check == false)
//                    {
//                        check = true;
//                        num++;
//                    }
//                }
//            }
//            return num;
//        }
//        public int sumOfPeople(Order o)
//        {
//            long l = o.GuestRequestKey;
//            GuestRequest g = getGuestRequest(l);
//            return g.Adults + g.Children;
//        }
//        #endregion

//        #region Lists
//        public List<BankBranch> AllBankBranch()
//        {
//            Thread configTread = new Thread(bank);
//            configTread.Start();
//            List<BankBranch> bankBranch = new List<BankBranch>();
//            bankBranch.Add(new BankBranch { BankName = "poalim", BankNumber = 11, BranchNumber = 290, BranchAddress = "bet hadfos", BranchCity = "jerusalem" });
//            bankBranch.Add(new BankBranch { BankName = "poalim", BankNumber = 11, BranchNumber = 290, BranchAddress = "bet hadfos", BranchCity = "jerusalem" });
//            bankBranch.Add(new BankBranch { BankName = "poalim", BankNumber = 11, BranchNumber = 290, BranchAddress = "bet hadfos", BranchCity = "jerusalem" });
//            bankBranch.Add(new BankBranch { BankName = "poalim", BankNumber = 11, BranchNumber = 290, BranchAddress = "bet hadfos", BranchCity = "jerusalem" });
//            bankBranch.Add(new BankBranch { BankName = "poalim", BankNumber = 11, BranchNumber = 290, BranchAddress = "bet hadfos", BranchCity = "jerusalem" });
//            return bankBranch;
//        }

//        public IEnumerable<GuestRequest> AllGuestRequest(Func<GuestRequest, bool> predicat = null)
//        {
//            if (predicat == null)
//            {
//                return from item in guestRequestRoot.Elements()
//                       select ConvertGuestRequest(item);
//            }

//            return from item in guestRequestRoot.Elements()
//                   let s = ConvertGuestRequest(item)
//                   where predicat(s)
//                   select s;
//        }

//        public IEnumerable<HostingUnit> AllHostingUnit(Func<HostingUnit, bool> predicat = null)
//        {
//            if (predicat == null)
//            {

//                return from item in hostingUnitRoot.Elements()
//                       select ConvertHostingUnit(item);
//            }

//            return from item in hostingUnitRoot.Elements()
//                   let s = ConvertHostingUnit(item)
//                   where predicat(s)
//                   select s;
//        }

//        public IEnumerable<Order> AllOrder(Func<Order, bool> predicat = null)
//        {
//            if (predicat == null)
//            {

//                return from item in orderRoot.Elements()
//                       select ConvertOrder(item);
//            }

//            return from item in orderRoot.Elements()
//                   let s = ConvertOrder(item)
//                   where predicat(s)
//                   select s;
//        }

//        public IEnumerable<GuestRequest> TheGuestRequest(long key)
//        {
//            return from guest in DataSource.guestRequest
//                   where guest.GuestRequestKey == key
//                   select guest.Clone();
//        }

//        public IEnumerable<HostingUnit> TheHostingUnit(long key)
//        {
//            return from unit in DataSource.hostingUnit
//                   where unit.HostingUnitKey == key
//                   select unit.Clone();
//        }

//        public IEnumerable<Order> TheOrder(long key)
//        {
//            return from ord in DataSource.order
//                   where ord.OrderKey == key
//                   select ord.Clone();
//        }
//        #endregion

//        #region Grouping
//        public IEnumerable<IGrouping<Area, GuestRequest>> GuestRequestByArea()
//        {
//            return from g in DataSource.guestRequest
//                   group g by g.area;
//        }
//        public IEnumerable<IGrouping<int, GuestRequest>> GuestRequestByNumOfGuest()
//        {
//            return from g in DataSource.guestRequest
//                   group g by (g.Adults + g.Children);
//        }
//        public IEnumerable<IGrouping<Host, HostingUnit>> HostByNumOfHostingUnits()
//        {
//            return from h in DataSource.hostingUnit
//                   group h by h.Owner;
//        }
//        public IEnumerable<IGrouping<Area, HostingUnit>> HostingUnitByArea()
//        {
//            return from h in DataSource.hostingUnit
//                   group h by h.areaHostingUnit;
//        }

//        public IEnumerable<Order> AllOrder()
//        {
//            return from o in
//                }

//        public IEnumerable<HostingUnit> AllHostingUnit()
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<GuestRequest> AllGuestRequest()
//        {
//            throw new NotImplementedException();
//        }

//        #endregion
//    }
//}

