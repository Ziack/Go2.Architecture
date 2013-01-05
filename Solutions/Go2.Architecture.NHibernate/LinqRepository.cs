namespace Go2.Architecture.NHibernate
{
    using Go2.Architecture.Domain.PersistenceSupport;

    public class LinqRepository<T> : LinqRepositoryWithTypedId<T, int>, ILinqRepository<T>
    {
    }
}