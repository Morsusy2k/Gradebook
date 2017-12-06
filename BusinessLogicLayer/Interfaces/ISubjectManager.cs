using Gradebook.BusinessLogicLayer.Models;
using System.Collections.Generic;

namespace Gradebook.BusinessLogicLayer.Interfaces
{
    public interface ISubjectManager
    {
        Subject GetById(int id);
        IEnumerable<Subject> GetAll();

        Subject Add(Subject subject);
        Subject Save(Subject subject);
        void Remove(Subject subject);

        Subject Map(DataAccessLayer.Models.Subject dbSubject);
        DataAccessLayer.Models.Subject Map(Subject subject);
    }
}
