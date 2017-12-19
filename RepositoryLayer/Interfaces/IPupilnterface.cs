using Gradebook.DataAccessLayer.Models;
using Gradebook.Utilities.Common;
using System.Collections.Generic;

namespace Gradebook.RepositoryLayer.Interfaces
{
    public interface IPupilInterface
    {
        Pupil GetPupilById(int id);
        List<Pupil> GetAllPupils();
        List<Pupil> GetPupilsByClassId(int id);

        Pupil InsertPupil(Pupil pupil, ITransaction transaction = null);
        Pupil UpdatePupil(Pupil pupil, ITransaction transaction = null);
        void DeletePupil(Pupil pupil, ITransaction transaction = null);

        ITransaction CreateNewTransaction();
    }
}
