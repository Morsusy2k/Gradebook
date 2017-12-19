using System.Collections.Generic;
using Gradebook.DataAccessLayer.Models;
using Gradebook.DataAccessLayer.SQLAccess.Providers;
using Gradebook.RepositoryLayer.Interfaces;
using Gradebook.Utilities.Common;

namespace Gradebook.RepositoryLayer.Repositories
{
    public class SubjectLessonRepository : ISubjectLessonInterface
    {
        private readonly ISubjectLessonInterface _provider = new SubjectLessonProvider();

        public List<SubjectLesson> GetAllSubjectLessons()
        {
            return _provider.GetAllSubjectLessons();
        }

        public SubjectLesson GetSubjectLessonById(int id)
        {
            return _provider.GetSubjectLessonById(id);
        }

        public SubjectLesson InsertSubjectLesson(SubjectLesson lesson, ITransaction transaction = null)
        {
            return _provider.InsertSubjectLesson(lesson, transaction);
        }

        public SubjectLesson UpdateSubjectLesson(SubjectLesson lesson, ITransaction transaction = null)
        {
            return _provider.UpdateSubjectLesson(lesson, transaction);
        }

        public void DeleteSubjectLesson(SubjectLesson lesson, ITransaction transaction = null)
        {
            _provider.DeleteSubjectLesson(lesson, transaction);
        }

        public ITransaction CreateNewTransaction()
        {
            return _provider.CreateNewTransaction();
        }
    }
}
