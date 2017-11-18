using Gradebook.BusinessLogicLayer.Interfaces;
using Gradebook.BusinessLogicLayer.Managers;
using Gradebook.BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;

namespace Gradebook.BusinessLogicLayer.Tests
{
    public static class UserRolesTest
    {
        private static readonly IRoleManager _roleManager = new RoleManager();
        private static readonly IUserManager _userManager = new UserManager();

        public static void Populate()
        {
            User editor = _userManager.GetById(95);
            Role role = _roleManager.GetById(1);

            _roleManager.AddUserRole(editor,role,editor);
        }

        public static void ShowAll()
        {
            foreach (var user in _userManager.GetAll())
            {
                IEnumerable<UserRole> roles = _roleManager.GetAllUserRolesByUserId(user.Id);

                Console.WriteLine($"User: {user.Name} {user.Surname}");
                Console.WriteLine("Roles:");
                foreach (var userRole in roles)
                {
                    Role role = _roleManager.GetById(userRole.Id);
                    Console.WriteLine($" - {role.Name}");
                }
                Console.WriteLine();
            }
        }
    }
}
