using Gradebook.BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;

namespace Gradebook.BusinessLogicLayer.Interfaces
{
    public interface IMarkManager
    {
        Mark GetById(int id);
        IEnumerable<Mark> GetAll();
        IEnumerable<Mark> GetByMarksId(int id);
        IEnumerable<String> GetAllMarkTypes();
        IEnumerable<String> GetMarkTypesByMarksId(int id);
        decimal GetAverageByPupilId(int id);

        Mark Add(Mark mark);
        Mark Save(Mark mark);
        void Remove(Mark mark);

        Mark Map(DataAccessLayer.Models.Mark dbMark);
        DataAccessLayer.Models.Mark Map(Mark mark);
    }
}
