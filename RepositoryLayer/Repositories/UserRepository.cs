using System.Collections.Generic;
using Gradebook.DataAccessLayer.Models;
using Gradebook.DataAccessLayer.SQLAccess.Providers;
using Gradebook.RepositoryLayer.Interfaces;
using Gradebook.Utilities.Common;

namespace Gradebook.RepositoryLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserRepository _provider = new UserProvider();

        public List<User> GetAllUsers()
        {
            return _provider.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return _provider.GetUserById(id);
        }

        public User InsertUser(User user, ITransaction transaction = null)
        {
            return _provider.InsertUser(user, transaction);
        }

        public User UpdateUser(User user, ITransaction transaction = null)
        {
            return _provider.UpdateUser(user, transaction);
        }

        public void DeleteUser(User user, ITransaction transaction = null)
        {
            _provider.DeleteUser(user, transaction);
        }

        public ITransaction CreateNewTransaction()
        {
            return _provider.CreateNewTransaction();
        }
    }
}
