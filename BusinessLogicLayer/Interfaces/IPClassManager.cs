using Gradebook.BusinessLogicLayer.Models;
using System.Collections.Generic;

namespace Gradebook.BusinessLogicLayer.Interfaces
{
    public interface IPClassManager
    {
        PClass GetById(int id);
        IEnumerable<PClass> GetAll();

        PClass Add(PClass pclass);
        PClass Save(PClass pclass);
        void Remove(PClass pclass);

        PClass Map(DataAccessLayer.Models.PClass dbPClass);
        DataAccessLayer.Models.PClass Map(PClass pClass);
    }
}
