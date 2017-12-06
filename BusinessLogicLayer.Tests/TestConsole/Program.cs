using Gradebook.BusinessLogicLayer.Tests;
using System;

namespace Gradebook.BusinessLogicLayer.AdminConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        private static void Menu()
        {
            int choice = 0;
            while (choice != 6)
            {
                Console.Clear();
                Console.WriteLine(" - Admin Console - ");
                Console.WriteLine("[1] List all users");
                Console.WriteLine("[2] List all roles");
                Console.WriteLine("[3] Add new role");
                Console.WriteLine("[4] Delete role");
                Console.WriteLine("[5] User add role");
                Console.WriteLine("[6] Exit");
                ConsoleKeyInfo key = Console.ReadKey();
                if (char.IsDigit(key.KeyChar))
                {
                    choice = int.Parse(key.KeyChar.ToString());
                }
                else
                {
                    choice = 0;
                }

                switch (choice)
                {
                    case 1:
                        ShowAllUsers();
                        Wait();
                        break;
                    case 2:
                        ShowAllRoles();
                        Wait();
                        break;
                    case 3:
                        InsertRole();
                        Wait();
                        break;
                    case 4:
                        RolesTest.DeleteRole();
                        Wait();
                        break;
                    case 5:
                        UserRolesTest.AddUserRole();
                        Wait();
                        break;
                }
            }
        }

        private static void ShowAllUsers()
        {
            UserRolesTest.ShowAllUsers();
        }

        private static void ShowAllRoles()
        {
            RolesTest.ShowAllRoles();
        }

        private static void InsertRole()
        {
            RolesTest.InsertRole();
        }

        private static void Wait()
        {
            Console.WriteLine("\n\n\nPress [enter] to continue...");
            Console.ReadLine();
        }
    }
}
