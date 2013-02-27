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
    public class PaymentsDAL
    {
        public static List<IOrderPaymentItem> GetOrderPayments(Guid orderID)
        {
            List<IOrderPaymentItem> payments = new List<IOrderPaymentItem>();
            SqlParameter[] param = 
            {               
                new SqlParameter("OrderID",typeof(Guid))
            };
            param[0].Value = orderID;
            DataTable dtPayments = SQLWrapper.GetDataTable("ORD_GetOrderPayments", 0, param);
            if (dtPayments != null)
            {
                for (int i = 0; i <= dtPayments.Rows.Count - 1; i++)
                {
                    payments.Add(loadOrderPayment(dtPayments.Rows[i]));
                }
            }
            return payments;
        }

        public static bool AddUpdateOrderPayment(Guid orderID, IOrderPaymentItem paymentItem)
        {
            bool returnValue = false;
            SqlParameter[] param = prepareParameters(orderID, paymentItem);
            returnValue = SQLWrapper.ExecuteStoredProcedure("ORD_AddUpdateOrderPayment", param);
            return returnValue;
        }

        public static bool AddUpdateOrderPayment(Guid orderID, IOrderPaymentItem paymentItem,ref SQLWrapper sw)
        {
            SqlParameter[] param = prepareParameters(orderID,paymentItem);
            return sw.ExecuteStoredProcedureInTransaction("ORD_AddUpdateOrderPayment", param);
        }

        public static bool DeleteRestOfTheOrderPayments(Guid orderID, string otherThanSequenceNumbers)
        {
            bool returnValue = false;
            SqlParameter[] param =
            {
                new SqlParameter("OrderID",typeof(Guid )),
                new SqlParameter("Sequences",typeof(string )),
            };
            returnValue = SQLWrapper.ExecuteStoredProcedure("ORD_DeleteOrderPayments", param);
            return returnValue;
        }

        public static bool DeleteRestOfTheOrderPayments(Guid orderID, string otherThanSequenceNumbers, ref SQLWrapper sw)
        {
            SqlParameter[] param =
            {
                new SqlParameter("OrderID",typeof(Guid )),
                new SqlParameter("Sequences",typeof(string )),
            };
            param[0].Value = orderID;
            param[1].Value = otherThanSequenceNumbers;
            return sw.ExecuteStoredProcedureInTransaction("ORD_DeleteOrderPayments", param);
        }

        #region Private Members

        private static SqlParameter[] prepareParameters(Guid orderID, IOrderPaymentItem paymentItem)
        {
            SqlParameter[] param  =
            {
                new SqlParameter("OrderID",typeof(Guid )),
                new SqlParameter("Sequence",typeof(int )),
                new SqlParameter("PaymentDate",typeof(DateTime )),
                new SqlParameter("Amount",typeof(decimal )),
                new SqlParameter("PaymentRemarks",typeof(string )),
                new SqlParameter("PaymentType",typeof(int )),
                new SqlParameter("CCNumber",typeof(string )),
                new SqlParameter("CCName",typeof(string )),
                new SqlParameter("CCExpiryDate",typeof(DateTime )),
                new SqlParameter("CCOwnerName",typeof(string )),
                new SqlParameter("CHKBankName",typeof(string )),
                new SqlParameter("CHKOwnerName",typeof(string )),
                new SqlParameter("CHKAmount",typeof(decimal )),
                new SqlParameter("CHKNumber",typeof(string )),
                new SqlParameter("GCNumber",typeof(string )),
                new SqlParameter("GCTotalValue",typeof(decimal )),
                new SqlParameter("GCAvailableValue",typeof(decimal ))
            };
            setParameterValues(ref param, orderID,paymentItem );
            return param;
        }

        private static void setParameterValues(ref SqlParameter[] param, Guid orderID, IOrderPaymentItem paymentItem)
        {
            param[0].Value = orderID;
            param[1].Value = paymentItem.Sequence;
            param[2].Value = paymentItem.PaymentDate;
            param[3].Value = paymentItem.Amount;
            param[4].Value = paymentItem.PaymentRemarks;
            switch (paymentItem.PaymentType)
            {
                case OrderPaymentTypes.GiftCertificate:
                    {
                        GiftCertificatePayment itm = (GiftCertificatePayment)paymentItem;
                        if (itm.GCInfo == null)
                        {
                            throw new Exception("Invalid gift card information for the payment.");
                        }
                        param[5].Value = ""; // cc number
                        param[6].Value = ""; // cc name
                        param[7].Value = DBNull.Value; // cc expiry date
                        param[8].Value = ""; // bank name
                        param[9].Value = ""; // owner name
                        param[10].Value = 0; // amount
                        param[11].Value = ""; // check number
                        param[12].Value = itm.GCInfo.Number;
                        param[13].Value = itm.GCInfo.TotalValue;
                        param[14].Value = itm.GCInfo.AvailableBalance;
                        break;
                    }
                case OrderPaymentTypes.CreditCard:
                    {
                        CreditCardPayment itm = (CreditCardPayment)paymentItem;
                        if (itm.CCInfo == null)
                        {
                            throw new Exception("Invalid credit card information for the payment.");
                        }
                        param[5].Value = itm.CCInfo.CardNumber;
                        param[6].Value = itm.CCInfo.CardName;
                        param[7].Value = itm.CCInfo.CardExpiryDate;
                        param[8].Value = ""; // bank name
                        param[9].Value = ""; // owner name
                        param[10].Value = 0; // amount
                        param[11].Value = ""; // check number
                        break;
                    }
                case OrderPaymentTypes.Check:
                    {
                        CheckPayment itm = (CheckPayment)paymentItem;
                        if (itm.ChkInfo == null)
                        {
                            throw new Exception("Invalid check information for the payment.");
                        }
                        param[5].Value = ""; // cc number
                        param[6].Value = ""; // cc name
                        param[7].Value = DBNull.Value; // cc expiry date
                        param[8].Value = itm.ChkInfo.BankName;
                        param[9].Value = itm.ChkInfo.AccountName;
                        param[10].Value = itm.ChkInfo.CheckAmount;
                        param[11].Value = itm.ChkInfo.CheckNumber;
                        param[12].Value = ""; // gc number
                        param[13].Value = 0; // total value
                        param[14].Value = 0; // available value
                        break;
                    }
                default:
                    {
                        OrderPaymentItem itm = (OrderPaymentItem)paymentItem;
                        param[5].Value = ""; // cc number
                        param[6].Value = ""; // cc name
                        param[7].Value = DBNull.Value; // cc expiry date
                        param[8].Value = ""; // bank name
                        param[9].Value = ""; // owner name
                        param[10].Value = 0; // amount
                        param[11].Value = ""; // check number
                        param[12].Value = ""; // gc number
                        param[13].Value = 0; // total value
                        param[14].Value = 0; // available value
                        break;
                    }
            }
        }

        private static IOrderPaymentItem loadOrderPayment(DataRow dr)
        {
            IOrderPaymentItem payment = null;
            if (dr != null)
            {
                OrderPaymentTypes paymentType = (OrderPaymentTypes)dr["PaymentType"];
                switch (paymentType)
                {
                    case OrderPaymentTypes.GiftCertificate:
                        {
                            GiftCertificatePayment gcPayment = new GiftCertificatePayment();
                            gcPayment.GCInfo = new GiftCertificateData();
                            gcPayment.GCInfo.Number = dr["GCNumber"].ToString();
                            gcPayment.GCInfo.TotalValue = Convert.ToDecimal(dr["GCTotalValue"]);
                            gcPayment.GCInfo.AvailableBalance = Convert.ToDecimal(dr["GCAvailableValue"]);
                            gcPayment.Sequence = Convert.ToInt32(dr["Sequence"]);
                            gcPayment.Amount = Convert.ToDecimal(dr["Amount"]);
                            gcPayment.PaymentDate = Convert.ToDateTime(dr["PaymentDate"]);
                            gcPayment.PaymentRemarks = dr["PaymentRemarks"].ToString();
                            return gcPayment;
                            break;
                        }
                    case OrderPaymentTypes.CreditCard:
                        {
                            CreditCardPayment ccPayment = new CreditCardPayment();
                            ccPayment.CCInfo = new CreditCardData();
                            ccPayment.CCInfo.CardNumber = dr["CCNumber"].ToString();
                            ccPayment.CCInfo.CardName = dr["CCName"].ToString();
                            ccPayment.CCInfo.CardExpiryDate = Convert.ToDateTime(dr["CCExpiryDate"]);
                            ccPayment.Sequence = Convert.ToInt32(dr["Sequence"]);
                            ccPayment.Amount = Convert.ToDecimal(dr["Amount"]);
                            ccPayment.PaymentDate = Convert.ToDateTime(dr["PaymentDate"]);
                            ccPayment.PaymentRemarks = dr["PaymentRemarks"].ToString();
                            return ccPayment;
                            break;
                        }
                    case OrderPaymentTypes.Check:
                        {
                            CheckPayment cqPayment = new CheckPayment();
                            cqPayment.ChkInfo = new CheckData();
                            cqPayment.ChkInfo.AccountName = dr["CHKOwnerName"].ToString();
                            cqPayment.ChkInfo.BankName = dr["CHKBankName"].ToString();
                            cqPayment.ChkInfo.CheckAmount = Convert.ToDecimal(dr["CHKAmount"]);
                            cqPayment.ChkInfo.CheckNumber = dr["CHKNumber"].ToString();
                            cqPayment.Sequence = Convert.ToInt32(dr["Sequence"]);
                            cqPayment.Amount = Convert.ToDecimal(dr["Amount"]);
                            cqPayment.PaymentDate = Convert.ToDateTime(dr["PaymentDate"]);
                            cqPayment.PaymentRemarks = dr["PaymentRemarks"].ToString();
                            return cqPayment;
                        }
                    default:
                        {
                            payment = new OrderPaymentItem();
                            payment.Sequence = Convert.ToInt32(dr["Sequence"]);
                            payment.Amount = Convert.ToDecimal(dr["Amount"]);
                            payment.PaymentDate = Convert.ToDateTime(dr["PaymentDate"]);
                            payment.PaymentRemarks = dr["PaymentRemarks"].ToString();
                            break;
                        }

                }
            }
            return payment;
        }

        #endregion
    }
}
