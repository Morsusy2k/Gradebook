using Gradebook.BusinessLogicLayer.Models;
using System.Collections.Generic;

namespace Gradebook.BusinessLogicLayer.Interfaces
{
    public interface IUserManager
    {
        User GetById(int id);
        User GetByUsername(string username);
        User GetByCredentials(string email, string password);
        IEnumerable<User> GetAll();
        IEnumerable<string> GetUserRoles(string username);

        User Add(User user);
        User Save(User user);
        void Remove(User user);

        User Map(DataAccessLayer.Models.User dbuser);
        DataAccessLayer.Models.User Map(User user);
    }
}
