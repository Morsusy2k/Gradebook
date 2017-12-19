using Gradebook.PresentationLayer.WebApplication.Models.BasicModels;
using System.Collections.Generic;

namespace Gradebook.PresentationLayer.WebApplication.Models.ComplexModels
{
    public class PupilDetailsModel
    {
        public IEnumerable<SubjectModel> Subjects { get; set; }
        public PupilModel Pupil { get; set; }
        public PClassModel Pclass { get; set; }
        public FieldModel Field { get; set; }
    }
}