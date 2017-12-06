using System.Collections.Generic;
using Gradebook.DataAccessLayer.Models;
using Gradebook.DataAccessLayer.SQLAccess.Providers;
using Gradebook.RepositoryLayer.Interfaces;
using Gradebook.Utilities.Common;

namespace Gradebook.RepositoryLayer.Repositories
{
    public class PupilRepository : IPupilInterface
    {
        private readonly IPupilInterface _provider = new PupilProvider();

        public List<Pupil> GetAllPupils()
        {
            return _provider.GetAllPupils();
        }

        public Pupil GetPupilById(int id)
        {
            return _provider.GetPupilById(id);
        }

        public Pupil InsertPupil(Pupil pupil, ITransaction transaction = null)
        {
            return _provider.InsertPupil(pupil, transaction);
        }

        public Pupil UpdatePupil(Pupil pupil, ITransaction transaction = null)
        {
            return _provider.UpdatePupil(pupil, transaction);
        }

        public void DeletePupil(Pupil pupil, ITransaction transaction = null)
        {
            _provider.DeletePupil(pupil, transaction);
        }

        public ITransaction CreateNewTransaction()
        {
            return _provider.CreateNewTransaction();
        }
    }
}
