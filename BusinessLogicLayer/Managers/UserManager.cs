using System;
using System.Collections.Generic;
using System.Linq;
using Gradebook.BusinessLogicLayer.Interfaces;
using Gradebook.BusinessLogicLayer.Models;
using Gradebook.RepositoryLayer.Interfaces;
using Gradebook.RepositoryLayer.Repositories;
using Gradebook.Utilities.Common;

namespace Gradebook.BusinessLogicLayer.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _repository = new UserRepository();
        private ITransaction _transaction;

        public IEnumerable<User> GetAll()
        {
            return _repository.GetAllUsers().Select(x => Map(x));
        }

        public User GetById(int id)
        {
            return Map(_repository.GetUserById(id));
        }

        public User GetByUsername(string username)
        {
            return Map(_repository.GetUserByUsername(username));
        }

        public User GetByCredentials(string username, string password)
        {
            return Map(_repository.GetUserByCredentials(username, password));
        }

        public IEnumerable<string> GetUserRoles(string username)
        {
            return _repository.GetUserRolesByUser(username);
        }

        public User Add(User user)
        {
            return Map(_repository.InsertUser(Map(user)));
        }

        public User Save(User user)
        {
            return Map(_repository.UpdateUser(Map(user)));
        }

        public void Remove(User user)
        {
            _repository.DeleteUser(Map(user));
        }

        public User Map(DataAccessLayer.Models.User dbUser)
        {
            if (Equals(dbUser, null))
                return null;

            User user = new User(dbUser.Name, dbUser.Surname, dbUser.Username, dbUser.Password, dbUser.Email, dbUser.Version);
            user.Id = dbUser.Id;
            user.Version = dbUser.Version;

            return user;
        }

        public DataAccessLayer.Models.User Map(User user)
        {
            if (Equals(user, null))
                throw new ArgumentNullException("User", "Valid user is mandatory!");

            return new DataAccessLayer.Models.User(user.Id, user.Name, user.Surname, user.Username, user.Password, user.Email, user.Version);
        }
    }
}
