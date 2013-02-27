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
    public class SelectQueryData
    {
        public SelectQueryData()
        {
            FieldNames = "*";
            FilterCondition = "";
            OrderBy = "";
            GroupBy = "";
        }

        public string TableName { get; set; }
        public string FieldNames { get; set; }
        public string FilterCondition { get; set; }
        public string OrderBy { get; set; }
        public string GroupBy { get; set; }

        public string GetSQL()
        {
            string cmdText = "";
            cmdText = "Select " + FieldNames + " From [" + TableName + "]";
            if (!FilterCondition.Trim().Equals(""))
            {
                cmdText += " Where " + FilterCondition;
            }
            if (!GroupBy.Trim().Equals(""))
            {
                cmdText += " Group By " + GroupBy;
            }
            if (!OrderBy.Trim().Equals(""))
            {
                cmdText += " Order By " + OrderBy;
            }
            return cmdText;
        }
    }
}
