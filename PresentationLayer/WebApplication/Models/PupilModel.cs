using Gradebook.BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gradebook.PresentationLayer.WebApplication.Models
{
    public class PupilModel
    {
        public PupilModel() { }

        public PupilModel(int pclassId, string name, int createdBy, DateTime createdDate, byte[] version, DateTime? modifiedDate = null, int? modifiedBy = null)
        {
            PClassId = pclassId;
            Name = name;
            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            Version = version;
        }

        public int Id { get; set; }
        public int PClassId { get; set; }
        public string Name { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] Version { get; set; }

        public static implicit operator Pupil(PupilModel pm)
        {
            if (pm == null)
                return null;

            Pupil pupil = new Pupil(pm.PClassId, pm.Name, pm.CreatedBy, pm.CreatedDate, pm.Version, pm.ModifiedDate, pm.ModifiedBy)
            {
                Id = pm.Id
            };

            return pupil;
        }

        public static implicit operator PupilModel(Pupil p)
        {
            if (p == null)
                return null;

            PupilModel user = new PupilModel(p.PClassId, p.Name, p.CreatedBy, p.CreatedDate, p.Version, p.ModifiedDate, p.ModifiedBy)
            {
                Id = p.Id
            };

            return user;
        }
    }
}