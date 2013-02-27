using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using MyTailor.BDO.Common;
using MyTailor.BDO.Masters;

namespace MyTailor.BDO.Orders
{

    public class OrderMeasurement
    {
        public List<OrderSizeItem> OrderMJacketSize { get; set; }
        public List<OrderSizeItem> OrderMSlackVestTopCoatSize { get; set; }
        public List<OrderSizeItem> OrderMShirtSize { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string OrderInstructions { get; set; }
    }
}
