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
    public class MarksManager : IMarksManager
    {
        private readonly IMarksInterface _repository = new MarksRepository();
        private ITransaction _transaction;

        public IEnumerable<Marks> GetAll()
        {
            return _repository.GetAllMarks().Select(x => Map(x));
        }

        public IEnumerable<Marks> GetByPupilId(int id)
        {
            return _repository.GetMarksByPupilId(id).Select(x => Map(x));
        }

        public Marks GetByPupilIdAndSubjectId(int pupilId, int subjectId)
        {
            return Map(_repository.GetMarksPupilIdAndSubjectId(pupilId, subjectId));
        }

        public Marks GetById(int id)
        {
            return Map(_repository.GetMarksById(id));
        }

        public Marks Add(Marks marks)
        {
            return Map(_repository.InsertMarks(Map(marks)));
        }

        public Marks Save(Marks marks)
        {
            return Map(_repository.UpdateMarks(Map(marks)));
        }

        public void Remove(Marks marks)
        {
            _repository.DeleteMarks(Map(marks));
        }

        public Marks Map(DataAccessLayer.Models.Marks dbMarks)
        {
            if (Equals(dbMarks, null))
                return null;

            Marks marks = new Marks(dbMarks.PupilId, dbMarks.SubjectId, dbMarks.CreatedBy, dbMarks.CreatedDate, dbMarks.Version, dbMarks.FinalMark, dbMarks.ModifiedDate, dbMarks.ModifiedBy);
            marks.Id = dbMarks.Id;
            marks.Version = dbMarks.Version;

            return marks;
        }

        public DataAccessLayer.Models.Marks Map(Marks marks)
        {
            if (Equals(marks, null))
                throw new ArgumentNullException("marks", "Valid marks is mandatory!");

            return new DataAccessLayer.Models.Marks(marks.Id, marks.PupilId, marks.SubjectId, marks.CreatedBy, marks.CreatedDate, marks.Version, marks.FinalMark, marks.ModifiedDate, marks.ModifiedBy);
        }
    }
}
