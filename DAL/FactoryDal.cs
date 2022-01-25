using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class FactoryDal
    {
        static Idal dal = null;
        public static Idal GetDal()
        {
            if (dal == null)
                dal = new DalImp();
            return dal;
        }
    }

}

