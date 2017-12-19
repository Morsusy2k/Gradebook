using Gradebook.DataAccessLayer.Models;
using Gradebook.Utilities.Common;
using System.Collections.Generic;

namespace Gradebook.RepositoryLayer.Interfaces
{
    public interface IUserInterface
    {
        User GetUserById(int id);
        User GetUserByUsername(string username);
        User GetUserByCredentials(string username, string password);
        List<string> GetUserRolesByUser(string username);
        List<User> GetAllUsers();
        List<User> GetAllProfessors();

        User InsertUser(User user, ITransaction transaction = null);
        User UpdateUser(User user, ITransaction transaction = null);
        void DeleteUser(User user, ITransaction transaction = null);

        ITransaction CreateNewTransaction();
    }
}
