using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gradebook.PresentationLayer.WebApplication.Models.ViewModels
{
    public class RegisterViewModel
    {
        [DisplayName("Display name")]
        [Required]
        [StringLength(25, MinimumLength = 5)]
        public string Name { get; set; }

        [DisplayName("Surname")]
        [Required]
        [StringLength(25, MinimumLength = 5)]
        public string Surname { get; set; }

        [DisplayName("Username")]
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string Username { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Password must be longer than 6 characters.")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "The passwords do not match.")]
        public string PasswordConfirm { get; set; }

        [DisplayName("Email address")]
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
    }
}