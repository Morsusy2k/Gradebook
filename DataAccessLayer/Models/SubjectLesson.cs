using System;

namespace Gradebook.DataAccessLayer.Models
{
    public class SubjectLesson
    {
        public SubjectLesson() { }
        public SubjectLesson(int id, int gradebookId, int subjectId, string lessonTheme, DateTime date, string timeOfLesson, int createdBy, DateTime createdDate, byte[] version, DateTime? modifiedDate = null, int? modifiedBy = null)
        {
            Id = id;
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
        public string LessonTheme { get; set; }
        public DateTime Date { get; set; }
        public string TimeOfLesson { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] Version { get; set; }
    }
}