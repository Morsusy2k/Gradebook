using Gradebook.DataAccessLayer.Models;
using Gradebook.Utilities.Common;
using System.Collections.Generic;

namespace Gradebook.RepositoryLayer.Interfaces
{
    public interface IGradebookInterface
    {
        Gbook GetGradebookById(int id);
        List<Gbook> GetAllGradebooks();

        Gbook InsertGradebook(Gbook gradebook, ITransaction transaction = null);
        Gbook UpdateGradebook(Gbook gradebook, ITransaction transaction = null);
        void DeleteGradebook(Gbook gradebook, ITransaction transaction = null);

        ITransaction CreateNewTransaction();
    }
}
