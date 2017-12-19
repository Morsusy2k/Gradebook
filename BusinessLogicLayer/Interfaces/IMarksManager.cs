using Gradebook.BusinessLogicLayer.Models;
using System.Collections.Generic;

namespace Gradebook.BusinessLogicLayer.Interfaces
{
    public interface IMarksManager
    {
        Marks GetById(int id);
        IEnumerable<Marks> GetAll();
        IEnumerable<Marks> GetByPupilId(int id);
        Marks GetByPupilIdAndSubjectId(int pupilId, int subjectId);

        Marks Add(Marks marks);
        Marks Save(Marks marks);
        void Remove(Marks marks);

        Marks Map(DataAccessLayer.Models.Marks dbPupil);
        DataAccessLayer.Models.Marks Map(Marks pupil);
    }
}
