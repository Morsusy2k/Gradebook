namespace PresentationLayer.WebApplication.Models.Identity
{
    public class CustomPrincipalSerializeModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string[] Roles { get; set; }
    }
}