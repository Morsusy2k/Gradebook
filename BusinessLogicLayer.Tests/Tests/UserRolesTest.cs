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

        public static void AddUserRole()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("Enter user ID: ");
            string inputUserId = Console.ReadLine();
            if (int.TryParse(inputUserId, out int userId))
            {
                Console.WriteLine("Enter role ID: ");
                string inputRoleId = Console.ReadLine();
                if (int.TryParse(inputRoleId, out int roleId))
                {
                    try
                    {
                        User user = _userManager.GetById(userId);
                        Role role = _roleManager.GetById(roleId);

                        _roleManager.AddUserRole(user, role, user);
                    }
                    catch
                    {
                        Console.WriteLine("\nSomething went wrong.");
                    }
                }
            }

            
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
