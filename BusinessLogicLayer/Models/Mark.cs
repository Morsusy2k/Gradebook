using System;
using System.Diagnostics;

namespace Gradebook.BusinessLogicLayer.Models
{
    public class Mark
    {
        public DateTime createdDate { get; set; }
        public string type { get; set; }

        public Mark() { }
        public Mark(int marksId, int grade, string type, int createdBy, DateTime createdDate, byte[] version, bool important = false, bool final = false, DateTime? modifiedDate = null, int? modifiedBy = null)
        {
            MarksId = marksId;
            Grade = grade;
            Type = type;
            Important = important;
            Final = final;
            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            Version = version;
        }

        public int Id { get; set; }
        public int MarksId { get; set; }
        public int Grade { get; set; }
        public bool Important { get; set; }
        public bool Final { get; set; }
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
        public string Type
        {
            get
            {
                Debug.Assert(type != null);
                return type;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("type", "Valid type is mandatory!");

                string oldValue = type;
                try
                {
                    type = value;
                }
                catch
                {
                    type = oldValue;
                    throw;
                }
            }
        }

    }
}
