using System.Configuration;

namespace Gradebook.Utilities.Common
{
    public static class AppSettings
    {
        //public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["GradebookDBConnection"].ConnectionString;
        public static readonly string ConnectionString = "Data Source=DESKTOP-39lugd9;Initial Catalog=Max.Gradebook;Integrated Security=True";
        public static readonly string SchoolName = "EGŠ Nikola Tesla";
    }
}