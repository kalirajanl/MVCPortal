using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using MyTailor.BDO.Common;
using MyTailor.BDO.Masters;
using MyTailor.BDO.Customers;

namespace MyTailor.BDO.Orders
{
    public class OrderHeader : OrderListItem 
    {

        public OrderHeader()
        {
            OrderMaterials = new List<OrderMaterialItem>();
        }

        public OrderCustomer Customer { get; set; }
        public string StyleSummary { get; set; }
        public List<OrderMaterialItem> OrderMaterials { get; set; }
        public OrderMeasurement MeasurementDetails { get; set; }
        public OrderPayment Payments { get; set; }
        public OrderFinishedSize FinishedSize { get; set; }

        public void initOrderNumber()
        {
            this.OrderID = Guid.NewGuid();
            this.OrderNumber = DateTime.Now.ToString("MMddHHss");
            this.OrderTakenDate = DateTime.Today;
            this.AssignedSalesMan = new SalesMan();
        }
    }
}
