using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class LoginModel
    {
        public string ErrorMessage { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        [StringLength(128)]
        public string Email { get; set; }

    }
}