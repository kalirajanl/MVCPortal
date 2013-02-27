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
    public interface IBaseQueryData
    {
        string TableName { get; set; }
        List<FieldData> Fields { get; set; }
        List<FieldData> KeyFields { get; set; }
        string GetSQL();
    }

}
