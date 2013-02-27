using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;

using GSR.Common.DataAccess;
using MyTailor.DAL.Masters;
using MyTailor.DAL.Customers;
using MyTailor.BDO.Common;
using MyTailor.BDO.Orders;
using MyTailor.BDO.Masters;
using MyTailor.BDO.Customers;

namespace MyTailor.DAL.Orders
{
    public class OrderMaterialsDAL
    {
        public static List<OrderMaterialItem> GetOrderMaterialsByOrderID(Guid orderID)
        {
            List<OrderMaterialItem> materiallist = new List<OrderMaterialItem>();
            SqlParameter[] param = 
            {               
                new SqlParameter("OrderID",typeof(Guid))
            };
            param[0].Value = orderID;
            DataTable dtPayments = SQLWrapper.GetDataTable("ORD_GetOrderMaterials", 0, param);
            if (dtPayments != null)
            {
                for (int i = 0; i <= dtPayments.Rows.Count - 1; i++)
                {
                    materiallist.Add(loadOrderMaterialItem(dtPayments.Rows[i]));
                }
            }
            return materiallist;
        }

        public static OrderMaterialItem GetOrderMaterialItemByOrderIDAndSequence(Guid orderID, int sequence)
        {
            OrderMaterialItem itm = null;
            SqlParameter[] param = 
            {               
                new SqlParameter("OrderID",typeof(Guid)),
                new SqlParameter("Sequence",typeof(Int32)),
            };
            param[0].Value = orderID;
            param[1].Value = sequence;
            DataTable dtPayments = SQLWrapper.GetDataTable("ORD_GetOrderMaterial", 0, param);
            if (dtPayments != null)
            {
                if (dtPayments.Rows.Count == 1)
                {
                    itm = loadOrderMaterialItem(dtPayments.Rows[0]);
                }
            }
            return itm;
        }

        public static bool AddOrderMaterial(Guid orderID, OrderMaterialItem itm, ref SQLWrapper sw)
        {
            bool returnValue = false;
            SqlParameter[] param = prepareParams(orderID, itm);
            returnValue = sw.ExecuteStoredProcedureInTransaction("ORD_AddUpdateOrderMaterial",param);
            return returnValue;
        }

        public static bool DeleteRestOfTheOrderMaterials(Guid orderID, string otherThanSequenceNumbers, ref SQLWrapper sw)
        {
            SqlParameter[] param =
            {
                new SqlParameter("OrderID",typeof(Guid )),
                new SqlParameter("Sequences",typeof(string )),
            };
            param[0].Value = orderID;
            param[1].Value = otherThanSequenceNumbers;
            return sw.ExecuteStoredProcedureInTransaction("ORD_DeleteOrderMaterials", param);
        }

        #region Private Members

        private static SqlParameter[] prepareParams(Guid orderID, OrderMaterialItem itm)
        {
            SqlParameter[] param = 
            {
                new SqlParameter("OrderID",typeof(Guid )),
                new SqlParameter("Sequence",typeof(Int32)),
                new SqlParameter("MaterialName",typeof(string)),
                new SqlParameter("MaterialDescription",typeof(string)),
                new SqlParameter("ItemType",typeof(Int32)),
                new SqlParameter("Quantity",typeof(Int32)),
                new SqlParameter("Price", typeof(decimal)),
                new SqlParameter("SubItem1Type",typeof(Int32)),
                new SqlParameter("SubItem1Name",typeof(string)),
                new SqlParameter("SubItem1Qty",typeof(Int32)),
                new SqlParameter("SubItem1Price", typeof(decimal)),
                new SqlParameter("SubItem2Type",typeof(Int32)),
                new SqlParameter("SubItem2Name",typeof(string)),
                new SqlParameter("SubItem2Qty",typeof(Int32)),
                new SqlParameter("SubItem2Price", typeof(decimal)),
                new SqlParameter("Yardage", typeof(decimal)),
                new SqlParameter("TailorID",typeof(Int32)),
                new SqlParameter("Color",typeof(string)),
                new SqlParameter("Pattern",typeof(string)),
                new SqlParameter("Category",typeof(string)),
                new SqlParameter("FabricWidth",typeof(Int32)),
                new SqlParameter("IncludeSlackHalfLining",typeof(bool)),
                new SqlParameter("IncludeSlackFullLining",typeof(bool)),
                new SqlParameter("IncludeRBHole",typeof(bool)),
                new SqlParameter("IncludeHSEdges",typeof(bool)),
                new SqlParameter("IncludeMono",typeof(bool)),
                new SqlParameter("IncludePB",typeof(bool)),
                new SqlParameter("IncludeWCC",typeof(bool)),
                new SqlParameter("IncludeWC",typeof(bool)),
                new SqlParameter("IncludeSS",typeof(bool)),
                new SqlParameter("IncludeFT",typeof(bool))
            };
            param[0].Value = orderID;
            param[1].Value = itm.Sequence;
            param[2].Value = itm.MaterialName;
            param[3].Value = itm.MaterialDescription;
            param[4].Value = Convert.ToInt32(itm.ItemDescription.OrderItemType);
            param[5].Value = itm.ItemDescription.OrderItemQuantity;
            param[6].Value = itm.UnitPrice;
            param[7].Value = Convert.ToInt32(itm.SubItem1Type);
            param[8].Value = itm.SubItem1;
            param[9].Value = Convert.ToInt32(itm.SubItem1Qty);
            param[10].Value = Convert.ToDecimal(itm.SubItem1Price);
            param[11].Value = Convert.ToInt32(itm.SubItem2Type);
            param[12].Value = itm.SubItem2;
            param[13].Value = Convert.ToInt32(itm.SubItem2Qty);
            param[14].Value = Convert.ToDecimal(itm.SubItem2Price);
            param[15].Value = Convert.ToDecimal(itm.Yardage);
            param[16].Value = itm.AssignedTailor.TailorID;
            param[17].Value = itm.Color;
            param[18].Value = itm.Pattern;
            param[19].Value = itm.Category;
            param[20].Value = Convert.ToInt32(itm.FabricWidth);
            param[21].Value = Convert.ToBoolean(itm.IncludeSlackHalfLining);
            param[22].Value = Convert.ToBoolean(itm.IncludeSlackFullLining);
            param[23].Value = Convert.ToBoolean(itm.IncludeRBHole);
            param[24].Value = Convert.ToBoolean(itm.IncludeHSEdges);
            param[25].Value = Convert.ToBoolean(itm.IncludeMono);
            param[26].Value = Convert.ToBoolean(itm.IncludePB);
            param[27].Value = Convert.ToBoolean(itm.IncludeWCC);
            param[28].Value = Convert.ToBoolean(itm.IncludeWC);
            param[29].Value = Convert.ToBoolean(itm.IncludeSS);
            param[30].Value = Convert.ToBoolean(itm.IncludeFT);
            return param;
        }

