using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace MvcApp.Models
{
    public class Business
    {
        public int BusinessId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string BusinessTypeId { get; set; }
        public string BusinessTypeDesc { get; set; }
        public string Email { get; set; }
        public string Phone1 { get; set; }
        public string Phone1Ext { get; set; }
        public string Phone2 { get; set; }
        public string Phone2Ext { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Comments { get; set; }
        public string CreatedBy { get; set; }
        //[DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        //[DataType(DataType.Date)]
        public DateTime LastModifiedDate { get; set; }
        //public string Self
        //{
        //    get
        //    {
        //        return string.Format(CultureInfo.CurrentCulture,
        //            "api/business/{0}", this.BusinessId);
        //    }
        //    set { }
        //}
    }
}