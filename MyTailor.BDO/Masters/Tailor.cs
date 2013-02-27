using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using MyTailor.BDO.Common;
using MyTailor.BDO.Masters;

namespace MyTailor.BDO.Masters
{
    public class Tailor
    {
        public int TailorID { get; set; }
        public string TailorCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public AddressData Address { get; set; }
        public string PaymentTerms { get; set; }
        public string WorkPhone1 { get; set; }
        public string WorkPhone2 { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }
        public string Notes { get; set; }
        public List<TailorChargeItem> TailoringCharges { get; set; }
        public List<TailorAddOnChargeItem> AddOnCharges { get; set; }
    }

    public class TailorChargeItem
    {
        public OrderItemTypes OrderItemType { get; set; }
        public double TailoringCharge { get; set; }
    }

    public class TailorAddOnChargeItem : TailorChargeItem
    {
        public string AddOnItem { get; set; }
    }
}
