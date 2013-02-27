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
    public class OrderSizeDAL
    {
        public static OrderFinishedSize GetOrderFinishedSizes(Guid orderID)
        {
            OrderFinishedSize fs = null;
            SqlParameter[] param = 
            {               
                new SqlParameter("OrderID",typeof(Guid))
            };
            param[0].Value = orderID;
            DataTable dtFS = SQLWrapper.GetDataTable("ORD_GetOrderSizes", 0, param);
            if (dtFS != null)
            {
                fs = loadOrderFinishedSize(dtFS);
            }
            return fs;
        }

        public static bool UpdateOrderFinishedSizes(Guid orderID, OrderFinishedSize itm)
        {
            bool returnValue = false;
            SQLWrapper sw = new SQLWrapper();
            sw.BeginTransaction();
            try
            {
                UpdateOrderFinishedSizes(orderID, itm, ref sw);
                sw.CommitTransaction();
                returnValue = true;
            }
            catch
            {
                sw.RollBackTransaction();
            }
            finally
            {
                sw = null;
            }
            return returnValue;
        }

        public static bool UpdateOrderFinishedSizes(Guid orderID, OrderFinishedSize itm, ref SQLWrapper sw)
        {
            bool returnValue = false;
            SqlParameter[] param =
            {
                new SqlParameter("OrderID",typeof(Guid))
            };
            param[0].Value = orderID;
            sw.ExecuteStoredProcedureInTransaction("ORD_DeleteOrderFinishedSizes", param);
            if (itm.OrderFSJacketSize != null)
            {
                for (int i = 0; i <= itm.OrderFSJacketSize.Count - 1; i++)
                {
                    param = prepareParams(orderID, 4, itm.OrderFSJacketSize[i]);
                    sw.ExecuteStoredProcedureInTransaction("ORD_AddOrderSize", param);
                }
            }
            if (itm.OrderFSSlackVestTopCoatSize != null)
            {
                for (int i = 0; i <= itm.OrderFSSlackVestTopCoatSize.Count - 1; i++)
                {
                    param = prepareParams(orderID, 5, itm.OrderFSSlackVestTopCoatSize[i]);
                    sw.ExecuteStoredProcedureInTransaction("ORD_AddOrderSize", param);
                }
            }
            if (itm.OrderFSShirtSize != null)
            {
                for (int i = 0; i <= itm.OrderFSShirtSize.Count - 1; i++)
                {
                    param = prepareParams(orderID, 6, itm.OrderFSShirtSize[i]);
                    sw.ExecuteStoredProcedureInTransaction("ORD_AddOrderSize", param);
                }
            }
            return returnValue;
        }

         public static bool UpdateOrderMeasurementSizes(Guid orderID, OrderMeasurement itm)
        {
            bool returnValue = false;
            SQLWrapper sw = new SQLWrapper();
            sw.BeginTransaction();
            try
            {
                UpdateOrderMeasurementSizes(orderID, itm, ref sw);
                sw.CommitTransaction();
                returnValue = true;
            }
            catch
            {
                sw.RollBackTransaction();
            }
            finally
            {
                sw = null;
            }
            return returnValue;
        }

         public static bool UpdateOrderMeasurementSizes(Guid orderID, OrderMeasurement itm, ref SQLWrapper sw)
         {
             bool returnValue = false;
             SqlParameter[] param =
            {
                new SqlParameter("OrderID",typeof(Guid))
            };
             param[0].Value = orderID;
             sw.ExecuteStoredProcedureInTransaction("ORD_DeleteOrderMeasureSizes", param);
             if (itm.OrderMJacketSize != null)
             {
                 for (int i = 0; i <= itm.OrderMJacketSize.Count - 1; i++)
                 {
                     param = prepareParams(orderID, 1, itm.OrderMJacketSize[i]);
                     sw.ExecuteStoredProcedureInTransaction("ORD_AddOrderSize", param);
                 }
             }
             if (itm.OrderMSlackVestTopCoatSize != null)
             {
                 for (int i = 0; i <= itm.OrderMSlackVestTopCoatSize.Count - 1; i++)
                 {
                     param = prepareParams(orderID, 2, itm.OrderMSlackVestTopCoatSize[i]);
                     sw.ExecuteStoredProcedureInTransaction("ORD_AddOrderSize", param);
                 }
             }
             if (itm.OrderMShirtSize != null)
             {
                 for (int i = 0; i <= itm.OrderMShirtSize.Count - 1; i++)
                 {
                     param = prepareParams(orderID, 3, itm.OrderMShirtSize[i]);
                     sw.ExecuteStoredProcedureInTransaction("ORD_AddOrderSize", param);
                 }
             }
             return returnValue;
         }
        
        public static void LoadOrderMeasurementSizes(Guid orderID, ref OrderHeader order)
        {
            SqlParameter[] param = 
            {               
                new SqlParameter("OrderID",typeof(Guid))
            };
            param[0].Value = orderID;
            DataTable dtFS = SQLWrapper.GetDataTable("ORD_GetOrderSizes", 0, param);
            if (dtFS != null)
            {
                order.MeasurementDetails.OrderMJacketSize = getOrderSizes(dtFS, Convert.ToInt32(TypeOfSizes.OrderMeasurementJacketSize));
                order.MeasurementDetails.OrderMShirtSize = getOrderSizes(dtFS, Convert.ToInt32(TypeOfSizes.OrderMeasurementShirtSize));
                order.MeasurementDetails.OrderMSlackVestTopCoatSize = getOrderSizes(dtFS, Convert.ToInt32(TypeOfSizes.OrderMeasurementSlackVestTopCoatSize));
            }
        }


        #region Private Members


        private static SqlParameter[] prepareParams(Guid orderID, int typeOfSize, OrderSizeItem itm)
        {
            SqlParameter[] param = 
            {
                new SqlParameter("OrderID",typeof(Guid)),
                new SqlParameter("TypeOfSize",typeof(Int32)),
                new SqlParameter("Caption",typeof(string)),
                new SqlParameter("Value",typeof(string)),
                new SqlParameter("Sequence",typeof(Int32))
            };
            param[0].Value = orderID;
            param[1].Value = typeOfSize;
            param[2].Value = itm.Caption;
            param[3].Value = itm.Value;
            param[4].Value = itm.Sequence;
            return param;
        }

        private static OrderFinishedSize loadOrderFinishedSize(DataTable dtFS)
        {
            OrderFinishedSize fs = new OrderFinishedSize();
            fs.OrderFSJacketSize = getOrderSizes(dtFS, Convert.ToInt32(TypeOfSizes.OrderFinishedJacketSize));
            fs.OrderFSShirtSize = getOrderSizes(dtFS, Convert.ToInt32(TypeOfSizes.OrderFinishedShirtSize));
            fs.OrderFSSlackVestTopCoatSize = getOrderSizes(dtFS, Convert.ToInt32(TypeOfSizes.OrderFinishedSlackVestTopCoatSize));
            return fs;
        }

        private static List<OrderSizeItem> getOrderSizes(DataTable dtFS, int sizeType)
        {
            List<OrderSizeItem> sizeItem = new List<OrderSizeItem>();

            DataView dv = dtFS.DefaultView;
            dv.RowFilter = "TypeOfSize = " + sizeType.ToString();
            dv.Sort = "Sequence";
            for (int i = 0; i <= dv.Count - 1; i++)
            {
                OrderSizeItem itm = new OrderSizeItem();
                itm.Sequence = Convert.ToInt32(dv[i]["Sequence"]);
                itm.Caption = dv[i]["Caption"].ToString();
                itm.Value = dv[i]["Value"].ToString();
                sizeItem.Add(itm);
                itm = null;
            }

            return sizeItem;
        }

        #endregion
    }
}
