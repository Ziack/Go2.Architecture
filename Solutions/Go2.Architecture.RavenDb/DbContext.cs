namespace Go2.Architecture.RavenDb
{
    using System;
    using System.Transactions;

    using Raven.Client;

    using Go2.Architecture.Domain.PersistenceSupport;

    public class DbContext : IDbContext
    {
        private readonly IDocumentSession session;

        private TransactionScope transaction;

        public DbContext(IDocumentSession session)
        {
            this.session = session;
        }

        public IDisposable BeginTransaction()
        {
            return this.transaction ?? (this.transaction = new TransactionScope());
        }

        public void CommitChanges()
        {
            this.session.SaveChanges();
        }

        public void CommitTransaction()
        {
            this.transaction.Complete();
            this.ClearTransaction();
        }

        public void RollbackTransaction()
        {
            this.transaction.Dispose();
            this.transaction = null;
        }

        private void ClearTransaction()
        {
            this.transaction.Dispose();
            this.transaction = null;
        }
    }
}