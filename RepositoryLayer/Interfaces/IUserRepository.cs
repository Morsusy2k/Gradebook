using Gradebook.DataAccessLayer.Models;
using Gradebook.Utilities.Common;
using System.Collections.Generic;

namespace Gradebook.RepositoryLayer.Interfaces
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        User GetUserByCredentials(string username, string password);
        List<User> GetAllUsers();

        User InsertUser(User user, ITransaction transaction = null);
        User UpdateUser(User user, ITransaction transaction = null);
        void DeleteUser(User user, ITransaction transaction = null);

        ITransaction CreateNewTransaction();
    }
}
