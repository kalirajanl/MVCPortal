using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;

using GSR.Common.DataAccess;
using MyTailor.DAL.Masters;
using MyTailor.BDO.Common;
using MyTailor.BDO.Orders;
using MyTailor.BDO.Masters;
using MyTailor.BDO.Customers;

namespace MyTailor.DAL.Customers
{
    public class CustomerDAL
    {

        public static List<OrderCustomer> GetCustomers()
        {
            List<OrderCustomer> customers = new List<OrderCustomer>();
            DataTable dt = SQLWrapper.GetDataTable("CST_GetCustomers");
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                customers.Add(loadOrderCustomer(dt.Rows[i]));
            }
            return customers;
        }

        public static OrderCustomer GetOrderCustomerByID(Guid customerID)
        {
            OrderCustomer itm = null;
            SqlParameter[] param = 
            {               
                new SqlParameter("CustomerID",typeof(Guid))
            };
            param[0].Value = customerID;
            DataTable dt = SQLWrapper.GetDataTable("CST_GetCustomer",0, param);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    itm = loadOrderCustomer(dt.Rows[0]);
                }
            }
            return itm;
        }

        #region Private Members

        private static OrderCustomer loadOrderCustomer(DataRow dr)
        {
            OrderCustomer itm = new OrderCustomer();
            itm.CustomerID = (Guid)dr["CustomerID"];
            itm.FirstName = dr["FirstName"].ToString();
            itm.LastName = dr["LastName"].ToString();
            itm.MInitials = dr["MInitials"].ToString();
            itm.Title = dr["Title"].ToString();
            itm.DisplayName = dr["DisplayName"].ToString();
            return itm;
        }

        #endregion
    }
}
