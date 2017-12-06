using Gradebook.DataAccessLayer.Models;
using Gradebook.Utilities.Common;
using System.Collections.Generic;

namespace Gradebook.RepositoryLayer.Interfaces
{
    public interface IPClassInterface
    {
        PClass GetPClassById(int id);
        List<PClass> GetAllPClasses();

        PClass InsertPClass(PClass pclass, ITransaction transaction = null);
        PClass UpdatePClass(PClass pclass, ITransaction transaction = null);
        void DeletePClass(PClass pclass, ITransaction transaction = null);

        ITransaction CreateNewTransaction();
    }
}
