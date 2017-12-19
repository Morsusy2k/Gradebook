using Gradebook.BusinessLogicLayer.Models;
using System.Collections.Generic;

namespace Gradebook.BusinessLogicLayer.Interfaces
{
    public interface ISubjectLessonManager
    {
        SubjectLesson GetById(int id);
        IEnumerable<SubjectLesson> GetAll();

        SubjectLesson Add(SubjectLesson lesson);
        SubjectLesson Save(SubjectLesson lesson);
        void Remove(SubjectLesson lesson);

        SubjectLesson Map(DataAccessLayer.Models.SubjectLesson dbLesson);
        DataAccessLayer.Models.SubjectLesson Map(SubjectLesson lesson);
    }
}
