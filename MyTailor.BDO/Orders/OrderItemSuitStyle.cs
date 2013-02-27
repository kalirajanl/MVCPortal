using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTailor.BDO.Orders
{
    public class OrderItemSuitStyle
    {
        public OrderItemJacketStyle JacketStyle { get; set; }
        public OrderItemSlackStyle SlackStyle { get; set; }
        public OrderItemVestStyle VestStyle { get; set; }
        public string BeltWidth { get; set; }
    }
}
