using Gradebook.DataAccessLayer.Models;
using Gradebook.Utilities.Common;
using System.Collections.Generic;

namespace Gradebook.RepositoryLayer.Interfaces
{
    public interface IRoleInterface
    {
        Role GetRoleById(int id);
        List<Role> GetAllRoles();
        List<Role> GetAllRolesByUserId(int id);

        Role InsertRole(Role role, ITransaction transaction = null);
        void DeleteRole(Role role, ITransaction transaction = null);
        void DeleteUserRolesByUser(User user, ITransaction transaction = null);

        List<UserRole> GetAllUserRoles();
        List<UserRole> GetUserRolesByUserId(int id);
        UserRole GetUserRoleById(int id);

        void InsertUserRole(User editor, Role role, User user, ITransaction transaction = null);
        void UpdateUserRole(User editor, Role role, User user, ITransaction transaction = null);
        void DeleteUserRole(UserRole userRole, ITransaction transaction = null);

        ITransaction CreateNewTransaction();
    }
}
