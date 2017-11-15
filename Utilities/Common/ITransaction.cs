using System.Data;

namespace Gradebook.Utilities.Common
{
    public interface ITransaction
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }

        void Begin();
        void Commit();
        void Rollback();
    }
}
