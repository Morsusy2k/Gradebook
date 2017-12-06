using System;

namespace Gradebook.DataAccessLayer.Models
{
    public class Subject
    {
        public Subject() { }
        public Subject(int id, int userId, string name, int createdBy, DateTime createdDate, byte[] version, DateTime? modifiedDate = null, int? modifiedBy = null)
        {
            Id = id;
            UserId = userId;
            Name = name;
            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            Version = version;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] Version { get; set; }
    }
}
