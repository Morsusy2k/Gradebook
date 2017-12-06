using System;
using System.Diagnostics;

namespace Gradebook.BusinessLogicLayer.Models
{
    public class Gbook
    {
        public DateTime createdDate { get; set; }
        public DateTime schoolYearStart { get; set; }
        public DateTime schoolYearEnd { get; set; }

        public Gbook() { }
        public Gbook(int pclassId, DateTime schoolYearStart, DateTime schoolYearEnd, bool editable, int createdBy, DateTime createdDate, byte[] version, DateTime? modifiedDate = null, int? modifiedBy = null)
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
        public bool Editable { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] Version { get; set; }

        public DateTime CreatedDate
        {
            get
            {
                Debug.Assert(createdDate != null);
                return createdDate;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("createdDate", "Valid createdDate is mandatory!");

                DateTime oldValue = createdDate;
                try
                {
                    createdDate = value;
                }
                catch
                {
                    createdDate = oldValue;
                    throw;
                }
            }
        }

        public DateTime SchoolYearStart
        {
            get
            {
                Debug.Assert(schoolYearStart != null);
                return schoolYearStart;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("schoolYearStart", "Valid schoolYearStart is mandatory!");

                DateTime oldValue = schoolYearStart;
                try
                {
                    schoolYearStart = value;
                }
                catch
                {
                    schoolYearStart = oldValue;
                    throw;
                }
            }
        }

        public DateTime SchoolYearEnd
        {
            get
            {
                Debug.Assert(schoolYearEnd != null);
                return schoolYearEnd;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("schoolYearEnd", "Valid schoolYearEnd is mandatory!");

                DateTime oldValue = schoolYearEnd;
                try
                {
                    schoolYearEnd = value;
                }
                catch
                {
                    schoolYearEnd = oldValue;
                    throw;
                }
            }
        }
    }
}
