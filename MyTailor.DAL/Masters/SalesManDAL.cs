using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using MyTailor.BDO.Masters;

namespace MyTailor.DAL.Masters
{
    public class SalesManDAL
    {
        public static List<SalesMan> GetSalesMen(SalesMan filterData = null)
        {
            List<SalesMan> salesMen = getSalesMenList();
            if (filterData != null)
            {
                return salesMen.FindAll(sm =>
                    sm.FirstName.StartsWith(filterData.FirstName) &&
                    sm.LastName.StartsWith(filterData.LastName) &&
                    sm.Initials.StartsWith(filterData.Initials)
                    );//.OrderBy(sm => sm.Initials).ThenBy(sm => sm.LastName).ThenBy(sm => sm.FirstName);
            }
            return salesMen;
        }

        public static SalesMan GetSalesManByID(int ID)
        {
            List<SalesMan> salesMen = getSalesMenList();
            return salesMen.Find(sm => sm.SalesManID == ID);
        }

        #region Private Members

        private static List<SalesMan> getSalesMenList()
        {
            List<SalesMan> salesMen = new List<SalesMan>();
            salesMen.Add(new SalesMan { SalesManID = 1, Initials = "AK", FirstName = "Alberto", LastName = "Khem", CommissionPercentage = 20, IsActive = true });
            salesMen.Add(new SalesMan { SalesManID = 2, Initials = "AL", FirstName = "Andre", LastName = "Lani", CommissionPercentage = 25, IsActive = true });
            salesMen.Add(new SalesMan { SalesManID = 3, Initials = "D", FirstName = "Direct", LastName = "Visiting Customers", CommissionPercentage = 0, IsActive = true });
            salesMen.Add(new SalesMan { SalesManID = 4, Initials = "DH", FirstName = "L", LastName = "H Bob", CommissionPercentage = 20, IsActive = true });
            salesMen.Add(new SalesMan { SalesManID = 5, Initials = "GS", FirstName = "MyTailor.Com", LastName = "Rep", CommissionPercentage = 0, IsActive = true });
            salesMen.Add(new SalesMan { SalesManID = 6, Initials = "H", FirstName = "H", LastName = "H", CommissionPercentage = 0, IsActive = true });
            salesMen.Add(new SalesMan { SalesManID = 7, Initials = "JGH", FirstName = "Joe", LastName = "Hemrajani", CommissionPercentage = 0, IsActive = true });
            salesMen.Add(new SalesMan { SalesManID = 8, Initials = "JOE", FirstName = "Joe", LastName = "Hemrajani", CommissionPercentage = 3, IsActive = true });
            salesMen.Add(new SalesMan { SalesManID = 9, Initials = "JOE_H", FirstName = "Joe", LastName = "Hemrajani", CommissionPercentage = 0, IsActive = true });
            salesMen.Add(new SalesMan { SalesManID = 10, Initials = "KD", FirstName = "Ken", LastName = "Daswani", CommissionPercentage = 25, IsActive = true });
            salesMen.Add(new SalesMan { SalesManID = 11, Initials = "KK", FirstName = "Kenny", LastName = "Keswani", CommissionPercentage = 25, IsActive = true });
            salesMen.Add(new SalesMan { SalesManID = 12, Initials = "McK", FirstName = "", LastName = "", CommissionPercentage = 20, IsActive = false });
            salesMen.Add(new SalesMan { SalesManID = 13, Initials = "MK", FirstName = "M", LastName = "Kenny", CommissionPercentage = 25, IsActive = true });
            salesMen.Add(new SalesMan { SalesManID = 14, Initials = "MS", FirstName = "M.", LastName = "Sam", CommissionPercentage = 20, IsActive = true });
            salesMen.Add(new SalesMan { SalesManID = 15, Initials = "NC", FirstName = "Nick", LastName = "Chotrani", CommissionPercentage = 25, IsActive = true });
            salesMen.Add(new SalesMan { SalesManID = 16, Initials = "PM", FirstName = "Pierre", LastName = "Mohan", CommissionPercentage = 25, IsActive = true });
            salesMen.Add(new SalesMan { SalesManID = 17, Initials = "REPL", FirstName = "Albert", LastName = "Hemrajani", CommissionPercentage = 0, IsActive = true });
            salesMen.Add(new SalesMan { SalesManID = 18, Initials = "RK", FirstName = "Ram", LastName = "Keswani", CommissionPercentage = 25, IsActive = true });
            salesMen.Add(new SalesMan { SalesManID = 19, Initials = "RN", FirstName = "N", LastName = "Rusty", CommissionPercentage = 20, IsActive = true });
            salesMen.Add(new SalesMan { SalesManID = 20, Initials = "S", FirstName = "Sample", LastName = "Rusty", CommissionPercentage = 0, IsActive = true });
            return salesMen;
        }

        #endregion

    }
}
