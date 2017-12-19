using Gradebook.DataAccessLayer.Models;
using Gradebook.Utilities.Common;
using System;
using System.Collections.Generic;

namespace Gradebook.RepositoryLayer.Interfaces
{
    public interface IMarkInterface
    {
        Mark GetMarkById(int id);
        List<Mark> GetAllMarks();
        List<Mark> GetMarksByMarksId(int id);
        List<String> GetAllMarkTypes();
        List<String> GetMarkTypesByMarksId(int id);
        decimal GetAverageByPupilId(int id);

        Mark InsertMark(Mark mark, ITransaction transaction = null);
        Mark UpdateMark(Mark mark, ITransaction transaction = null);
        void DeleteMark(Mark mark, ITransaction transaction = null);

        ITransaction CreateNewTransaction();
    }
}
