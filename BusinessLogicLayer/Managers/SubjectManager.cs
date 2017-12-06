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
    public class SubjectManager : ISubjectManager
    {
        private readonly ISubjectInterface _repository = new SubjectRepository();
        private ITransaction _transaction;

        public IEnumerable<Subject> GetAll()
        {
            return _repository.GetAllSubjects().Select(x => Map(x));
        }

        public Subject GetById(int id)
        {
            return Map(_repository.GetSubjectById(id));
        }

        public Subject Add(Subject subject)
        {
            return Map(_repository.InsertSubject(Map(subject)));
        }

        public Subject Save(Subject subject)
        {
            return Map(_repository.UpdateSubject(Map(subject)));
        }

        public void Remove(Subject subject)
        {
            _repository.DeleteSubject(Map(subject));
        }

        public Subject Map(DataAccessLayer.Models.Subject dbSubject)
        {
            if (Equals(dbSubject, null))
                return null;

            Subject subject = new Subject(dbSubject.UserId, dbSubject.Name, dbSubject.CreatedBy, dbSubject.CreatedDate, dbSubject.Version, dbSubject.ModifiedDate, dbSubject.ModifiedBy);
            subject.Id = dbSubject.Id;
            subject.Version = dbSubject.Version;

            return subject;
        }

        public DataAccessLayer.Models.Subject Map(Subject subject)
        {
            if (Equals(subject, null))
                throw new ArgumentNullException("Subject", "Valid subject is mandatory!");

            return new DataAccessLayer.Models.Subject(subject.Id, subject.UserId, subject.Name, subject.CreatedBy, subject.CreatedDate, subject.Version, subject.ModifiedDate, subject.ModifiedBy);
        }
    }
}
