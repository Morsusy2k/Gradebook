using System;
using System.Collections.Generic;
using System.Linq;
using Gradebook.BusinessLogicLayer.Interfaces;
using Gradebook.BusinessLogicLayer.Models;
using Gradebook.RepositoryLayer.Interfaces;
using Gradebook.RepositoryLayer.Repositories;
using Gradebook.Utilities.Common;

namespace Gradebook.BusinessLogicLayer.Managers
{
    public class MarkManager : IMarkManager
    {
        private readonly IMarkInterface _repository = new MarkRepository();
        private ITransaction _transaction;

        public IEnumerable<Mark> GetAll()
        {
            return _repository.GetAllMarks().Select(x => Map(x));
        }

        public Mark GetById(int id)
        {
            return Map(_repository.GetMarkById(id));
        }

        public IEnumerable<Mark> GetByMarksId(int id)
        {
            return _repository.GetMarksByMarksId(id).Select(x => Map(x));
        }

        public IEnumerable<String> GetAllMarkTypes()
        {
            return _repository.GetAllMarkTypes().Select(x => x.ToString());
        }

        public IEnumerable<String> GetMarkTypesByMarksId(int id)
        {
            return _repository.GetMarkTypesByMarksId(id).Select(x => x.ToString());
        }

        public decimal GetAverageByPupilId(int id)
        {
            return _repository.GetAverageByPupilId(id);
        }

        public Mark Add(Mark mark)
        {
            return Map(_repository.InsertMark(Map(mark)));
        }

        public Mark Save(Mark mark)
        {
            return Map(_repository.UpdateMark(Map(mark)));
        }

        public void Remove(Mark mark)
        {
            _repository.DeleteMark(Map(mark));
        }

        public Mark Map(DataAccessLayer.Models.Mark dbMark)
        {
            if (Equals(dbMark, null))
                return null;

            Mark mark = new Mark(dbMark.MarksId, dbMark.Grade, dbMark.Type, dbMark.CreatedBy, dbMark.CreatedDate, dbMark.Version, dbMark.Important, dbMark.Final, dbMark.ModifiedDate, dbMark.ModifiedBy);
            mark.Id = dbMark.Id;
            mark.Version = dbMark.Version;

            return mark;
        }

        public DataAccessLayer.Models.Mark Map(Mark mark)
        {
            if (Equals(mark, null))
                throw new ArgumentNullException("Mark", "Valid mark is mandatory!");

            return new DataAccessLayer.Models.Mark(mark.Id, mark.MarksId, mark.Grade, mark.Type, mark.CreatedBy, mark.CreatedDate, mark.Version, mark.Important, mark.Final, mark.ModifiedDate, mark.ModifiedBy);
        }
    }
}
