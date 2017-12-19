using Gradebook.BusinessLogicLayer.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Gradebook.PresentationLayer.WebApplication.Models.BasicModels
{
    public class MarkModel
    {
        public MarkModel() { }

        public MarkModel(int marksId, int grade, string type, int createdBy, DateTime createdDate, byte[] version, bool important = false, bool final = false, DateTime? modifiedDate = null, int? modifiedBy = null)
        {
            MarksId = marksId;
            Grade = grade;
            Type = type;
            Important = important;
            Final = final;
            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            Version = version;
        }

        public int Id { get; set; }
        public int MarksId { get; set; }
        public int Grade { get; set; }
        public string Type { get; set; }
        public bool Important { get; set; }
        public bool Final { get; set; }
        public int CreatedBy { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] Version { get; set; }

        public static implicit operator Mark(MarkModel mm)
        {
            if (mm == null)
                return null;

            Mark mark = new Mark(mm.MarksId, mm.Grade, mm.Type, mm.CreatedBy, mm.CreatedDate, mm.Version, mm.Important, mm.Final, mm.ModifiedDate, mm.ModifiedBy)
            {
                Id = mm.Id
            };

            return mark;
        }

        public static implicit operator MarkModel(Mark m)
        {
            if (m == null)
                return null;

            MarkModel mark = new MarkModel(m.MarksId, m.Grade, m.Type, m.CreatedBy, m.CreatedDate, m.Version, m.Important, m.Final, m.ModifiedDate, m.ModifiedBy)
            {
                Id = m.Id
            };

            return mark;
        }
    }
}