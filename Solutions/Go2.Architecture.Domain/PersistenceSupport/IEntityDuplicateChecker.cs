namespace Go2.Architecture.Domain.PersistenceSupport
{
    using Go2.Architecture.Domain.DomainModel;

    public interface IEntityDuplicateChecker
    {
        bool DoesDuplicateExistWithTypedIdOf<TId>(IEntityWithTypedId<TId> entity);
    }
}