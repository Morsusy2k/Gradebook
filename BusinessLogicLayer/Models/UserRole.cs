using System;

namespace Gradebook.BusinessLogicLayer.Models
{
    public class UserRole
    {
        public UserRole() { }
        public UserRole(int userId, int roleId, int createdBy, DateTime createdDate, byte[] version, int? modifiedBy = null, DateTime? modifiedDate = null)
        {
            RoleId = roleId;
            UserId = userId;
            CreatedBy = createdBy;
            CreatedDate = createdDate;
            ModifiedBy = modifiedBy;
            ModifiedDate = modifiedDate;
            Version = version;
        }
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] Version { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
