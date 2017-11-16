using Gradebook.DataAccessLayer.Models;
using Gradebook.Utilities.Common;
using System.Collections.Generic;

namespace Gradebook.RepositoryLayer.Interfaces
{
    public interface IRoleRepository
    {
        Role GetRoleById(int id);
        List<Role> GetAllRoles();

        Role InsertRole(Role role, ITransaction transaction = null);
        Role UpdateRole(Role role, ITransaction transaction = null);
        void DeleteRole(Role role, ITransaction transaction = null);

        ITransaction CreateNewTransaction();
    }
}
