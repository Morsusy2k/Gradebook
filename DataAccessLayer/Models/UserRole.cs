using System;

namespace Gradebook.DataAccessLayer.Models
{
    public class UserRole
    {
        public UserRole() { }
        public UserRole(int id,int userId, int roleId, int createdBy, DateTime createdOn, byte[] version, int? modifiedBy, DateTime? modifiedOn)
        {
            Id = id;
            RoleId = roleId;
            UserId = userId;
            CreatedBy = createdBy;
            CreatedOn = createdOn;
            ModifiedBy = modifiedBy;
            ModifiedOn = modifiedOn;
            Version = version;
        }
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public byte[] Version { get; set; }
    }
}
