using Gradebook.BusinessLogicLayer.Managers;
using System;
using System.Web.Security;

namespace WebApplication.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        private readonly UserManager _manager = new UserManager();

        public override string[] GetRolesForUser(string username)
        {
            //return _manager.GetEmployeeRoles(username);
            return new string[] { "Administrator" };
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            foreach (var role in GetRolesForUser(username))
            {
                if (role == roleName)
                {
                    return true;
                }
            }

            return false;
        }

        #region [NotImplementedMembers]

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}