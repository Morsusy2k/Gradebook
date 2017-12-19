using Gradebook.DataAccessLayer.Models;
using Gradebook.Utilities.Common;
using System.Collections.Generic;

namespace Gradebook.RepositoryLayer.Interfaces
{
    public interface IFieldInterface
    {
        FieldOfStudy GetFieldById(int id);
        List<FieldOfStudy> GetAllFields();

        FieldOfStudy InsertField(FieldOfStudy field, ITransaction transaction = null);
        void InsertFieldSubject(FieldOfStudy field, Subject subject, int creatorId, ITransaction transaction = null);
        FieldOfStudy UpdateField(FieldOfStudy field, ITransaction transaction = null);
        void DeleteField(FieldOfStudy field, ITransaction transaction = null);
        void DeleteFieldSubjects(FieldOfStudy field, ITransaction transaction = null);

        ITransaction CreateNewTransaction();
    }
}
