using Gradebook.BusinessLogicLayer.Models;
using System.Collections.Generic;

namespace Gradebook.BusinessLogicLayer.Interfaces
{
    public interface IPupilManager
    {
        Pupil GetById(int id);
        IEnumerable<Pupil> GetAll();

        Pupil Add(Pupil pupil);
        Pupil Save(Pupil pupil);
        void Remove(Pupil pupil);

        Pupil Map(DataAccessLayer.Models.Pupil dbPupil);
        DataAccessLayer.Models.Pupil Map(Pupil pupil);
    }
}
