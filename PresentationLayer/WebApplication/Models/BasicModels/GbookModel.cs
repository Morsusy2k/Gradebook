using Gradebook.BusinessLogicLayer.Interfaces;
using Gradebook.BusinessLogicLayer.Managers;
using Gradebook.BusinessLogicLayer.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Gradebook.PresentationLayer.WebApplication.Models.BasicModels
{
    public class GbookModel
    {
        public GbookModel() { }
        private readonly IPClassManager _classManager = new PClassManager();
        private readonly IFieldManager _fieldManager = new FieldManager();

        public GbookModel(int pclassId, DateTime schoolYearStart, DateTime schoolYearEnd, bool editable, int createdBy, DateTime createdDate, byte[] version, DateTime? modifiedDate = null, int? modifiedBy = null)
        {
            PClassId = pclassId;
            SchoolYearStart = schoolYearStart;
            SchoolYearEnd = schoolYearEnd;
            Editable = editable;
            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            Version = version;
        }

        public int Id { get; set; }
        public int PClassId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime SchoolYearStart { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime SchoolYearEnd { get; set; }
        public bool Editable { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] Version { get; set; }
        public string ClassName
        {
            get
            {
                PClassModel pClass = _classManager.GetById(this.PClassId);
                FieldModel field = _fieldManager.GetById(pClass.FieldOfStudyId);
                return pClass.Year + " - " + pClass.PClassIndex;
            }
        }
        public string ClassNameAndField
        {
            get
            {
                PClassModel pClass = _classManager.GetById(this.PClassId);
                FieldModel field = _fieldManager.GetById(pClass.FieldOfStudyId);
                return pClass.Year + " - " + pClass.PClassIndex + " (" + field.Name + ")";
            }
        }

        public static implicit operator Gbook(GbookModel gm)
        {
            if (gm == null)
                return null;

            Gbook gbook = new Gbook(gm.PClassId, gm.SchoolYearStart, gm.SchoolYearEnd, gm.Editable, gm.CreatedBy, gm.CreatedDate, gm.Version, gm.ModifiedDate, gm.ModifiedBy)
            {
                Id = gm.Id
            };

            return gbook;
        }

        public static implicit operator GbookModel(Gbook g)
        {
            if (g == null)
                return null;

            GbookModel gbook = new GbookModel(g.PClassId, g.SchoolYearStart, g.SchoolYearEnd, g.Editable, g.CreatedBy, g.CreatedDate, g.Version, g.ModifiedDate, g.ModifiedBy)
            {
                Id = g.Id
            };

            return gbook;
        }
    }
}