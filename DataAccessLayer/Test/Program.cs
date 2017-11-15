using System;
using Gradebook.DataAccessLayer.Models;
using Gradebook.RepositoryLayer.Interfaces;
using Gradebook.RepositoryLayer.Repositories;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserRepository _repository = new UserRepository();

            User user = _repository.GetUserById(95);

            Console.WriteLine($"Id:{user.Id}\nName:{user.Name}\nSurname:{user.Surname}\n");/*Version:{user.Version.GetHashCode()}*/
        }
    }
}
