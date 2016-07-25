using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace MvcApp.UtilityCode
{
    public class Common
    {
        public static string GetConnectionString(string Connection)
        {
            //Checks to see if test system, sets switch to true if found
            if (HttpContext.Current.Request.Url.AbsoluteUri.ToString().ToUpper().Contains("LOCALHOST")
                  || HttpContext.Current.Request.Url.AbsoluteUri.ToString().ToUpper().Contains("TEST"))
            {
                switch (Connection)
                {
                    case ConfigValues.literal_Landscape_ERP:
                        Connection = ConfigurationManager.ConnectionStrings[ConfigValues.Landscape_ERP_TEST].ConnectionString;
                        break;
                }
            }
            //Production System
            else
            {
                switch (Connection)
                {
                    case ConfigValues.literal_Landscape_ERP:
                        Connection = ConfigurationManager.ConnectionStrings[ConfigValues.Landscape_ERP_PROD].ConnectionString;
                        break;
                }
            }

            return Connection;
        }
    }
}