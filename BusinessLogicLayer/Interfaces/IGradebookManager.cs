using Gradebook.BusinessLogicLayer.Models;
using System.Collections.Generic;

namespace Gradebook.BusinessLogicLayer.Interfaces
{
    public interface IGradebookManager
    {
        Gbook GetById(int id);
        IEnumerable<Gbook> GetAll();

        Gbook Add(Gbook gBook);
        Gbook Save(Gbook gBook);
        void Remove(Gbook gBook);

        Gbook Map(DataAccessLayer.Models.Gbook dbGbook);
        DataAccessLayer.Models.Gbook Map(Gbook gBook);
    }
}
