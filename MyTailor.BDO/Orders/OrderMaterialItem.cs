using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using MyTailor.BDO.Common;
using MyTailor.BDO.Masters;

namespace MyTailor.BDO.Orders
{
    public class OrderMaterialItem 
    {

        public OrderMaterialItem()
        {
            ItemDescription = new ItemDescriptions();
            AssignedTailor = new Tailor();
        }

        public char Sequence { get; set; }

        public string MaterialName { get; set; }
        public string MaterialDescription { get; set; }
        public ItemDescriptions ItemDescription { get; set; }
        public string SubItem1 { get; set; }
        public SuitSubItemTypes SubItem1Type { get; set; }
        public double SubItem1Qty { get; set; }
        public decimal SubItem1Price { get; set; }
        public string SubItem2 { get; set; }
        public SuitSubItemTypes SubItem2Type { get; set; }
        public double SubItem2Qty { get; set; }
        public decimal SubItem2Price { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Yardage { get; set; }
        public Tailor AssignedTailor { get; set; }

        public decimal MaterialPrice
        {
            get
            {
                return Math.Round(ItemDescription.OrderItemQuantity * UnitPrice, 2, MidpointRounding.AwayFromZero);
            }
            private set { }
        }

        public string Color { get; set; } // should this be a link to MCA Color?
        public string Pattern { get; set; } // should this be a link to MCA Pattern?
        public string Category { get; set; } // should this be a link to MCA Category?
        public FabricWidths FabricWidth { get; set; }

        public bool IncludeSlackHalfLining { get; set; }
        public bool IncludeSlackFullLining { get; set; }
        public bool IncludeRBHole { get; set; }
        public bool IncludeHSEdges { get; set; }
        public bool IncludeMono { get; set; }
        public bool IncludePB { get; set; }
        public bool IncludeWCC { get; set; }
        public bool IncludeWC { get; set; }
        public bool IncludeSS { get; set; }
        public bool IncludeFT { get; set; }
    }
}
