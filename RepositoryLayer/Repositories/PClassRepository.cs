using System.Collections.Generic;
using Gradebook.DataAccessLayer.Models;
using Gradebook.DataAccessLayer.SQLAccess.Providers;
using Gradebook.RepositoryLayer.Interfaces;
using Gradebook.Utilities.Common;

namespace Gradebook.RepositoryLayer.Repositories
{
    public class PClassRepository : IPClassInterface
    {
        private readonly IPClassInterface _provider = new PClassProvider();

        public List<PClass> GetAllPClasses()
        {
            return _provider.GetAllPClasses();
        }

        public PClass GetPClassById(int id)
        {
            return _provider.GetPClassById(id);
        }

        public PClass InsertPClass(PClass pclass, ITransaction transaction = null)
        {
            return _provider.InsertPClass(pclass, transaction);
        }

        public PClass UpdatePClass(PClass pclass, ITransaction transaction = null)
        {
            return _provider.UpdatePClass(pclass, transaction);
        }

        public void DeletePClass(PClass pclass, ITransaction transaction = null)
        {
            _provider.DeletePClass(pclass, transaction);
        }

        public ITransaction CreateNewTransaction()
        {
            return _provider.CreateNewTransaction();
        }
    }
}
