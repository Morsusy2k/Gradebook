using System;
using System.Diagnostics;

namespace Gradebook.BusinessLogicLayer.Models
{
    public class UserRole
    {
        private string name { get; set; }
        private string surname { get; set; }
        private string username { get; set; }
        private string password { get; set; }
        private string email { get; set; }


        public UserRole() { }
        public UserRole(int userId, int roleId, int createdBy, DateTime createdOn, byte[] version, int? modifiedBy, DateTime? modifiedOn)
        {
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
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public byte[] Version { get; set; }

        public DateTime CreatedOn { get; set; }


    }
}
