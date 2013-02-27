using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using MyTailor.BDO.Masters;
using MyTailor.DAL.Masters;

namespace MyTailor.Logic.Masters
{
    public class SalesManLogic
    {
        public static List<SalesMan> GetSalesMen(SalesMan filterData = null)
        {
            return SalesManDAL.GetSalesMen(filterData);
        }

        public static SalesMan GetSalesManByID(int ID)
        {
            return SalesManDAL.GetSalesManByID(ID);
        }
    }
}
