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

        public static void ShowAllRoles()
        {
            Console.WriteLine("\n\n");
            foreach (var role in _roleManager.GetAll())
            {
                ShowRole(role);
            }
        }

        public static void ShowRole(Role role)
        {
            Console.WriteLine($"Id: {role.Id} | Role name: {role.Name}");
        }

        public static void InsertRole()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("New role name: ");
            string name = Console.ReadLine();
            Role newRole = new Role(name);
            _roleManager.Add(newRole);
            Console.WriteLine($"\n{newRole.Name} added!");
        }

        public static void DeleteRole()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("Enter role ID: ");
            int id;
            string inputId = Console.ReadLine();
            if (int.TryParse(inputId, out id))
            {
                try
                {
                    Role role = _roleManager.GetById(Convert.ToInt32(id));
                    Console.WriteLine($"\n\n {role.Name} selected.");
                    Console.WriteLine("Confirm delete? y/n");
                    char check = Console.ReadKey().KeyChar;
                    if (check == 'y')
                    {
                        _roleManager.DeleteRole(role);
                        Console.WriteLine("\nRole deleted!");
                    }
                    else
                    {
                        Console.WriteLine("\nCanceled!");
                    }
                }
                catch
                {
                    Console.WriteLine("\nRole with this ID does not exist!");
                }
            }
            else
            {
                Console.WriteLine("\nNot an integer!");
            }
        }
    }
}
