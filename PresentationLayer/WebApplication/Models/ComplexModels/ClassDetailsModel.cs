using Gradebook.PresentationLayer.WebApplication.Models.BasicModels;
using System.Collections.Generic;

namespace Gradebook.PresentationLayer.WebApplication.Models.ComplexModels
{
    public class ClassDetailsModel
    {
        public GbookModel ClassGradebook { get; set; }
        public PClassModel ClassClass { get; set; }
        public FieldModel ClassField { get; set; }
        public UserModel ClassProfessor { get; set; }
        public IEnumerable<PupilModel> ClassPupils { get; set; }
    }
}