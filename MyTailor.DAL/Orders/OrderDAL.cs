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
    public class OrderDAL
    {
        public static List<OrderListItem> GetOrdersList()
        {
            List<OrderListItem> orders = new List<OrderListItem>();
            DataTable dt = SQLWrapper.GetDataTable("ORD_GetOrders");
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                orders.Add(loadOrderListItem(dt.Rows[i]));
            }
            return orders;
        }

        public static OrderHeader GetOrderByID(Guid orderID)
        {
            OrderHeader itm = null;
            SqlParameter[] param = 
            {               
                new SqlParameter("OrderID",typeof(Guid))
            };
            param[0].Value = orderID;
            DataSet ds = SQLWrapper.GetDataSet("ORD_GetOrder", param);
            itm = loadOrderHeader(ds);
            return itm;
        }

        public static bool AddOrder(OrderHeader order)
        {
            bool returnValue = false;
            SqlParameter[] param;
            SQLWrapper sw = new SQLWrapper();
            sw.BeginTransaction();
            try
            {
                param = prepareSQLParameters(order, true);
                sw.ExecuteStoredProcedureInTransaction("ORD_AddOrderHeader", param);
                order.OrderID = (Guid)param[0].Value;

                addUpdateChildTablesForOrder(order, ref sw);

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

        public static bool UpdateOrder(OrderHeader order)
        {
            bool returnValue = false;
            SqlParameter[] param;
            SQLWrapper sw = new SQLWrapper();
            sw.BeginTransaction();
            try
            {
                param = prepareSQLParameters(order, false);
                sw.ExecuteStoredProcedureInTransaction("ORD_UpdateOrderHeader", param);

                addUpdateChildTablesForOrder(order, ref sw);

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

        public static bool DeleteOrder(OrderHeader orderID)
        {
            bool returnValue = false;
            SQLWrapper sw = new SQLWrapper();
            sw.BeginTransaction();
            try
            {
                SqlParameter[] param = 
            {               
                new SqlParameter("OrderID",typeof(Guid))
            };
                param[0].Value = orderID;
                sw.ExecuteStoredProcedureInTransaction("ORD_DeleteOrder", param);

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

        #region Private Members

        private static void addUpdateChildTablesForOrder(OrderHeader order, ref SQLWrapper sw)
        {
            string sequences = "";
            // payments
            if (order.Payments != null)
            {
                if (order.Payments.PaymentDetails != null)
                {
                    for (int i = 0; i <= order.Payments.PaymentDetails.Count - 1; i++)
                    {
                        if (!sequences.Trim().Equals(""))
                        {
                            sequences += ",";
                        }
                        sequences += order.Payments.PaymentDetails[i].Sequence.ToString();
                        PaymentsDAL.AddUpdateOrderPayment(order.OrderID, order.Payments.PaymentDetails[i], ref sw);
                    }
                }
            }
            PaymentsDAL.DeleteRestOfTheOrderPayments(order.OrderID, sequences, ref sw);
            sequences = "";

            // finished sizes
            if (order.FinishedSize != null)
            {
                OrderSizeDAL.UpdateOrderFinishedSizes(order.OrderID, order.FinishedSize, ref sw);
            }

            // measurement sizes
            if (order.MeasurementDetails != null)
            {
                OrderSizeDAL.UpdateOrderMeasurementSizes(order.OrderID, order.MeasurementDetails, ref sw);
            }

            // material details
            if (order.OrderMaterials != null)
            {
                sequences = "";
                for (int i = 0; i <= order.OrderMaterials.Count; i++)
                {
                    if (!sequences.Trim().Equals(""))
                    {
                        sequences += ",";
                    }
                    sequences += order.OrderMaterials[i].Sequence.ToString();
                    OrderMaterialsDAL.AddOrderMaterial(order.OrderID, order.OrderMaterials[i], ref sw);
                }
            }
            OrderMaterialsDAL.DeleteRestOfTheOrderMaterials(order.OrderID, sequences, ref sw);
        }

        private static SqlParameter[] prepareSQLParameters(OrderHeader order, bool forAddMode)
        {
            SqlParameter[] param = 
            {
                new SqlParameter("OrderID",typeof(Guid )),
                new SqlParameter("OrderNumber",typeof(string)),
                new SqlParameter("CustomerID",typeof(Guid)),
                new SqlParameter("OrderDate",typeof(DateTime)),
                new SqlParameter("SalesManID",typeof(Int32)),
                new SqlParameter("StyleSummary",typeof(string)),
                new SqlParameter("OrderAmount",typeof(decimal)),
                new SqlParameter("PaidAmount",typeof(decimal)),
                new SqlParameter("UploadedDate",typeof(DateTime)),
                new SqlParameter("HasLog",typeof(bool)),
                new SqlParameter("Measure_Height",typeof(string)),
                new SqlParameter("Measure_Weight",typeof(string)),
                new SqlParameter("Measure_OrderInstructions",typeof(string)),
                new SqlParameter("ShippingCharges",typeof(decimal)),
                new SqlParameter("DutyCharges",typeof(decimal)),
                new SqlParameter("OtherCharges",typeof(decimal)),
                new SqlParameter("OtherChargesCaption",typeof(string)),
                new SqlParameter("Discount",typeof(decimal)),
                new SqlParameter("TaxPercentage",typeof(decimal)),
                new SqlParameter("ShippingInstructions",typeof(string)),
                new SqlParameter("OrderRemarks",typeof(string)),
                new SqlParameter("ShipmentType",typeof(Int32)),
                new SqlParameter("OrderType",typeof(Int32))
            };
            if (forAddMode)
            {
                param[0].Direction = ParameterDirection.Output;
            }
            else
            {
                param[0].Value = order.OrderID;
            }
            param[1].Value = order.OrderNumber;
            param[2].Value = order.Customer.CustomerID;
            param[3].Value = order.OrderTakenDate;
            param[4].Value = order.AssignedSalesMan.SalesManID;
            param[5].Value = order.StyleSummary;
            param[6].Value = order.OrderAmount;
            param[7].Value = order.PaidAmount;
            param[8].Value = order.UploadedDate;
            param[9].Value = order.HasLog;
            param[10].Value = order.MeasurementDetails.Height;
            param[11].Value = order.MeasurementDetails.Weight;
            param[12].Value = order.MeasurementDetails.OrderInstructions;
            param[13].Value = order.Payments.Shipping;
            param[14].Value = order.Payments.Duty;
            param[15].Value = order.Payments.OtherCharges;
            param[16].Value = order.Payments.OtherChargesCaption;
            param[17].Value = order.Payments.Discount;
            param[18].Value = order.Payments.TaxPercentage;
            param[19].Value = order.Payments.ShippingInstructions;
            param[20].Value = order.Payments.Notes;
            param[21].Value = Convert.ToInt32(order.Payments.ShipmentType);
            param[22].Value = Convert.ToInt32(order.Payments.OrderType);
            return param;
        }

        private static string generateOrderNumber(SalesMan sm, OrderOriginatedFrom source, long OrderCount)
        {
            return Convert.ToInt32(source).ToString() + "-" + sm.Initials + "-" + (OrderCount + 1).ToString("000000#");
        }

        private static OrderOriginatedFrom getOrigination(string orderNumber)
        {
            switch (orderNumber.Substring(0, 1))
            {
                case "2": { return OrderOriginatedFrom.MyTailorDotCom; break; }
                default: { return OrderOriginatedFrom.Portal; break; }
            }
        }

        private static OrderListItem loadOrderListItem(DataRow dr)
        {
            OrderListItem itm = new OrderListItem();
            itm.AssignedSalesMan = SalesManDAL.GetSalesManByID(Convert.ToInt32(dr["SalesManID"]));
            itm.HasLog = Convert.ToBoolean(dr["HasLog"]);
            itm.OrderAmount = Convert.ToDecimal(dr["OrderAmount"]);
            itm.OrderID = (Guid)dr["OrderID"];
            itm.OrderNumber = dr["OrderNumber"].ToString();
            itm.OrderSource = getOrigination(itm.OrderNumber);
            itm.OrderTakenDate = Convert.ToDateTime(dr["OrderDate"]);
            itm.PaidAmount = Convert.ToDecimal(dr["PaidAmount"]);
            itm.UploadedDate = Convert.ToDateTime(dr["UploadedDate"]);

            itm.CardDetails = new BDO.Common.CreditCardData();
            if (dr["CCNumber"] != DBNull.Value)
            {
                itm.CardDetails.CardExpiryDate = Convert.ToDateTime(dr["CCExpiryDate"]);
                itm.CardDetails.CardName = dr["CCOwnerName"].ToString();
                itm.CardDetails.CardNumber = dr["CCNumber"].ToString();
            }
            return itm;
        }

        private static OrderHeader loadOrderHeader(DataSet ds)
        {
            OrderHeader itm = null;
            if (ds != null)
            {
                if (ds.Tables.Count == 4)
                {
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        itm = new OrderHeader();
                        itm.AssignedSalesMan = SalesManDAL.GetSalesManByID(Convert.ToInt32(dr["SalesManID"]));
                        itm.HasLog = Convert.ToBoolean(dr["HasLog"]);
                        itm.OrderAmount = Convert.ToDecimal(dr["OrderAmount"]);
                        itm.OrderID = (Guid)dr["OrderID"];
                        itm.OrderNumber = dr["OrderNumber"].ToString();
                        itm.OrderSource = getOrigination(itm.OrderNumber);
                        itm.OrderTakenDate = Convert.ToDateTime(dr["OrderDate"]);
                        itm.PaidAmount = Convert.ToDecimal(dr["PaidAmount"]);
                        itm.UploadedDate = Convert.ToDateTime(dr["UploadedDate"]);

                        itm.CardDetails = new BDO.Common.CreditCardData();
                        if (dr["CCNumber"] != DBNull.Value)
                        {
                            itm.CardDetails.CardExpiryDate = Convert.ToDateTime(dr["CCExpiryDate"]);
                            itm.CardDetails.CardName = dr["CCOwnerName"].ToString();
                            itm.CardDetails.CardNumber = dr["CCNumber"].ToString();
                        }

                        itm.Customer = CustomerDAL.GetOrderCustomerByID((Guid)dr["CustomerID"]);
                        itm.StyleSummary = dr["StyleSummary"].ToString();

                        itm.MeasurementDetails = new OrderMeasurement();
                        itm.MeasurementDetails.Height = dr["Measure_Height"].ToString();
                        itm.MeasurementDetails.Weight = dr["Measure_Weight"].ToString();
                        itm.MeasurementDetails.OrderInstructions = dr["Measure_OrderInstructions"].ToString();
                        OrderSizeDAL.LoadOrderMeasurementSizes(itm.OrderID, ref itm);
                        itm.FinishedSize = OrderSizeDAL.GetOrderFinishedSizes(itm.OrderID);
                        itm.Payments = new OrderPayment();
                        itm.Payments.TotalItemPrice = Convert.ToDecimal(dr["OrderAmount"]);
                        itm.Payments.Shipping = Convert.ToDecimal(dr["ShippingCharges"]);
                        itm.Payments.Duty = Convert.ToDecimal(dr["DutyCharges"]);
                        itm.Payments.OtherCharges = Convert.ToDecimal(dr["OtherCharges"]);
                        itm.Payments.OtherChargesCaption = dr["OtherChargesCaption"].ToString();
                        itm.Payments.Discount = Convert.ToDecimal(dr["Discount"]);
                        itm.Payments.TaxPercentage = Convert.ToDecimal(dr["TaxPercentage"]);
                        itm.Payments.ShipmentType = (ShipmentTypes)Convert.ToInt32(dr["ShipmentType"]);
                        itm.Payments.OrderType = (OrderTypes)Convert.ToInt32(dr["OrderType"]);
                        itm.Payments.ShippingInstructions = dr["ShippingInstructions"].ToString();
                        itm.Payments.Notes = dr["OrderRemarks"].ToString();
                        itm.OrderMaterials = OrderMaterialsDAL.GetOrderMaterialsByOrderID(itm.OrderID);
                    }
                }
            }

            return itm;
        }

        #endregion
    }
}
