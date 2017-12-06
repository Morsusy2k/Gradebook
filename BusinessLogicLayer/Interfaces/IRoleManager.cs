using Gradebook.BusinessLogicLayer.Models;
using System.Collections.Generic;

namespace Gradebook.BusinessLogicLayer.Interfaces
{
    public interface IRoleManager
    {
        Role GetById(int id);
        IEnumerable<Role> GetAll();
        Role Add(Role role);

        IEnumerable<UserRole> GetAllUserRoles();
        UserRole GetUserRoleById(int id);
        IEnumerable<UserRole> GetAllUserRolesByUserId(int id);
        void AddUserRole(User editor, Role role, User user);
        void DeleteUserRole(UserRole userRole);

        Role InsertRole(Role role);
        void DeleteRole(Role role);

        Role Map(DataAccessLayer.Models.Role dbRole);
        DataAccessLayer.Models.Role Map(Role role);
    }
}
