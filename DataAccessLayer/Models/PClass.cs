using System;

namespace Gradebook.DataAccessLayer.Models
{
    public class PClass
    {
        public PClass() { }
        public PClass(int id, int userId, int fieldId, DateTime generation, string year, int pclassIndex, int createdBy, DateTime createdDate, byte[] version, DateTime? modifiedDate = null, int? modifiedBy = null)
        {
            Id = id;
            UserId = userId;
            FieldOfStudyId = fieldId;
            Generation = generation;
            Year = year;
            PClassIndex = pclassIndex;
            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            Version = version;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int FieldOfStudyId { get; set; }
        public DateTime Generation { get; set; }
        public string Year { get; set; }
        public int PClassIndex { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] Version { get; set; }
    }
}
