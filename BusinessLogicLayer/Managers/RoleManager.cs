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

        public Role Save(Role role)
        {
            return Map(_repository.UpdateRole(Map(role)));
        }

        public void Remove(Role role)
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
    }
}