        private static OrderMaterialItem loadOrderMaterialItem(DataRow dr)
        {
            OrderMaterialItem itm = null;
            if (dr != null)
            {
                itm = new OrderMaterialItem();
                itm.AssignedTailor = TailorDAL.GetTailorByID(Convert.ToInt32(dr["TailorID"]));
                itm.ItemDescription = new ItemDescriptions();
                itm.ItemDescription.OrderItemQuantity = Convert.ToInt32(dr["Quantity"]);
                itm.ItemDescription.OrderItemType = (OrderItemTypes)Convert.ToInt32(dr["ItemType"]);
                itm.MaterialDescription = dr["MaterialDescription"].ToString();
                itm.MaterialName = dr["MaterialName"].ToString();
                itm.Sequence = getCharacterSequence(Convert.ToInt32(dr["Sequence"]));
                itm.SubItem1 = dr["SubItem1Name"].ToString();
                itm.SubItem1Price = Convert.ToDecimal(dr["SubItem1Price"]);
                itm.SubItem1Qty = Convert.ToInt32(dr["SubItem1Qty"]);
                itm.SubItem1Type = (SuitSubItemTypes)dr["SubItem1Type"];
                itm.SubItem2 = dr["SubItem2Name"].ToString();
                itm.SubItem2Price = Convert.ToDecimal(dr["SubItem2Price"]);
                itm.SubItem2Qty = Convert.ToInt32(dr["SubItem2Qty"]);
                itm.SubItem2Type = (SuitSubItemTypes)dr["SubItem2Type"];
                itm.UnitPrice = Convert.ToDecimal(dr["Price"]);
                itm.Yardage = Convert.ToDecimal(dr["Yardage"]);

                itm.Color = dr["Color"].ToString();
                itm.Pattern = dr["Pattern"].ToString();
                itm.Category = dr["Category"].ToString();
                itm.FabricWidth = (FabricWidths)Convert.ToInt32(dr["FabricWidth"]);
                itm.IncludeSlackHalfLining = Convert.ToBoolean(dr["IncludeSlackHalfLining"]);
                itm.IncludeSlackFullLining = Convert.ToBoolean(dr["IncludeSlackFullLining"]);
                itm.IncludeRBHole = Convert.ToBoolean(dr["IncludeRBHole"]);
                itm.IncludeHSEdges = Convert.ToBoolean(dr["IncludeHSEdges"]);
                itm.IncludeMono = Convert.ToBoolean(dr["IncludeMono"]);
                itm.IncludePB = Convert.ToBoolean(dr["IncludePB"]);
                itm.IncludeWCC = Convert.ToBoolean(dr["IncludeWCC"]);
                itm.IncludeWC = Convert.ToBoolean(dr["IncludeWC"]);
                itm.IncludeSS = Convert.ToBoolean(dr["IncludeSS"]);
                itm.IncludeFT = Convert.ToBoolean(dr["IncludeFT"]);

            }
            return itm;
        }

        private const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private static char getCharacterSequence(int index)
        {
            return Convert.ToChar(letters.Substring(index, 1));
        }

        private static int getCharacterSequenceNumber(char letter)
        {
            return letters.IndexOf(letter);
        }

        #endregion
    }
}
