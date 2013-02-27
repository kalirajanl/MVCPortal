using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyTailor.BDO.Common
{
    public class CreditCardData
    {
        [Display(Name = "Card Name")]
        public string CardName { get; set; }

        [Display(Name = "Card No.")]
        public string CardNumber { get; set; }

        [Display(Name = "Expires On")]
        [DisplayFormat(DataFormatString = "{0:MMM/yy}",NullDisplayText="")]
        public DateTime CardExpiryDate { get; set; }
    }
}
