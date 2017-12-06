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
    public class PClassManager : IPClassManager
    {
        private readonly IPClassInterface _repository = new PClassRepository();
        private ITransaction _transaction;

        public IEnumerable<PClass> GetAll()
        {
            return _repository.GetAllPClasses().Select(x => Map(x));
        }

        public PClass GetById(int id)
        {
            return Map(_repository.GetPClassById(id));
        }

        public PClass Add(PClass pclass)
        {
            return Map(_repository.InsertPClass(Map(pclass)));
        }

        public PClass Save(PClass pclass)
        {
            return Map(_repository.UpdatePClass(Map(pclass)));
        }

        public void Remove(PClass pclass)
        {
            _repository.DeletePClass(Map(pclass));
        }

        public PClass Map(DataAccessLayer.Models.PClass dbPClass)
        {
            if (Equals(dbPClass, null))
                return null;

            PClass field = new PClass(dbPClass.UserId, dbPClass.FieldOfStudyId, dbPClass.Generation, dbPClass.Year, dbPClass.PClassIndex, dbPClass.CreatedBy, dbPClass.CreatedDate, dbPClass.Version, dbPClass.ModifiedDate, dbPClass.ModifiedBy);
            field.Id = dbPClass.Id;
            field.Version = dbPClass.Version;

            return field;
        }

        public DataAccessLayer.Models.PClass Map(PClass pclass)
        {
            if (Equals(pclass, null))
                throw new ArgumentNullException("PClass", "Valid pclass is mandatory!");

            return new DataAccessLayer.Models.PClass(pclass.Id, pclass.UserId, pclass.FieldOfStudyId, pclass.Generation, pclass.Year, pclass.PClassIndex, pclass.CreatedBy, pclass.CreatedDate, pclass.Version, pclass.ModifiedDate, pclass.ModifiedBy);
        }
    }
}
