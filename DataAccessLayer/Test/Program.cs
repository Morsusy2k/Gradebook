using System;
using Gradebook.DataAccessLayer.Models;
using Gradebook.RepositoryLayer.Interfaces;
using Gradebook.RepositoryLayer.Repositories;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserRepository _repository = new UserRepository();
            List<User> users = _repository.GetAllUsers();

            Console.WriteLine("--- User list ---");
            foreach (User user in users)
            {
                Console.WriteLine($"Id:{user.Id}\nName:{user.Name}\nSurname:{user.Surname}\nVersion:{user.Version.GetHashCode()}\n");
            }

            IRoleRepository _roleRepository = new RoleRepository();
            List<Role> roles = _roleRepository.GetAllRoles();

            Console.WriteLine("\n--- Role list ---");
            foreach (Role role in roles)
            {
                Console.WriteLine($"Id: {role.Id} Role name: {role.Name}\n");
            }
        }
    }
}
