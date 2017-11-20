using Gradebook.BusinessLogicLayer.Interfaces;
using Gradebook.BusinessLogicLayer.Managers;
using System.Collections.Generic;

namespace WebApplication.Models.IdentityModels
{
    public class UserDatabase : List<UserModel>
    {
        //private static readonly IRoleManager _roleManager = new RoleManager();
        private static readonly IUserManager _userManager = new UserManager();

        public UserDatabase()
        {
            foreach(UserModel user in _userManager.GetAll())
            {
                Add(user);
            }
        }
        
    }
}