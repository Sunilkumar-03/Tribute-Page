using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tribute_MVC.Models.DataViewModel
{
    public class UserDataView
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please Enter Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password fields do not match")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress(ErrorMessage = "Please enter a Proper Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter Mobile Number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile")]
        public Int64 Mobile { get; set; }
        [Required]
        public string Role { get; set; }
        public string Status { get; set; }
        public IFormFile ImageUrl { get; set; }
    }
}
