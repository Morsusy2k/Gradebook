using Gradebook.BusinessLogicLayer.Models;
using System;

namespace Gradebook.PresentationLayer.WebApplication.Models
{
    public class FieldModel
    {
        public FieldModel() { }
        public FieldModel(string name, int createdBy, DateTime createdDate, byte[] version, int? modifiedBy = null, DateTime? modifiedDate = null)
        {
            Name = name;
            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            Version = version;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] Version { get; set; }

        public static implicit operator FieldOfStudy(FieldModel fm)
        {
            if (fm == null)
                return null;

            FieldOfStudy field = new FieldOfStudy(fm.Name, fm.CreatedBy, fm.CreatedDate, fm.Version, fm.ModifiedBy, fm.ModifiedDate)
            {
                Id = fm.Id
            };

            return field;
        }

        public static implicit operator FieldModel(FieldOfStudy fos)
        {
            if (fos == null)
                return null;

            FieldModel field = new FieldModel(fos.Name, fos.CreatedBy, fos.CreatedDate, fos.Version, fos.ModifiedBy, fos.ModifiedDate)
            {
                Id = fos.Id
            };

            return field;
        }
    }
}
