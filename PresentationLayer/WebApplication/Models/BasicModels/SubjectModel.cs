using Gradebook.BusinessLogicLayer.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Gradebook.PresentationLayer.WebApplication.Models.BasicModels
{
    public class SubjectModel
    {
        public SubjectModel() { }

        public SubjectModel(int userId, string name, int createdBy, DateTime createdDate, byte[] version, DateTime? modifiedDate = null, int? modifiedBy = null)
        {
            UserId = userId;
            Name = name;
            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            Version = version;
        }

        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] Version { get; set; }

        public bool IsChecked { get; set; }

        public static implicit operator Subject(SubjectModel sm)
        {
            if (sm == null)
                return null;

            Subject subject = new Subject(sm.UserId, sm.Name, sm.CreatedBy, sm.CreatedDate, sm.Version, sm.ModifiedDate, sm.ModifiedBy)
            {
                Id = sm.Id
            };

            return subject;
        }

        public static implicit operator SubjectModel(Subject s)
        {
            if (s == null)
                return null;

            SubjectModel subject = new SubjectModel(s.UserId, s.Name, s.CreatedBy, s.CreatedDate, s.Version, s.ModifiedDate, s.ModifiedBy)
            {
                Id = s.Id
            };

            return subject;
        }
    }
}