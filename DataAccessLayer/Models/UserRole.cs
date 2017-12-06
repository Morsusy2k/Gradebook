using System;
using System.Diagnostics;

namespace Gradebook.DataAccessLayer.Models
{
    public class UserRole
    {
        private DateTime createdDate;

        public UserRole() { }
        public UserRole(int id,int userId, int roleId, int createdBy, DateTime createdDate, byte[] version, int? modifiedBy = null, DateTime? modifiedDate = null)
        {
            Id = id;
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

        public DateTime CreatedDate
        {
            get
            {
                Debug.Assert(createdDate != null);
                return createdDate;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("createdDate", "Valid createdDate is mandatory!");

                DateTime oldValue = createdDate;
                try
                {
                    createdDate = value;
                }
                catch
                {
                    createdDate = oldValue;
                    throw;
                }
            }
        }
    }
}
