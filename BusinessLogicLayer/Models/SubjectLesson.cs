using System;
using System.Diagnostics;

namespace Gradebook.BusinessLogicLayer.Models
{
    public class SubjectLesson
    {
        public string lessonTheme { get; set; }
        public string timeOfLesson { get; set; }
        public DateTime createdDate { get; set; }

        public SubjectLesson() { }
        public SubjectLesson(int gradebookId, int subjectId, string lessonTheme, DateTime date, string timeOfLesson, int createdBy, DateTime createdDate, byte[] version, DateTime? modifiedDate = null, int? modifiedBy = null)
        {
            GradebookId = gradebookId;
            SubjectId = subjectId;
            LessonTheme = lessonTheme;
            Date = date;
            TimeOfLesson = timeOfLesson;
            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            Version = version;
        }

        public int Id { get; set; }
        public int GradebookId { get; set; }
        public int SubjectId { get; set; }
        public DateTime Date { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] Version { get; set; }

        public string LessonTheme
        {
            get
            {
                Debug.Assert(lessonTheme != null);
                return lessonTheme;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("lessonTheme", "Valid lessonTheme is mandatory!");

                string oldValue = lessonTheme;
                try
                {
                    lessonTheme = value;
                }
                catch
                {
                    lessonTheme = oldValue;
                    throw;
                }
            }
        }
        public string TimeOfLesson
        {
            get
            {
                Debug.Assert(timeOfLesson != null);
                return timeOfLesson;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("timeOfLesson", "Valid timeOfLesson is mandatory!");

                string oldValue = timeOfLesson;
                try
                {
                    timeOfLesson = value;
                }
                catch
                {
                    timeOfLesson = oldValue;
                    throw;
                }
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                Debug.Assert(createdDate != null);
                return createdDate;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("createdDate", "Valid createdDate is mandatory!");

                DateTime oldValue = createdDate;
                try
                {
                    createdDate = value;
                }
                catch
                {
                    createdDate = oldValue;
                    throw;
                }
            }
        }
    }
}