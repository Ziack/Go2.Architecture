namespace Go2.Architecture.RavenDb
{
    using Raven.Client;

    using Go2.Architecture.Domain.DomainModel;
    using Go2.Architecture.Domain.PersistenceSupport;
    using Go2.Architecture.RavenDb.Contracts.Repositories;

    public class RavenDbRepository<T> : RavenDbRepositoryWithTypedId<T, int>,
        IRavenDbRepository<T>,
        ILinqRepository<T>
    {
        public RavenDbRepository(IDocumentSession session) : base(session)
        {
        }
    }
}