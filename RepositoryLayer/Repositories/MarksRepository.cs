using System.Collections.Generic;
using Gradebook.DataAccessLayer.Models;
using Gradebook.DataAccessLayer.SQLAccess.Providers;
using Gradebook.RepositoryLayer.Interfaces;
using Gradebook.Utilities.Common;

namespace Gradebook.RepositoryLayer.Repositories
{
    public class MarksRepository : IMarksInterface
    {
        private readonly IMarksInterface _provider = new MarksProvider();

        public List<Marks> GetAllMarks()
        {
            return _provider.GetAllMarks();
        }

        public List<Marks> GetMarksByPupilId(int id)
        {
            return _provider.GetMarksByPupilId(id);
        }

        public Marks GetMarksPupilIdAndSubjectId(int pupilId, int subjectId)
        {
            return _provider.GetMarksPupilIdAndSubjectId(pupilId, subjectId);
        }

        public Marks GetMarksById(int id)
        {
            return _provider.GetMarksById(id);
        }

        public Marks InsertMarks(Marks marks, ITransaction transaction = null)
        {
            return _provider.InsertMarks(marks, transaction);
        }

        public Marks UpdateMarks(Marks marks, ITransaction transaction = null)
        {
            return _provider.UpdateMarks(marks, transaction);
        }

        public void DeleteMarks(Marks marks, ITransaction transaction = null)
        {
            _provider.DeleteMarks(marks, transaction);
        }

        public ITransaction CreateNewTransaction()
        {
            return _provider.CreateNewTransaction();
        }
    }
}
