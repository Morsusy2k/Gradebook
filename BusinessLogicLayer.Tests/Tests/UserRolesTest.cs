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

        public static void ShowAllUsers()
        {
            Console.WriteLine("\n\n");
            foreach (var user in _userManager.GetAll())
            {
                IEnumerable<UserRole> roles = _roleManager.GetAllUserRolesByUserId(user.Id);

                Console.Write($"User: {user.Id} {user.Name} {user.Surname} | ");
                Console.Write("Roles:");
                foreach (var userRole in roles)
                {
                    Role role = _roleManager.GetById(userRole.RoleId);
                    Console.Write(" - ");
                    Console.Write($"{role.Name} ");
                }
                Console.WriteLine();
            }
        }
    }
}
