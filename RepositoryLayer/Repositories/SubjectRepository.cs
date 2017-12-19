using System.Collections.Generic;
using Gradebook.DataAccessLayer.Models;
using Gradebook.DataAccessLayer.SQLAccess.Providers;
using Gradebook.RepositoryLayer.Interfaces;
using Gradebook.Utilities.Common;

namespace Gradebook.RepositoryLayer.Repositories
{
    public class SubjectRepository : ISubjectInterface
    {
        private readonly ISubjectInterface _provider = new SubjectProvider();

        public List<Subject> GetAllSubjects()
        {
            return _provider.GetAllSubjects();
        }

        public Subject GetSubjectById(int id)
        {
            return _provider.GetSubjectById(id);
        }

        public List<Subject> GetSubjectsByFieldId(int id)
        {
            return _provider.GetSubjectsByFieldId(id);
        }

        public Subject InsertSubject(Subject subject, ITransaction transaction = null)
        {
            return _provider.InsertSubject(subject, transaction);
        }

        public Subject UpdateSubject(Subject subject, ITransaction transaction = null)
        {
            return _provider.UpdateSubject(subject, transaction);
        }

        public void DeleteSubject(Subject subject, ITransaction transaction = null)
        {
            _provider.DeleteSubject(subject, transaction);
        }

        public ITransaction CreateNewTransaction()
        {
            return _provider.CreateNewTransaction();
        }
    }
}
