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
    public class SubjectLessonManager : ISubjectLessonManager
    {
        private readonly ISubjectLessonInterface _repository = new SubjectLessonRepository();
        private ITransaction _transaction;

        public IEnumerable<SubjectLesson> GetAll()
        {
            return _repository.GetAllSubjectLessons().Select(x => Map(x));
        }

        public SubjectLesson GetById(int id)
        {
            return Map(_repository.GetSubjectLessonById(id));
        }

        public SubjectLesson Add(SubjectLesson lesson)
        {
            return Map(_repository.InsertSubjectLesson(Map(lesson)));
        }

        public SubjectLesson Save(SubjectLesson lesson)
        {
            return Map(_repository.UpdateSubjectLesson(Map(lesson)));
        }

        public void Remove(SubjectLesson lesson)
        {
            _repository.DeleteSubjectLesson(Map(lesson));
        }

        public SubjectLesson Map(DataAccessLayer.Models.SubjectLesson dbLesson)
        {
            if (Equals(dbLesson, null))
                return null;

            SubjectLesson lesson = new SubjectLesson(dbLesson.GradebookId, dbLesson.SubjectId, dbLesson.LessonTheme, dbLesson.Date, dbLesson.TimeOfLesson, dbLesson.CreatedBy, dbLesson.CreatedDate, dbLesson.Version, dbLesson.ModifiedDate, dbLesson.ModifiedBy);
            lesson.Id = dbLesson.Id;
            lesson.Version = dbLesson.Version;

            return lesson;
        }

        public DataAccessLayer.Models.SubjectLesson Map(SubjectLesson lesson)
        {
            if (Equals(lesson, null))
                throw new ArgumentNullException("lesson", "Valid lesson is mandatory!");

            return new DataAccessLayer.Models.SubjectLesson(lesson.Id, lesson.GradebookId, lesson.SubjectId, lesson.LessonTheme, lesson.Date, lesson.TimeOfLesson, lesson.CreatedBy, lesson.CreatedDate, lesson.Version, lesson.ModifiedDate, lesson.ModifiedBy);
        }
    }
}
