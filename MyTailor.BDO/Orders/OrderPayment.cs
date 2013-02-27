using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using MyTailor.BDO.Common;
using MyTailor.BDO.Masters;

namespace MyTailor.BDO.Orders
{
    public class OrderPayment
    {
        public decimal TotalItemPrice { get; set; }
        public decimal Shipping { get; set; }
        public decimal Duty { get; set; }
        public decimal OtherCharges { get; set; }
        public string OtherChargesCaption { get; set; }
        public decimal Discount { get; set; }
        public decimal TaxPercentage { get; set; }
        public List<IOrderPaymentItem> PaymentDetails { get; set; }
        public ShipmentTypes ShipmentType { get; set; }
        public OrderTypes OrderType { get; set; }
        public string ShippingInstructions { get; set; }
        public string Notes { get; set; }

        #region Derived Members

        public decimal Tax
        {
            get
            {
                return Math.Round(TotalItemPrice  * TaxPercentage / 100, 2, MidpointRounding.AwayFromZero);
            }
            private set { }
        }

        public decimal GrandTotal
        {
            get
            {
                return TotalItemPrice + Tax + OtherCharges-Discount;
            }
            private set { }
        }

        public decimal TotalPaidAmount
        {
            get
            {
                decimal totalAmount = 0;
                if (PaymentDetails != null)
                {
                    foreach (IOrderPaymentItem itm in PaymentDetails)
                    {
                        totalAmount += itm.Amount;
                    }
                }
                return totalAmount;
            }
            private set { }
        }

        public decimal BalanceAmount
        {
            get
            {
                return GrandTotal - TotalPaidAmount;
            }
            private set { }
        }

        #endregion

    }
}
