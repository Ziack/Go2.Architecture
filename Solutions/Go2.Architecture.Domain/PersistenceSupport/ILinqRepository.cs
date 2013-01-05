namespace Go2.Architecture.Domain.PersistenceSupport
{
    public interface ILinqRepository<T> : ILinqRepositoryWithTypedId<T, int>
    {
    }
}