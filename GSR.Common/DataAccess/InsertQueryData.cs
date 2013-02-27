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
    public class InsertQueryData : IBaseQueryData
    {

        public string TableName { get; set; }
        public List<FieldData> Fields { get; set; }
        public List<FieldData> KeyFields { get; set; }

        public InsertQueryData()
        {
            TableName = "";
            Fields = new List<FieldData>();
            KeyFields = null;
        }

        public string GetSQL()
        {
            string cmdText = "";
            if ((!TableName.Trim().Equals("")) && (Fields.Count > 0))
            {
                cmdText = "INSERT " + TableName + "(";

                for (int i = 0; i <= Fields.Count - 1; i++)
                {
                    cmdText += "[" + Fields[i].FieldName + "]";
                    if (i <= Fields.Count - 2)
                    {
                        cmdText += ",";
                    }
                }
                cmdText += ") Values (";
                for (int i = 0; i <= Fields.Count - 1; i++)
                {
                    cmdText += "'" + Fields[i].FieldValue.Replace("'", "''") + "'";
                    if (i <= Fields.Count - 2)
                    {
                        cmdText += ",";
                    }
                }
                cmdText += ")";
            }
            return cmdText;
        }
    }
}
