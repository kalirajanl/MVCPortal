using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using MyTailor.BDO.Common;
using MyTailor.BDO.Masters;

namespace MyTailor.BDO.Orders
{
    public class GiftCertificate
    {
        public Guid GiftCertificateID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleInitials { get; set; }
        public string EmailID { get; set; }
        public Guid CustomerID { get; set; }
        public AddressData Address { get; set; }
        public List<GiftCertificateReceiver> Receivers { get; set; }
        public IOrderPaymentItem Payment { get; set; }

        public double TotalAmount
        {
            get
            {
                double totalAmount = 0;
                if (Receivers != null)
                {
                    foreach (GiftCertificateReceiver itm in Receivers)
                    {
                        totalAmount += itm.Amount;
                    }
                }
                return totalAmount;
            }
            private set { }
        }

    }
}
