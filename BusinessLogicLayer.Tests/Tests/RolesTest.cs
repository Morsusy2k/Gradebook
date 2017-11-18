using Gradebook.BusinessLogicLayer.Interfaces;
using Gradebook.BusinessLogicLayer.Managers;
using Gradebook.BusinessLogicLayer.Models;
using System;

namespace Gradebook.BusinessLogicLayer.Tests
{
    public static class RolesTest
    {
        private static readonly IRoleManager _roleManager = new RoleManager();

        public static void Populate()
        {
            Role role1 = new Role("Ucenik");
            Role role2 = new Role("Teacher");
            Role role3 = new Role("Admir");

            _roleManager.Add(role1);
            _roleManager.Add(role2);
            _roleManager.Add(role3);
        }

        /*public static void UpdateAndDelete()
        {
            Role role1 = _roleManager.GetById(5);
            role1.Name = "Student";

            Role role2 = _roleManager.GetById(7);
            _roleManager.Save(role1);
            _roleManager.Remove(role2);
        }*/

        public static void ShowAll()
        {
            foreach (var role in _roleManager.GetAll())
            {
                ShowRole(role);
            }
        }

        public static void ShowUser(User user)
        {
            Console.WriteLine($"Id: {user.Id}\nFull name: {user.Name} {user.Surname}\n");
        }

        public static void ShowRole(Role role)
        {
            Console.WriteLine($"Id: {role.Id}\nRole name: {role.Name}\n");
        }
    }
}
