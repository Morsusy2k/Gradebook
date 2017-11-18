using System.Collections.Generic;
using Gradebook.DataAccessLayer.Models;
using Gradebook.DataAccessLayer.SQLAccess.Providers;
using Gradebook.RepositoryLayer.Interfaces;
using Gradebook.Utilities.Common;

namespace Gradebook.RepositoryLayer.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IRoleRepository _provider = new RoleProvider();

        public List<Role> GetAllRoles()
        {
            return _provider.GetAllRoles();
        }

        public Role GetRoleById(int id)
        {
            return _provider.GetRoleById(id);
        }

        public Role InsertRole(Role role, ITransaction transaction = null)
        {
            return _provider.InsertRole(role, transaction);
        }

        public void DeleteRole(Role role, ITransaction transaction = null)
        {
            _provider.DeleteRole(role, transaction);
        }

        public List<UserRole> GetAllUserRoles()
        {
            return _provider.GetAllUserRoles();
        }

        public List<UserRole> GetUserRolesByUserId(int id)
        {
            return _provider.GetUserRolesByUserId(id);
        }

        public UserRole GetUserRoleById(int id)
        {
            return _provider.GetUserRoleById(id);
        }

        public void InsertUserRole(User editor, Role role, User user, ITransaction transaction = null)
        {
            _provider.InsertUserRole(editor, role, user, transaction);
        }

        public void UpdateUserRole(User editor, Role role, User user, ITransaction transaction = null)
        {
            _provider.UpdateUserRole(editor, role, user, transaction);
        }

        public void DeleteUserRole(UserRole userRole, ITransaction transaction = null)
        {
            _provider.DeleteUserRole(userRole, transaction);
        }

        public ITransaction CreateNewTransaction()
        {
            return _provider.CreateNewTransaction();
        }
    }
}
