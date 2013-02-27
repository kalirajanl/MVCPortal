using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using MyTailor.BDO.Common;
using MyTailor.BDO.Masters;

namespace MyTailor.BDO.Orders
{
    public class ItemDescriptions
    {
        public OrderItemTypes OrderItemType { get; set; }
        public int OrderItemQuantity { get; set; }
        public string DisplayText
        {
            get
            {
                return OrderItemQuantity.ToString() + " " + OrderItemType.ToString();
            }
            private set
            {
            }
        }
    }
}
