using Gradebook.PresentationLayer.WebApplication.Models.BasicModels;

namespace Gradebook.PresentationLayer.WebApplication.Models.ComplexModels
{
    public class ClassGbookModel
    {
        public PClassModel PClass { get; set; }
        public GbookModel Gradebook { get; set; }
    }
}