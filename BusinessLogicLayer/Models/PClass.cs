using System;
using System.Diagnostics;

namespace Gradebook.BusinessLogicLayer.Models
{
    public class PClass
    {
        public DateTime createdDate { get; set; }
        public DateTime generation { get; set; }
        public string year { get; set; }

        public PClass() { }
        public PClass(int userId, int fieldId, DateTime generation, string year, int pclassIndex, int createdBy, DateTime createdDate, byte[] version, DateTime? modifiedDate = null, int? modifiedBy = null)
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
        public int PClassIndex { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] Version { get; set; }

        public DateTime Generation
        {
            get
            {
                Debug.Assert(createdDate != null);
                return generation;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("generation", "Valid generation is mandatory!");

                DateTime oldValue = generation;
                try
                {
                    generation = value;
                }
                catch
                {
                    generation = oldValue;
                    throw;
                }
            }
        }
        public string Year
        {
            get
            {
                Debug.Assert(year != null);
                return year;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("year", "Valid year is mandatory!");

                string oldValue = year;
                try
                {
                    year = value;
                }
                catch
                {
                    year = oldValue;
                    throw;
                }
            }
        }
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
