using DataContextNamespace.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyTermMVC.Models
{
    public class UserView
    {
        public string Id { get; set; }
        
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [Display(Name = "Email Confirmed")]
        public bool EmailConfirmed { get; set; }

       
        [Display(Name = "Username")]
        public string Username { get; set; }
        
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        //[Display(Name = "Role Name")]
        //public string RoleName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string PasswordHash { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("PasswordHash", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        internal User ToDataModel()
        {
            return new User()
            {            
                Id = this.Id,    
                PhoneNumber = this.PhoneNumber,
                Email = this.Email,
                EmailConfirmed = this.EmailConfirmed,
                Firstname = this.FirstName,
                Lastname = this.LastName,
                PasswordHash = this.PasswordHash,
                UserName = this.Username,                
            };
        }
    }
}