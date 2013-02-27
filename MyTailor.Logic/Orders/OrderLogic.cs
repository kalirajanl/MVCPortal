using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using MyTailor.BDO.Orders;
using MyTailor.DAL.Orders;

namespace MyTailor.Logic.Orders
{
    public class OrderLogic
    {
        public static List<OrderListItem> GetOrdersList()
        {
            return OrderDAL.GetOrdersList();
        }

        public static OrderHeader GetOrderByID(Guid orderID)
        {
            return OrderDAL.GetOrderByID(orderID);
        }
        public static bool AddOrder(OrderHeader order)
        {
            return OrderDAL.AddOrder(order);
        }

        public static bool UpdateOrder(OrderHeader order)
        {
            return OrderDAL.UpdateOrder(order);
        }

        public static bool DeleteOrder(OrderHeader orderID)
        {
            return OrderDAL.DeleteOrder(orderID);
        }
    }
}
