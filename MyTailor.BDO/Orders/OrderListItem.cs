using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using MyTailor.BDO.Common;
using MyTailor.BDO.Masters;
using MyTailor.BDO.Customers;

namespace MyTailor.BDO.Orders
{
    public class OrderListItem
    {
     
        public Guid OrderID { get; set; }
        [Display(Name="Order No.")]
        public string OrderNumber { get; set; }
        
        [Display(Name = "Order Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime OrderTakenDate { get; set; }

        public OrderOriginatedFrom OrderSource { get; set; } // to be loaded from OrderNumber. how?

        [Display(Name = "Amount in US$")]
        [DisplayFormat(DataFormatString = "{0:###,###,###0.00}")]
        public decimal OrderAmount { get; set; }
        
        [Display(Name = "Paid in US$")]
        [DisplayFormat(DataFormatString = "{0:###,###,###0.00}")]
        public decimal PaidAmount { get; set; }

        [Display(Name = "Balance in US$")]
        [DisplayFormat(DataFormatString = "{0:###,###,###0.00}")]
        public decimal BalanceAmount
        {
            get
            {
                return PaidAmount - OrderAmount;
            }

            private set { }
        }

        [Display(Name = "Uploaded On")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm tt}")]
        public DateTime UploadedDate { get; set; }

        [Display(Name = "Has Log")]
        public bool HasLog { get; set; }

        public int AssignedSalesManID { get; set; }
        public SalesMan AssignedSalesMan { get; set; }

        public CreditCardData CardDetails { get; set; }
    }

}
