using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApp.Models
{
    public class User
    {
      public int UserID { get; set; }
      public int BusinessID { get; set; }
      public int CompanyID { get; set; }
      public int UserTypeID { get; set; }
      public string  Password { get; set; }
      public string  Email { get; set; }
      public string  FirstName { get; set; }
      public string  LastName { get; set; }
      public string  Phone { get; set; }
      public string  Mobile { get; set; }
      public string  Address1 { get; set; }
      public string  Address2 { get; set; }
      public string  City { get; set; }
      public string  State { get; set; }
      public string  Zip { get; set; }
      public string  Country { get; set; }
      public string  Comments { get; set; }
      public int LoginAttempts { get; set; }
      public DateTime LastLoginDate { get; set; }
      public DateTime AccountLockDate { get; set; }
      public DateTime DeactivatedDate { get; set; }
      public string  CreatedBy { get; set; }
      DateTime CreatedDate { get; set; }
      public string  LastModifiedBy { get; set; }
      DateTime LastModifiedDate { get; set; }
      public string  DeleteFlag { get; set; }
    }
}