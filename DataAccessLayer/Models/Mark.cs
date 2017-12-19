using System;

namespace Gradebook.DataAccessLayer.Models
{
    public class Mark
    {
        public Mark() { }
        public Mark(int id, int marksId, int grade, string type, int createdBy, DateTime createdDate, byte[] version, bool important = false, bool final = false, DateTime? modifiedDate = null, int? modifiedBy = null)
        {
            Id = id;
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
        public int? ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] Version { get; set; }
    }
}
