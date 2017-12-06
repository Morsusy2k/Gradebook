using System.Collections.Generic;
using Gradebook.DataAccessLayer.Models;
using Gradebook.DataAccessLayer.SQLAccess.Providers;
using Gradebook.RepositoryLayer.Interfaces;
using Gradebook.Utilities.Common;

namespace Gradebook.RepositoryLayer.Repositories
{
    public class FieldRepository : IFieldInterface
    {
        private readonly IFieldInterface _provider = new FieldProvider();

        public List<FieldOfStudy> GetAllFields()
        {
            return _provider.GetAllFields();
        }

        public FieldOfStudy GetFieldById(int id)
        {
            return _provider.GetFieldById(id);
        }

        public FieldOfStudy InsertField(FieldOfStudy field, ITransaction transaction = null)
        {
            return _provider.InsertField(field, transaction);
        }

        public FieldOfStudy UpdateField(FieldOfStudy field, ITransaction transaction = null)
        {
            return _provider.UpdateField(field, transaction);
        }

        public void DeleteField(FieldOfStudy field, ITransaction transaction = null)
        {
            _provider.DeleteField(field, transaction);
        }

        public ITransaction CreateNewTransaction()
        {
            return _provider.CreateNewTransaction();
        }
    }
}
