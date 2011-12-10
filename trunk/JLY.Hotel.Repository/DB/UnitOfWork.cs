using System;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace JLY.Hotel.Repository.DB
{
    /// <summary>
    /// DbContext is implementation of unit of work pattern
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext context;

        private DbTransaction transaction;

        /// <summary>
        /// Constructor of a new Unity of Work.
        /// </summary>
        /// <param name="context">With an specific context</param>
        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Determinates if the unity of work is under transaction.
        /// </summary>
        public bool IsInTransaction
        {
            get { return transaction != null; }
        }

        /// <summary>
        /// Save changes in the current context.
        /// </summary>
        public void SaveChanges()
        {
            if (IsInTransaction)
            {
                throw new ApplicationException("A transaction is running. Call BeginTransaction instead.");
            }
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var msg = ex.EntityValidationErrors.SelectMany(validationErrors => validationErrors.ValidationErrors).Aggregate(string.Empty, (current, validationError) => current + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage));
                throw new ApplicationException("Validation Error: " + msg);
            }

        }

        /// <summary>
        /// Begin a new transaction under Read Commited isolation level.
        /// </summary>
        public void BeginTransaction()
        {
            BeginTransaction(IsolationLevel.ReadCommitted);
        }

        /// <summary>
        /// Starts a new transaction with an specific Isolation Level.
        /// </summary>
        /// <param name="isolationLevel">Isolation level</param>
        public void BeginTransaction(IsolationLevel isolationLevel)
        {
            if (IsInTransaction)
            {
                throw new ApplicationException("Cannot begin a new transaction while an existing transaction is still running. " +
                                                "Please commit or rollback the existing transaction before starting a new one.");
            }

            OpenConnection();

            transaction = context.Database.Connection.BeginTransaction(isolationLevel);
        }

        /// <summary>
        /// Transaction rollback if the application is running under transaction scope.
        /// </summary>
        public void RollBackTransaction()
        {
            if (!IsInTransaction)
            {
                throw new ApplicationException(
                    "Cannot run a RollBack transaction because there is no running under a transaction scope.");
            }

            transaction.Rollback();
        }

        /// <summary>
        /// Transaction commit if the application is running under transaction scope.
        /// </summary>
        public void CommitTransaction()
        {
            if (!IsInTransaction)
            {
                throw new ApplicationException("Cannot run a Commit transaction because there is no running under a transaction scope.");
            }

            transaction.Commit();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Open connection if it's not already opened.
        /// </summary>
        private void OpenConnection()
        {
            if (context.Database.Connection.State != ConnectionState.Open)
            {
                context.Database.Connection.Open();
            }
        }

        /// <summary>
        /// Disposes off the managed and unmanaged resources used.
        /// </summary>
        /// <param name="disposing">if disposing</param>
        private void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            if (disposed)
            {
                return;
            }

            disposed = true;
        }

        private bool disposed;
    }
}