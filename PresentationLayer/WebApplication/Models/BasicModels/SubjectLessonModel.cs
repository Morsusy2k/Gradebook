using Gradebook.BusinessLogicLayer.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Gradebook.PresentationLayer.WebApplication.Models.BasicModels
{
    public class SubjectLessonModel
    {
        public SubjectLessonModel() { }
        public SubjectLessonModel(int gradebookId, int subjectId, string lessonTheme, DateTime date, string timeOfLesson, int createdBy, DateTime createdDate, byte[] version, DateTime? modifiedDate = null, int? modifiedBy = null)
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
        public string LessonTheme { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }
        public string TimeOfLesson { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] Version { get; set; }

        public static implicit operator SubjectLesson(SubjectLessonModel sml)
        {
            if (sml == null)
                return null;

            SubjectLesson lesson = new SubjectLesson(sml.GradebookId, sml.SubjectId, sml.LessonTheme, sml.Date, sml.TimeOfLesson, sml.CreatedBy, sml.CreatedDate, sml.Version, sml.ModifiedDate, sml.ModifiedBy)
            {
                Id = sml.Id
            };

            return lesson;
        }

        public static implicit operator SubjectLessonModel(SubjectLesson sl)
        {
            if (sl == null)
                return null;

            SubjectLessonModel subject = new SubjectLessonModel(sl.GradebookId, sl.SubjectId, sl.LessonTheme, sl.Date, sl.TimeOfLesson, sl.CreatedBy, sl.CreatedDate, sl.Version, sl.ModifiedDate, sl.ModifiedBy)
            {
                Id = sl.Id
            };

            return subject;
        }
    }
}