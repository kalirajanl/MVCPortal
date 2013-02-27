using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using MyTailor.BDO.Common;
using MyTailor.BDO.Masters;

namespace MyTailor.BDO.Masters
{
    public class SalesMan
    {
        public int SalesManID { get; set; }

        [Display(Name="SalesMan")]
        public string Initials { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double CommissionPercentage { get; set; }
        public bool IsActive { get; set; }
        public AddressData Address { get; set; }
        public string EmailID { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }
        public string AreaAssigned { get; set; }
        public string Notes { get; set; }
    }
}
