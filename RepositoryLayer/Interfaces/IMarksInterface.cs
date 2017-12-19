using Gradebook.DataAccessLayer.Models;
using Gradebook.Utilities.Common;
using System.Collections.Generic;

namespace Gradebook.RepositoryLayer.Interfaces
{
    public interface IMarksInterface
    {
        Marks GetMarksById(int id);
        List<Marks> GetAllMarks();
        List<Marks> GetMarksByPupilId(int id);
        Marks GetMarksPupilIdAndSubjectId(int pupilId, int subjectId);

        Marks InsertMarks(Marks marks, ITransaction transaction = null);
        Marks UpdateMarks(Marks marks, ITransaction transaction = null);
        void DeleteMarks(Marks marks, ITransaction transaction = null);

        ITransaction CreateNewTransaction();
    }
}
