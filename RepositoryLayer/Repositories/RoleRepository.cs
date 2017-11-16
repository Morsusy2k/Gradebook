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

        public Role UpdateRole(Role role, ITransaction transaction = null)
        {
            return _provider.UpdateRole(role, transaction);
        }

        public void DeleteRole(Role role, ITransaction transaction = null)
        {
            _provider.DeleteRole(role, transaction);
        }

        public ITransaction CreateNewTransaction()
        {
            return _provider.CreateNewTransaction();
        }
    }
}
