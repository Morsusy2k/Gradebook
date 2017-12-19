using Gradebook.BusinessLogicLayer.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gradebook.PresentationLayer.WebApplication.Models.BasicModels
{
    public class UserModel
    {
        public UserModel() { }

        public UserModel(string name, string surname, string username, string password, string email, byte[] version)
        {
            Name = name;
            Surname = surname;
            Username = username;
            Password = password;
            Email = email;
            Version = version;
        }

        public int Id { get; set; }

        [DisplayName("Name")]
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

        [DisplayName("Email address")]
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public byte[] Version { get; set; }

        public List<RoleModel> Roles { get; set; }

        public string RolesString { get; set; }

        public string FullName { get { return Name + " " + Surname; } }

        public static implicit operator User(UserModel um)
        {
            if (um == null)
                return null;

            User user = new User(um.Name, um.Surname, um.Username, um.Password, um.Email, um.Version)
            {
                Id = um.Id
            };

            return user;
        }

        public static implicit operator UserModel(User u)
        {
            if (u == null)
                return null;

            UserModel user = new UserModel(u.Name, u.Surname, u.Username, u.Password, u.Email, u.Version)
            {
                Id = u.Id
            };

            return user;
        }
    }
}