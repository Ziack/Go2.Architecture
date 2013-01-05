namespace Go2.Architecture.RavenDb.Contracts.Repositories
{
    using System;
    using System.Collections.Generic;

    using Raven.Client;

    using Go2.Architecture.Domain.PersistenceSupport;

    public interface IRavenDbRepositoryWithTypedId<T, TIdT> : IRepositoryWithTypedId<T, TIdT>
    {
        IDocumentSession Session { get; }

        IEnumerable<T> FindAll(Func<T, bool> where);

        T FindOne(Func<T, bool> where);

        T First(Func<T, bool> where);

        IList<T> GetAll(IEnumerable<TIdT> ids);
    }
}