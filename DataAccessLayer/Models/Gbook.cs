using System;

namespace Gradebook.DataAccessLayer.Models
{
    public class Gbook
    {
        public Gbook() { }
        public Gbook(int id, int pclassId, DateTime schoolYearStart, DateTime schoolYearEnd, bool editable, int createdBy, DateTime createdDate, byte[] version, DateTime? modifiedDate = null, int? modifiedBy = null)
        {
            Id = id;
            PClassId = pclassId;
            SchoolYearStart = schoolYearStart;
            SchoolYearEnd = schoolYearEnd;
            Editable = editable;
            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            Version = version;
        }

        public int Id { get; set; }
        public int PClassId { get; set; }
        public DateTime SchoolYearStart { get; set; }
        public DateTime SchoolYearEnd { get; set; }
        public bool Editable { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] Version { get; set; }
    }
}
