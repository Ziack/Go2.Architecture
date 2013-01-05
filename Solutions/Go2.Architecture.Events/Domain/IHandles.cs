namespace Go2.Architecture.Events.Domain
{
    public interface IHandles<in T> where T : IDomainEvent
    {
        void Handle(T args);
    }
}
