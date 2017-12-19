using System.Collections.Generic;
using Gradebook.DataAccessLayer.Models;
using Gradebook.DataAccessLayer.SQLAccess.Providers;
using Gradebook.RepositoryLayer.Interfaces;
using Gradebook.Utilities.Common;

namespace Gradebook.RepositoryLayer.Repositories
{
    public class GradebookRepository : IGradebookInterface
    {
        private readonly IGradebookInterface _provider = new GradebookProvider();

        public List<Gbook> GetAllGradebooks()
        {
            return _provider.GetAllGradebooks();
        }

        public Gbook GetGradebookById(int id)
        {
            return _provider.GetGradebookById(id);
        }

        public Gbook GetGradebookByClassId(int id)
        {
            return _provider.GetGradebookByClassId(id);
        }

        public Gbook InsertGradebook(Gbook gradebook, ITransaction transaction = null)
        {
            return _provider.InsertGradebook(gradebook, transaction);
        }

        public Gbook UpdateGradebook(Gbook gradebook, ITransaction transaction = null)
        {
            return _provider.UpdateGradebook(gradebook, transaction);
        }

        public void DeleteGradebook(Gbook gradebook, ITransaction transaction = null)
        {
            _provider.DeleteGradebook(gradebook, transaction);
        }

        public ITransaction CreateNewTransaction()
        {
            return _provider.CreateNewTransaction();
        }
    }
}
