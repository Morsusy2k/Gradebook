using Gradebook.BusinessLogicLayer.Models;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public class UserModel
    {
        public UserModel() { }
        public UserModel(string name, string surname, string username, string password, string email, byte[] version, IEnumerable<Role> roles)
        {
            Name = name;
            Surname = surname;
            Username = username;
            Password = password;
            Email = email;
            Version = version;
            Roles = roles;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public byte[] Version { get; set; }
        public IEnumerable<Role> Roles { get; set; }

        public static implicit operator User(UserModel um)
        {
            User user = new User(um.Name, um.Surname, um.Username, um.Password, um.Email, um.Version)
            {
                Id = um.Id
            };

            return user;
        }

        public static implicit operator UserModel(User u)
        {
            UserModel user = new UserModel(u.Name, u.Surname, u.Username, u.Password, u.Email, u.Version, u.Roles)
            {
                Id = u.Id
            };

            return user;
        }
    }
}