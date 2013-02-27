using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTailor.BDO.Customers
{
    public class OrderCustomer
    {
        public Guid CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MInitials { get; set; }
        public string Title { get; set; }
        public string DisplayName { get; set; }
    }
}
