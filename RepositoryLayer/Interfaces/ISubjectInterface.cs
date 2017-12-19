using Gradebook.DataAccessLayer.Models;
using Gradebook.Utilities.Common;
using System.Collections.Generic;

namespace Gradebook.RepositoryLayer.Interfaces
{
    public interface ISubjectInterface
    {
        Subject GetSubjectById(int id);
        List<Subject> GetAllSubjects();
        List<Subject> GetSubjectsByFieldId(int id);

        Subject InsertSubject(Subject subject, ITransaction transaction = null);
        Subject UpdateSubject(Subject subject, ITransaction transaction = null);
        void DeleteSubject(Subject subject, ITransaction transaction = null);

        ITransaction CreateNewTransaction();
    }
}
