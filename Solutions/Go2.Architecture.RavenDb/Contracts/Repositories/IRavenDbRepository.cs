namespace Go2.Architecture.RavenDb.Contracts.Repositories
{
    using Go2.Architecture.Domain.PersistenceSupport;

    public interface IRavenDbRepository<T> : IRavenDbRepositoryWithTypedId<T, int>, IRepository<T>
    {
    }
}