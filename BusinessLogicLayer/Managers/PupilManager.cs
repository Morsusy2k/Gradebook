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
    public class PupilManager : IPupilManager
    {
        private readonly IPupilInterface _repository = new PupilRepository();
        private ITransaction _transaction;

        public IEnumerable<Pupil> GetAll()
        {
            return _repository.GetAllPupils().Select(x => Map(x));
        }

        public Pupil GetById(int id)
        {
            return Map(_repository.GetPupilById(id));
        }

        public Pupil Add(Pupil pupil)
        {
            return Map(_repository.InsertPupil(Map(pupil)));
        }

        public Pupil Save(Pupil pupil)
        {
            return Map(_repository.UpdatePupil(Map(pupil)));
        }

        public void Remove(Pupil pupil)
        {
            _repository.DeletePupil(Map(pupil));
        }

        public Pupil Map(DataAccessLayer.Models.Pupil dbPupil)
        {
            if (Equals(dbPupil, null))
                return null;

            Pupil field = new Pupil(dbPupil.PClassId, dbPupil.Name, dbPupil.CreatedBy, dbPupil.CreatedDate, dbPupil.Version, dbPupil.ModifiedDate, dbPupil.ModifiedBy);
            field.Id = dbPupil.Id;
            field.Version = dbPupil.Version;

            return field;
        }

        public DataAccessLayer.Models.Pupil Map(Pupil pupil)
        {
            if (Equals(pupil, null))
                throw new ArgumentNullException("pupil", "Valid pupil is mandatory!");

            return new DataAccessLayer.Models.Pupil(pupil.Id, pupil.PClassId, pupil.Name, pupil.CreatedBy, pupil.CreatedDate, pupil.Version, pupil.ModifiedDate, pupil.ModifiedBy);
        }
    }
}
