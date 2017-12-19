using Gradebook.DataAccessLayer.Models;
using Gradebook.Utilities.Common;
using System.Collections.Generic;

namespace Gradebook.RepositoryLayer.Interfaces
{
    public interface ISubjectLessonInterface
    {
        SubjectLesson GetSubjectLessonById(int id);
        List<SubjectLesson> GetAllSubjectLessons();

        SubjectLesson InsertSubjectLesson(SubjectLesson lesson, ITransaction transaction = null);
        SubjectLesson UpdateSubjectLesson(SubjectLesson lesson, ITransaction transaction = null);
        void DeleteSubjectLesson(SubjectLesson lesson, ITransaction transaction = null);

        ITransaction CreateNewTransaction();
    }
}
