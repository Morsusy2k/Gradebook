using Gradebook.PresentationLayer.WebApplication.Models.BasicModels;
using System.Collections.Generic;

namespace Gradebook.PresentationLayer.WebApplication.Models.ComplexModels
{
    public class MarksDetailsModel
    {
        public PupilModel Pupil { get; set; }
        public SubjectModel Subject { get; set; }
        public UserModel Professor { get; set; }
        public MarksModel Marks { get; set; }
        public PClassModel PClass { get; set; }
        public IEnumerable<MarkModel> Grades { get; set; }
    }
}