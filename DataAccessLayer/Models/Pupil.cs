using System;

namespace Gradebook.DataAccessLayer.Models
{
    public class Pupil
    {
        public Pupil() { }
        public Pupil(int id, int pclassId, string name, int createdBy, DateTime createdDate, byte[] version, DateTime? modifiedDate = null, int? modifiedBy = null)
        {
            Id = id;
            PClassId = pclassId;
            Name = name;
            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            Version = version;
        }

        public int Id { get; set; }
        public int PClassId { get; set; }
        public string Name { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] Version { get; set; }
    }
}
