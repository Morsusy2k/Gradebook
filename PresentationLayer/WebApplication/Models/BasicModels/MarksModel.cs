using Gradebook.BusinessLogicLayer.Models;
using System;

namespace Gradebook.PresentationLayer.WebApplication.Models.BasicModels
{
    public class MarksModel
    {
        public MarksModel() { }

        public MarksModel(int pupilId, int subjectId, int createdBy, DateTime createdDate, byte[] version, int? finalMark = null, DateTime? modifiedDate = null, int? modifiedBy = null)
        {
            PupilId = pupilId;
            SubjectId = subjectId;
            FinalMark = finalMark;
            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            Version = version;
        }

        public int Id { get; set; }
        public int PupilId { get; set; }
        public int SubjectId { get; set; }
        public int? FinalMark { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] Version { get; set; }

        public static implicit operator Marks(MarksModel mm)
        {
            if (mm == null)
                return null;

            Marks marks = new Marks(mm.PupilId, mm.SubjectId, mm.CreatedBy, mm.CreatedDate, mm.Version, mm.FinalMark, mm.ModifiedDate, mm.ModifiedBy)
            {
                Id = mm.Id
            };

            return marks;
        }

        public static implicit operator MarksModel(Marks m)
        {
            if (m == null)
                return null;

            MarksModel marks = new MarksModel(m.PupilId, m.SubjectId, m.CreatedBy, m.CreatedDate, m.Version, m.FinalMark, m.ModifiedDate, m.ModifiedBy)
            {
                Id = m.Id
            };

            return marks;
        }
    }
}