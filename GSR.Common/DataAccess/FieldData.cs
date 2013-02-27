using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;

using GSR.Common.Utils;

namespace GSR.Common.DataAccess
{
    public class FieldData
    {
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public SqlDbType FieldType { get; set; }
    }
}
