using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using MyTailor.BDO.Customers;
using MyTailor.DAL.Customers;

namespace MyTailor.Logic.Customers
{
    public class CustomerLogic
    {
        public static List<OrderCustomer> GetCustomers()
        {
            return CustomerDAL.GetCustomers();
        }

        public static OrderCustomer GetOrderCustomerByID(Guid customerID)
        {
            return CustomerDAL.GetOrderCustomerByID(customerID);
        }
    }
}
