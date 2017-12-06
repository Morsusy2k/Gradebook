using System;
using System.Collections.Generic;
using System.Linq;
using Gradebook.BusinessLogicLayer.Interfaces;
using Gradebook.BusinessLogicLayer.Models;
using Gradebook.RepositoryLayer.Interfaces;
using Gradebook.RepositoryLayer.Repositories;
using Gradebook.Utilities.Common;

namespace Gradebook.BusinessLogicLayer.Managers
{
    public class FieldManager : IFieldManager
    {
        private readonly IFieldInterface _repository = new FieldRepository();
        private ITransaction _transaction;

        public IEnumerable<FieldOfStudy> GetAll()
        {
            return _repository.GetAllFields().Select(x => Map(x));
        }

        public FieldOfStudy GetById(int id)
        {
            return Map(_repository.GetFieldById(id));
        }

        public FieldOfStudy Add(FieldOfStudy field)
        {
            return Map(_repository.InsertField(Map(field)));
        }

        public FieldOfStudy Save(FieldOfStudy field)
        {
            return Map(_repository.UpdateField(Map(field)));
        }

        public void Remove(FieldOfStudy field)
        {
            _repository.DeleteField(Map(field));
        }

        public FieldOfStudy Map(DataAccessLayer.Models.FieldOfStudy dbField)
        {
            if (Equals(dbField, null))
                return null;

            FieldOfStudy field = new FieldOfStudy(dbField.Name, dbField.CreatedBy, dbField.CreatedDate, dbField.Version, dbField.ModifiedBy, dbField.ModifiedDate);
            field.Id = dbField.Id;
            field.Version = dbField.Version;

            return field;
        }

        public DataAccessLayer.Models.FieldOfStudy Map(FieldOfStudy field)
        {
            if (Equals(field, null))
                throw new ArgumentNullException("FieldOfStudy", "Valid field is mandatory!");

            return new DataAccessLayer.Models.FieldOfStudy(field.Id, field.Name, field.CreatedBy, field.CreatedDate, field.Version, field.ModifiedDate, field.ModifiedBy);
        }
    }
}
