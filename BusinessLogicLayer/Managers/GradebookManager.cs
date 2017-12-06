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
    public class GradebookManager : IGradebookManager
    {
        private readonly IGradebookInterface _repository = new GradebookRepository();
        private ITransaction _transaction;

        public IEnumerable<Gbook> GetAll()
        {
            return _repository.GetAllGradebooks().Select(x => Map(x));
        }

        public Gbook GetById(int id)
        {
            return Map(_repository.GetGradebookById(id));
        }

        public Gbook Add(Gbook gBook)
        {
            return Map(_repository.InsertGradebook(Map(gBook)));
        }

        public Gbook Save(Gbook gBook)
        {
            return Map(_repository.UpdateGradebook(Map(gBook)));
        }

        public void Remove(Gbook gBook)
        {
            _repository.DeleteGradebook(Map(gBook));
        }

        public Gbook Map(DataAccessLayer.Models.Gbook dbGbook)
        {
            if (Equals(dbGbook, null))
                return null;

            Gbook gBook = new Gbook(dbGbook.PClassId, dbGbook.SchoolYearStart, dbGbook.SchoolYearEnd, dbGbook.Editable, dbGbook.CreatedBy, dbGbook.CreatedDate, dbGbook.Version, dbGbook.ModifiedDate, dbGbook.ModifiedBy);
            gBook.Id = dbGbook.Id;
            gBook.Version = dbGbook.Version;

            return gBook;
        }

        public DataAccessLayer.Models.Gbook Map(Gbook gBook)
        {
            if (Equals(gBook, null))
                throw new ArgumentNullException("gBook", "Valid gBook is mandatory!");

            return new DataAccessLayer.Models.Gbook(gBook.Id, gBook.PClassId, gBook.SchoolYearStart, gBook.SchoolYearEnd, gBook.Editable, gBook.CreatedBy, gBook.CreatedDate, gBook.Version, gBook.ModifiedDate, gBook.ModifiedBy);
        }
    }
}
