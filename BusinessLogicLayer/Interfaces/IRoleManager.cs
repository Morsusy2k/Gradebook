using Gradebook.BusinessLogicLayer.Models;
using System.Collections.Generic;

namespace Gradebook.BusinessLogicLayer.Interfaces
{
    public interface IRoleManager
    {
        Role GetById(int id);
        IEnumerable<Role> GetAll();

        Role Add(Role user);
        Role Save(Role user);
        void Remove(Role user);

        Role Map(DataAccessLayer.Models.Role dbuser);
        DataAccessLayer.Models.Role Map(Role user);
    }
}
