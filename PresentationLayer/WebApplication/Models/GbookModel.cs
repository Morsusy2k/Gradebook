using Gradebook.BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gradebook.PresentationLayer.WebApplication.Models
{
    public class GbookModel
    {
        public GbookModel() { }

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
        public DateTime SchoolYearStart { get; set; }
        public DateTime SchoolYearEnd { get; set; }
        public bool Editable { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] Version { get; set; }

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