using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTailor.BDO.Orders
{
    public class OrderFinishedSize
    {
        public List<OrderSizeItem> OrderFSJacketSize { get; set; }
        public List<OrderSizeItem> OrderFSSlackVestTopCoatSize { get; set; }
        public List<OrderSizeItem> OrderFSShirtSize { get; set; }
    }
}
