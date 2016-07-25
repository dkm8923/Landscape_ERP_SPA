using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MvcApp.Models;
using System.Data;
using System.Data.SqlClient;
using MvcApp.UtilityCode;
using System.Configuration;

namespace MvcApp.Controllers
{
    public class BusinessController : ApiController
    {
        //Local Mac Mini Connection
        //string connString = "Data Source=MACMINI;Initial Catalog=Landscape_ERP;Integrated Security=True";
        //Azure Connection
        //string connString = "Data Source=landscape-erp.database.windows.net;Initial Catalog=Landscape_ERP;Integrated Security=False;User ID=dmauk;Password=ADD PASSWORD HERE!!;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";
        
        // GET api/<controller>
        public List<Business> Get()
        {
            try
            {
                #region SQL Parms

                var lstParms = new List<SQL.sql_parms> { };

                #endregion

                List<Business> data = getBusinessData(lstParms);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET api/<controller>/5
        public List<Business> Get(int id)
        {
            try
            {
                #region SQL Parms

                var lstParms = new List<SQL.sql_parms> { };
                lstParms.Add(new SQL.sql_parms() { parameter = "@Business_ID", value = Convert.ToString(id) });

                #endregion

                List<Business> data = getBusinessData(lstParms);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Business> getBusinessData(List<SQL.sql_parms> lstParms)
        {
            List<Business> lstBusiness = new List<Business>();

            try
            {
                DataTable dt = SQL.sql_datatable_return(lstParms, "proc_Business_Get_All_By_Id", connString);

                foreach (DataRow row in dt.Rows)
                {
                    lstBusiness.Add
                    (
                        new Business
                        {
                            BusinessId = Convert.ToInt32(row["Business_ID"].ToString()),
                            Name = row["Name"].ToString(),
                            BusinessTypeId = row["Type_ID"].ToString(),
                            //BusinessTypeDesc = row["Business_Type_Desc"].ToString(),
                            Email = row["Email"].ToString(),
                            Phone1 = row["Phone_1"].ToString(),
                            Phone1Ext = row["Phone_1_Ext"].ToString(),
                            Phone2 = row["Phone_2"].ToString(),
                            Phone2Ext = row["Phone_2_Ext"].ToString(),
                            Address1 = row["Address_1"].ToString(),
                            Address2 = row["Address_2"].ToString(),
                            City = row["City"].ToString(),
                            State = row["State_ID"].ToString(),
                            Zip = row["Zip"].ToString(),
                            Country = row["Country"].ToString(),
                            Comments = row["Comments"].ToString(),
                            CreatedBy = row["Created_By"].ToString(),
                            CreatedDate = DateTime.Parse(row["Created_Date"].ToString()),
                            LastModifiedBy = row["Last_Modified_By"].ToString(),
                            LastModifiedDate = DateTime.Parse(row["Last_Modified_Date"].ToString())
                        }
                    );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //Should figure out the real way to return JSON data at some point...
            //string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(lstBusiness);
            //return json;
            return lstBusiness;
        }

        // POST api/<controller>
        public int Post([FromBody]Business obj)
        {
            int returnVal = 0;

            if (ModelState.IsValid)
            {
                string createdBy = "dmauk";

                try
                {
                    #region SQL Parms

                    var lstParms = new List<SQL.sql_parms> { };
                    
                    if (obj.BusinessId != 0)
                    {
                        lstParms.Add(new SQL.sql_parms() { parameter = "@Business_ID", value = Convert.ToString(obj.BusinessId) });
                    }
                    
                    lstParms.Add(new SQL.sql_parms() { parameter = "@Name", value = obj.Name });
                    lstParms.Add(new SQL.sql_parms() { parameter = "@Type_ID", value = obj.BusinessTypeId });
                    lstParms.Add(new SQL.sql_parms() { parameter = "@Email", value = obj.Email });
                    lstParms.Add(new SQL.sql_parms() { parameter = "@Phone_1", value = obj.Phone1 });
                    lstParms.Add(new SQL.sql_parms() { parameter = "@Phone_1_Ext", value = obj.Phone1Ext });
                    lstParms.Add(new SQL.sql_parms() { parameter = "@Phone_2", value = obj.Phone2 });
                    lstParms.Add(new SQL.sql_parms() { parameter = "@Phone_2_Ext", value = obj.Phone2Ext });
                    lstParms.Add(new SQL.sql_parms() { parameter = "@Address_1", value = obj.Address1 });
                    lstParms.Add(new SQL.sql_parms() { parameter = "@Address_2", value = obj.Address2 });
                    lstParms.Add(new SQL.sql_parms() { parameter = "@City", value = obj.City });
                    lstParms.Add(new SQL.sql_parms() { parameter = "@State_ID", value = obj.State });
                    lstParms.Add(new SQL.sql_parms() { parameter = "@Zip", value = obj.Zip });
                    lstParms.Add(new SQL.sql_parms() { parameter = "@Country", value = obj.Country });
                    lstParms.Add(new SQL.sql_parms() { parameter = "@Comments", value = obj.Comments });
                    lstParms.Add(new SQL.sql_parms() { parameter = "@Created_By", value = createdBy });

                    #endregion

                    int id = SQL.sql_insert_update_with_output(lstParms, Procedures.proc_Business_InsertUpdate, connString);
                    returnVal = id;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return returnVal;
        }
        
        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}