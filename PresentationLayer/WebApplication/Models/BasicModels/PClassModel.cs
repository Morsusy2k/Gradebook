using Gradebook.BusinessLogicLayer.Interfaces;
using Gradebook.BusinessLogicLayer.Managers;
using Gradebook.BusinessLogicLayer.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Gradebook.PresentationLayer.WebApplication.Models.BasicModels
{
    public class PClassModel
    {
        private readonly IFieldManager _fieldManager = new FieldManager();

        public PClassModel() { }
        public PClassModel(int userId, int fieldId, string generation, string year, int pclassIndex, int createdBy, DateTime createdDate, byte[] version, DateTime? modifiedDate = null, int? modifiedBy = null)
        {
            UserId = userId;
            FieldOfStudyId = fieldId;
            Generation = generation;
            Year = year;
            PClassIndex = pclassIndex;
            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            Version = version;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int FieldOfStudyId { get; set; }
        [Required]
        public string Generation { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public int PClassIndex { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] Version { get; set; }

        public string ClassName { get { return Year + "-" + PClassIndex + " ("+ _fieldManager.GetById(this.FieldOfStudyId).Name + ")"; } }

        public static implicit operator PClass(PClassModel pcm)
        {
            if (pcm == null)
                return null;

            PClass pclass = new PClass(pcm.UserId, pcm.FieldOfStudyId, pcm.Generation, pcm.Year, pcm.PClassIndex, pcm.CreatedBy, pcm.CreatedDate, pcm.Version, pcm.ModifiedDate, pcm.ModifiedBy)
            {
                Id = pcm.Id
            };

            return pclass;
        }

        public static implicit operator PClassModel(PClass p)
        {
            if (p == null)
                return null;

            PClassModel user = new PClassModel(p.UserId, p.FieldOfStudyId, p.Generation, p.Year, p.PClassIndex, p.CreatedBy, p.CreatedDate, p.Version, p.ModifiedDate, p.ModifiedBy)
            {
                Id = p.Id
            };

            return user;
        }
    }
}
