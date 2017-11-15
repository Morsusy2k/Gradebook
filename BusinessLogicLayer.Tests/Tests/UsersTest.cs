using Gradebook.BusinessLogicLayer.Interfaces;
using Gradebook.BusinessLogicLayer.Managers;
using Gradebook.BusinessLogicLayer.Models;
using System;

namespace Gradebook.BusinessLogicLayer.Tests
{
    public static class UsersTest
    {
        private static readonly IUserManager _userManager = new UserManager();

        public static void Populate()
        {
            DateTime dt = DateTime.Now;
            var CurrentTimeStamp = BitConverter.GetBytes(dt.Ticks);

            User user1 = new User("Dragan", "Ilic", "Morsus", "password1", "dilic993@gmail.com", CurrentTimeStamp);
            User user2 = new User("Milena", "Kostic", "KMilka", "password2", "kosticeva@gmail.com", CurrentTimeStamp);
            User user3 = new User("Andrej", "Agic", "Zak", "password3", "zak023@gmail.com", CurrentTimeStamp);

            _userManager.Add(user1);
            _userManager.Add(user2);
            _userManager.Add(user3);
        }

        public static void UpdateAndDelete()
        {
            User user1 = _userManager.GetById(96);
            user1.Name = "Dragance-Updated";

            User user2 = _userManager.GetById(97);
            user2.Name = "Kmilka-Updated";

            User user3 = _userManager.GetById(98);
            _userManager.Save(user1);
            _userManager.Save(user2);
            _userManager.Remove(user3);
        }

        public static void ShowAll()
        {
            foreach (var user in _userManager.GetAll())
            {
                ShowUser(user);
            }
        }

        public static void ShowUser(User user)
        {
            Console.WriteLine($"Id: {user.Id}\nFull name: {user.Name} {user.Surname}\n");
        }
    }
}
