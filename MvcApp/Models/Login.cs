using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcApp.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Email Required!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Required!")]
        public string Password { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string ErrorMsg { get; set; }
    }
}