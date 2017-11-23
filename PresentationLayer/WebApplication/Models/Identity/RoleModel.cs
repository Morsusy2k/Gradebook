using Gradebook.BusinessLogicLayer.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.WebApplication.Models
{
    public class RoleModel
    {
        public RoleModel() { }
        public RoleModel(string name)
        {
            Name = name;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<UserModel> Users { get; set; }

        public bool IsChecked { get; set; }

        public static implicit operator Role(RoleModel rm)
        {
            Role genre = new Role(rm.Name)
            {
                Id = rm.Id
            };

            return genre;
        }

        public static implicit operator RoleModel(Role r)
        {
            RoleModel role = new RoleModel(r.Name)
            {
                Id = r.Id
            };

            return role;
        }
    }
}