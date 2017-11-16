namespace Gradebook.DataAccessLayer.Models
{
    public class UserRole
    {
        public UserRole() { }
        public UserRole(int id, int userEditorId, int roleId, int userId, byte[] version)
        {
            Id = id;
            UserEditorId = userEditorId;
            RoleId = roleId;
            UserId = userId;
            Version = version;
        }
        public int Id { get; set; }
        public int UserEditorId { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public byte[] Version { get; set; }
    }
}
