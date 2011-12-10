using System.Data;

namespace JLY.Hotel.Repository.DB
{
    public interface IUnitOfWork
    {
        bool IsInTransaction { get; }

        void SaveChanges();

        void BeginTransaction();

        void BeginTransaction(IsolationLevel isolationLevel);

        void RollBackTransaction();

        void CommitTransaction();
    }
}