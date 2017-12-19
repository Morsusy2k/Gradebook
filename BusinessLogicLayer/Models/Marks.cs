using System;
using System.Diagnostics;

namespace Gradebook.BusinessLogicLayer.Models
{
    public class Marks
    {
        public DateTime createdDate { get; set; }

        public Marks() { }
        public Marks(int pupilId, int subjectId, int createdBy, DateTime createdDate, byte[] version, int? finalMark = null, DateTime? modifiedDate = null, int? modifiedBy = null)
        {
            PupilId = pupilId;
            SubjectId = subjectId;
            FinalMark = finalMark;
            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            Version = version;
        }

        public int Id { get; set; }
        public int PupilId { get; set; }
        public int SubjectId { get; set; }
        public int? FinalMark { get; set; }
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

    }
}
