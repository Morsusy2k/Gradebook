using System.Collections.Generic;
using Gradebook.DataAccessLayer.Models;
using Gradebook.DataAccessLayer.SQLAccess.Providers;
using Gradebook.RepositoryLayer.Interfaces;
using Gradebook.Utilities.Common;
using System;

namespace Gradebook.RepositoryLayer.Repositories
{
    public class MarkRepository : IMarkInterface
    {
        private readonly IMarkInterface _provider = new MarkProvider();

        public List<Mark> GetAllMarks()
        {
            return _provider.GetAllMarks();
        }

        public Mark GetMarkById(int id)
        {
            return _provider.GetMarkById(id);
        }

        public List<Mark> GetMarksByMarksId(int id)
        {
            return _provider.GetMarksByMarksId(id);
        }

        public List<String> GetAllMarkTypes()
        {
            return _provider.GetAllMarkTypes();
        }

        public List<String> GetMarkTypesByMarksId(int id)
        {
            return _provider.GetMarkTypesByMarksId(id);
        }

        public decimal GetAverageByPupilId(int id)
        {
            return _provider.GetAverageByPupilId(id);
        }

        public Mark InsertMark(Mark mark, ITransaction transaction = null)
        {
            return _provider.InsertMark(mark, transaction);
        }

        public Mark UpdateMark(Mark mark, ITransaction transaction = null)
        {
            return _provider.UpdateMark(mark, transaction);
        }

        public void DeleteMark(Mark mark, ITransaction transaction = null)
        {
            _provider.DeleteMark(mark, transaction);
        }

        public ITransaction CreateNewTransaction()
        {
            return _provider.CreateNewTransaction();
        }
    }
}
