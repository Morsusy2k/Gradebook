using System;

namespace Gradebook.DataAccessLayer.Models
{
    public class Marks
    {
        public Marks() { }
        public Marks(int id, int pupilId, int subjectId, int createdBy, DateTime createdDate, byte[] version, int? finalMark = null, DateTime? modifiedDate = null, int? modifiedBy = null)
        {
            Id = id;
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
        public int? ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] Version { get; set; }
    }
}
