namespace Go2.Architecture.Events.Infraestructure
{
    public interface IEventListener
    {

    }

    public interface IEventListener<in TEvent> : IEventListener
    {
        void Handle(TEvent eventData);
    }
}
