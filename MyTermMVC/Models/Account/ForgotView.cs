using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyTermMVC.Models.Account
{
    public class ForgotView
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}