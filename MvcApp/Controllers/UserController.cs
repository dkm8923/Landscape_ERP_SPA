using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApp.Models;
using System.Data;
using System.Data.SqlClient;
using MvcApp.UtilityCode;
using System.Configuration;

namespace MvcApp.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            if (TempData[Constants.ErrorMsg] != null)
            {
                ViewBag.ErrorMsg = TempData["ErrorMsg"];
                TempData.Remove(Constants.ErrorMsg);
            }

            return View();
        }

        /// <summary>
        /// Validates Username and Password in DB.
        /// ReturnVal = 0: User was not found in db or deactivated
        /// ReturnVal = 1: Account is locked
        /// ReturnVal = 2: Account Authenticated Successfully
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Error Message in ViewBag.ErrorMsg or Redirects user to next page</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model)
        {
            //Model did not pass validation rules
            if (!ModelState.IsValid)
            {
                TempData[Constants.ErrorMsg] = "Invalid Username / Password!";
                return RedirectToAction(Constants.Index, Constants.User);
            }
            else
            {
                User u = new User();
                int returnVal = 0;

                try
                {
                    //Azure Connection
                    string connString = "Data Source=landscape-erp.database.windows.net;Initial Catalog=Landscape_ERP;Integrated Security=False;User ID=dmauk;Password=!0a418tq0!;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";

                    var browser = Request.Browser;

                    #region SQL Parms

                    var lstParms = new List<SQL.sql_parms> { };

                    lstParms.Add(new SQL.sql_parms() { parameter = "@Email", value = model.Email });
                    lstParms.Add(new SQL.sql_parms() { parameter = "@Password", value = model.Password });
                    lstParms.Add(new SQL.sql_parms() { parameter = "@OS", value = Request.UserAgent.ToString() });
                    lstParms.Add(new SQL.sql_parms() { parameter = "@Browser", value = browser.Type.ToString() });
                    lstParms.Add(new SQL.sql_parms() { parameter = "@BrowserPlatform", value = Request.Browser.Platform.ToString() });
                    lstParms.Add(new SQL.sql_parms() { parameter = "@MajorVersion", value = browser.MajorVersion.ToString() });
                    lstParms.Add(new SQL.sql_parms() { parameter = "@MinorVersion", value = browser.MinorVersion.ToString() });
                    lstParms.Add(new SQL.sql_parms() { parameter = "@IP", value = Request.UserHostAddress.ToString() });
                    lstParms.Add(new SQL.sql_parms() { parameter = "@Mobile", value = browser.IsMobileDevice.ToString() });
                    lstParms.Add(new SQL.sql_parms() { parameter = "@MobileDeviceType", value = browser.MobileDeviceManufacturer.ToString() });
                    lstParms.Add(new SQL.sql_parms() { parameter = "@MobileDeviceModel", value = browser.MobileDeviceModel.ToString() });

                    lstParms.Add(new SQL.sql_parms() { parameter = "@Longitude", value = model.Longitude });
                    lstParms.Add(new SQL.sql_parms() { parameter = "@Latitude", value = model.Latitude });


                    #endregion

                    DataTable dt = SQL.sql_datatable_return(lstParms, "proc_Login_Authenticate_User", connString);

                    foreach (DataRow row in dt.Rows)
                    {
                        returnVal = Convert.ToInt32(row["ReturnVal"]);

                        if (returnVal == 2)
                        {
                            u.UserID = Convert.ToInt32(row["User_ID"]);
                            u.BusinessID = Convert.ToInt32(row["Business_ID"]);
                            u.CompanyID = Convert.ToInt32(row["Company_ID"]);
                            u.UserTypeID = Convert.ToInt32(row["User_Type_ID"]);
                            u.Email = row["Email"].ToString();
                            u.FirstName = row["First_Name"].ToString();
                            u.LastName = row["Last_Name"].ToString();
                            u.Phone = row["Phone"].ToString();
                            u.Mobile = row["Mobile"].ToString();
                            u.Address1 = row["Address_1"].ToString();
                            u.Address2 = row["Address_2"].ToString();
                            u.City = row["City"].ToString();
                            u.State = row["State"].ToString();
                            u.Zip = row["Zip"].ToString();
                            u.Country = row["Country"].ToString();
                            u.Comments = row["Comments"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                if (returnVal == 1)
                {
                    //Account is locked
                    TempData[Constants.ErrorMsg] = "Your Account has been locked. Please try again later!";
                    return RedirectToAction(Constants.Index, Constants.User);
                }
                else if (returnVal == 2)
                {
                    //Successful Login
                    return RedirectToAction(Constants.Index, Constants.Home);
                }
                else
                {
                    //User was not found in db or deactivated
                    TempData[Constants.ErrorMsg] = "Invalid Username / Password!";
                    return RedirectToAction(Constants.Index, Constants.User);
                }
            }
        }
    }
}
