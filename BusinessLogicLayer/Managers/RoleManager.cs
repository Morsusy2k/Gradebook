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
    public class RoleManager : IRoleManager
    {
        private readonly IRoleRepository _repository = new RoleRepository();
        private ITransaction _transaction;

        public IEnumerable<Role> GetAll()
        {
            return _repository.GetAllRoles().Select(x => Map(x));
        }

        public Role GetById(int id)
        {
            return Map(_repository.GetRoleById(id));
        }

        public Role Add(Role role)
        {
            return Map(_repository.InsertRole(Map(role)));
        }

        public IEnumerable<UserRole> GetAllUserRoles()
        {
            return _repository.GetAllUserRoles().Select(x => Map(x));
        }

        public IEnumerable<UserRole> GetAllUserRolesByUserId(int id)
        {
            return _repository.GetUserRolesByUserId(id).Select(x => Map(x));
        }

        public UserRole GetUserRoleById(int id)
        {
            return Map(_repository.GetUserRoleById(id));
        }

        public void AddUserRole(User editor, Role role, User user)
        {
            _repository.InsertUserRole(Map(editor), Map(role), Map(user));
        }

        public void SaveUserRole(User editor, Role role, User user)
        {
            _repository.UpdateUserRole(Map(editor), Map(role), Map(user));
        }

        public void DeleteUserRole(UserRole userRole)
        {
            _repository.DeleteUserRole(Map(userRole));
        }

        public Role InsertRole(Role role)
        {
            return Map(_repository.InsertRole(Map(role)));
        }

        public void DeleteRole(Role role)
        {
            _repository.DeleteRole(Map(role));
        }

        public Role Map(DataAccessLayer.Models.Role dbRole)
        {
            if (Equals(dbRole, null))
                return null;

            Role role = new Role(dbRole.Name);
            role.Id = dbRole.Id;

            return role;
        }

        public DataAccessLayer.Models.Role Map(Role role)
        {
            if (Equals(role, null))
                throw new ArgumentNullException("Role", "Valid role is mandatory!");

            return new DataAccessLayer.Models.Role(role.Id, role.Name);
        }

        public UserRole Map(DataAccessLayer.Models.UserRole dbUserRole)
        {
            if (Equals(dbUserRole, null))
                return null;

            UserRole userRole = new UserRole(dbUserRole.UserId, dbUserRole.RoleId, dbUserRole.CreatedBy, dbUserRole.CreatedDate, dbUserRole.Version, dbUserRole.ModifiedBy, dbUserRole.ModifiedDate);
            userRole.Id = dbUserRole.Id;

            return userRole;
        }

        public DataAccessLayer.Models.UserRole Map(UserRole userRole)
        {
            if (Equals(userRole, null))
                throw new ArgumentNullException("userRole", "Valid userRole is mandatory!");

            return new DataAccessLayer.Models.UserRole(userRole.Id, userRole.UserId, userRole.RoleId, userRole.CreatedBy, userRole.CreatedDate, userRole.Version, userRole.ModifiedBy, userRole.ModifiedDate);
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
