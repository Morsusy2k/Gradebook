using Gradebook.BusinessLogicLayer.Models;
using System.Collections.Generic;

namespace Gradebook.BusinessLogicLayer.Interfaces
{
    public interface IFieldManager
    {
        FieldOfStudy GetById(int id);
        IEnumerable<FieldOfStudy> GetAll();

        FieldOfStudy Add(FieldOfStudy field);
        FieldOfStudy Save(FieldOfStudy field);
        void Remove(FieldOfStudy field);

        FieldOfStudy Map(DataAccessLayer.Models.FieldOfStudy dbuser);
        DataAccessLayer.Models.FieldOfStudy Map(FieldOfStudy user);
    }
}
