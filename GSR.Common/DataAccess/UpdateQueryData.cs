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
    public class UpdateQueryData : IBaseQueryData
    {
        public string TableName { get; set; }
        public List<FieldData> Fields { get; set; }
        public List<FieldData> KeyFields { get; set; }

        public UpdateQueryData()
        {
            TableName = "";
            Fields = new List<FieldData>();
            KeyFields = new List<FieldData>();
        }

        public string GetSQL()
        {
            string cmdText = "";
            if ((!TableName.Trim().Equals("")) && (Fields.Count > 0) && (KeyFields.Count > 0))
            {
                cmdText = "UPDATE " + TableName + " SET ";

                for (int i = 0; i <= Fields.Count - 1; i++)
                {
                    cmdText += "[" + Fields[i].FieldName + "] = ";
                    cmdText += "'" + Fields[i].FieldValue.Replace("'", "''") + "'";
                    if (i <= Fields.Count - 2)
                    {
                        cmdText += ",";
                    }
                }
                cmdText += " WHERE ";
                for (int i = 0; i <= KeyFields.Count - 1; i++)
                {
                    cmdText += "[" + KeyFields[i].FieldName + "] = ";
                    cmdText += "'" + KeyFields[i].FieldValue.Replace("'", "''") + "'";
                    if (i <= KeyFields.Count - 2)
                    {
                        cmdText += " AND ";
                    }
                }
            }
            return cmdText;
        }
    }
}
