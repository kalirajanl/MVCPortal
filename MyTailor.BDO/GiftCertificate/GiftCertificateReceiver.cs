using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using MyTailor.BDO.Common;
using MyTailor.BDO.Masters;

namespace MyTailor.BDO.Orders
{
    public class GiftCertificateReceiver
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleInitials { get; set; }
        public string EmailID { get; set; }
        public double Amount { get; set; }
        public AddressData Address { get; set; }
        public string Message { get; set; }
    }
}
