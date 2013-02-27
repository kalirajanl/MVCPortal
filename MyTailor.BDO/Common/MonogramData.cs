using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using MyTailor.BDO.Common;
using MyTailor.BDO.Masters;

namespace MyTailor.BDO.Common
{
    public class MonogramData
    {
        public MonogramTypes MonogramType { get; set; }
        public string InitialFName {get;set;}
        public string InitialMName { get; set; }
        public string InitialLName { get; set; }
        public string MonogramNotes { get; set; }
    }
}
