using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;

using GSR.Common.Utils;

namespace GSR.Common.DataAccess
{
    public class SQLWrapper
    {

        #region Instance Methods

        private Database db = null;
        private DbConnection conn = null;
        private DbTransaction trans = null;

        public SQLWrapper()
        {
            db = DatabaseFactory.CreateDatabase(ConfigReader.ActiveConnectionStringKey);
            conn = db.CreateConnection();
            trans = null;
        }

        public void BeginTransaction()
        {
            trans = conn.BeginTransaction();
        }

        public void CommitTransaction()
        {
            trans.Commit();
            trans.Dispose();
            trans = null;
        }

        public void RollBackTransaction()
        {
            trans.Rollback();
            trans.Dispose();
            trans = null;
        }

        ~SQLWrapper()
        {
            if (conn != null)
            {
                if (conn.State == ConnectionState.Open)
                {
                    if (trans != null)
                    {
                        trans.Rollback();
                        trans.Dispose();
                        trans = null;
                    }
                        conn.Close();
                        conn.Dispose();
                        conn = null;
                }
            }
            db = null;
        }

        public bool ExecuteQueryInTransaction(string queryText)
        {
            DbCommand dbc = db.GetSqlStringCommand(queryText);
            db.ExecuteNonQuery(dbc, trans);
            return true;
        }

        public bool ExecuteStoredProcedureInTransaction(string spName, SqlParameter[] param)
        {
            DbCommand dbc = db.GetStoredProcCommand(spName, param);
            db.ExecuteNonQuery(dbc, trans);
            return true;
        }

        public bool ExecuteQueryInTransaction(List<IBaseQueryData> queryDatum)
        {
            for (int i = 0; i <= queryDatum.Count - 1; i++)
            {
                IBaseQueryData queryData = queryDatum[i];
                DbCommand dbc = db.GetSqlStringCommand(queryData.GetSQL());
                db.ExecuteNonQuery(dbc, trans);
            }
            return true;
        }

        #endregion


        #region Static Methods

        public static DataTable GetDataTable(string spName, int tableIndex = 0, SqlParameter[] param = null)
        {
            DataTable dt = null;

            DataSet ds = GetDataSet(spName, param);
            if (ds != null)
            {
                if (ds.Tables.Count > tableIndex)
                {
                    dt = ds.Tables[tableIndex];
                }
            }

            return dt;
        }

        public static DataSet GetDataSet(string spName, SqlParameter[] param = null)
        {
            DataSet ds = null;
            Database db = DatabaseFactory.CreateDatabase(ConfigReader.ActiveConnectionStringKey);
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbCommand dbc;
                if (param != null)
                {
                    dbc = db.GetStoredProcCommand(spName, param);
                }
                else
                {
                    dbc = db.GetStoredProcCommand(spName);
                }
                ds = db.ExecuteDataSet(dbc);
                conn.Close();
                conn.Dispose();
            }
            return ds;
        }

        public static DataTable GetDataTable(SelectQueryData queryData, int tableIndex = 0)
        {
            DataTable dtResult = null;
            Database db = DatabaseFactory.CreateDatabase(ConfigReader.ActiveConnectionStringKey);
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbCommand dbc = db.GetSqlStringCommand(queryData.GetSQL());
                DataSet ds = db.ExecuteDataSet(dbc);
                conn.Close();
                conn.Dispose();
                if (ds != null)
                {
                    if (ds.Tables[tableIndex] != null)
                    {
                        dtResult = ds.Tables[tableIndex];
                    }
                }
            }
            return dtResult;
        }

        public static bool ExecuteQuery(string queryText)
        {
            bool returnValue = false;
            Database db = DatabaseFactory.CreateDatabase(ConfigReader.ActiveConnectionStringKey);
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbCommand dbc = db.GetSqlStringCommand(queryText);
                db.ExecuteNonQuery(dbc);
                conn.Close();
                conn.Dispose();
                returnValue = true;
            }
            return returnValue;
        }

        public static bool ExecuteStoredProcedure(string spName, SqlParameter[] param)
        {
            bool returnValue = false;
            Database db = DatabaseFactory.CreateDatabase(ConfigReader.ActiveConnectionStringKey);
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbCommand dbc = db.GetStoredProcCommand(spName, param);
                db.ExecuteNonQuery(dbc);
                conn.Close();
                conn.Dispose();
                returnValue = true;
            }
            return returnValue;
        }

        public static bool ExecuteQuery(IBaseQueryData queryData)
        {
            return ExecuteQuery(queryData.GetSQL());
        }

        public static bool ExecuteQuery(List<IBaseQueryData> queryDatum)
        {
            bool returnValue = false;
            Database db = DatabaseFactory.CreateDatabase(ConfigReader.ActiveConnectionStringKey);
            using (DbConnection conn = db.CreateConnection())
            {
                // open the connection and begin transaction
                conn.Open();
                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    for (int i = 0; i <= queryDatum.Count - 1; i++)
                    {
                        IBaseQueryData queryData = queryDatum[i];
                        DbCommand dbc = db.GetSqlStringCommand(queryData.GetSQL());
                        db.ExecuteNonQuery(dbc, trans);
                    }
                    // Commit the transaction.
                    trans.Commit();
                    returnValue = true;
                }
                catch (Exception ex)
                {
                    // Roll back the transaction. 
                    trans.Rollback();
                    throw ex;
                }
                conn.Close();
            }
            return returnValue;
        }

        #endregion

    }
}
