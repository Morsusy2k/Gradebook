using System.Configuration;

namespace Gradebook.Utilities.Common
{
    public static class AppSettings
    {
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["GradebookDBConnection"].ConnectionString;
    }
}