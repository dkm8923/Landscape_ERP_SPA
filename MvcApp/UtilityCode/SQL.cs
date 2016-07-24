using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcApp.UtilityCode
{
    public class SQL
    {

        #region Sql Parms struct

        //sql parm class for listing
        public struct sql_parms
        {
            public string parameter { get; set; }
            public string value { get; set; }
        }

        #endregion

        #region Insert / Update Methods

        public static void sql_insert_update(List<sql_parms> lstParms, string strProc, string connString)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(connString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand(strProc, sqlConn))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        foreach (sql_parms parm in lstParms)
                        {
                            sqlCmd.Parameters.Add(new SqlParameter(parm.parameter, parm.value));
                        }

                        sqlConn.Open();

                        sqlCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int sql_insert_update_with_output(List<sql_parms> lstParms, string strProc, string connString)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(connString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand(strProc, sqlConn))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        foreach (sql_parms parm in lstParms)
                        {
                            sqlCmd.Parameters.Add(new SqlParameter(parm.parameter, parm.value));
                        }

                        sqlConn.Open();

                        return (int) sqlCmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Load SQL Data into Datatable
        public static DataTable sql_datatable_return(List<sql_parms> lstParms, string strProc, string connString)
        {
            //DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(connString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand(strProc, sqlConn))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        foreach (sql_parms parm in lstParms)
                        {
                            sqlCmd.Parameters.Add(new SqlParameter(parm.parameter, parm.value));
                        }

                        sqlConn.Open();

                        using (SqlDataReader dr = sqlCmd.ExecuteReader())
                        {
                            using (DataTable dt = new DataTable())
                            {
                                dt.Load(dr);
                                return dt;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}