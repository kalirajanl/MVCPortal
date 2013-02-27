using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using MyTailor.BDO.Common;
using MyTailor.BDO.Masters;

namespace MyTailor.BDO.Orders
{

    public class IOrderPaymentItem
    {
        public virtual DateTime PaymentDate { get; set; }
        public virtual OrderPaymentTypes PaymentType { get; set; }
        public virtual Int32 Sequence { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual string PaymentRemarks { get; set; }
    }

    public class OrderPaymentItem : IOrderPaymentItem
    {
        public OrderPaymentItem()
        {
            PaymentType = OrderPaymentTypes.Cash;
        }

        public override DateTime PaymentDate { get; set; }
        public override OrderPaymentTypes PaymentType { get; set; }
        public override Int32 Sequence { get; set; }
        public override decimal Amount { get; set; }
        public override string PaymentRemarks { get; set; }
    }

    public class CreditCardPayment : OrderPaymentItem
    {
        public CreditCardPayment()
        {
            PaymentType = OrderPaymentTypes.CreditCard;
        }

        public CreditCardData CCInfo { get; set; }
    }

    public class CheckPayment : OrderPaymentItem
    {
        public CheckPayment()
        {
            PaymentType = OrderPaymentTypes.Check;
        }

        public CheckData ChkInfo { get; set; }
    }

    public class GiftCertificatePayment : OrderPaymentItem
    {
        public GiftCertificatePayment()
        {
            PaymentType = OrderPaymentTypes.GiftCertificate;
        }

        public GiftCertificateData GCInfo { get; set; }
    }
}
