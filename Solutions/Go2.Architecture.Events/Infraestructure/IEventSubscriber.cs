using System;

namespace Go2.Architecture.Events.Infraestructure
{
    public interface IEventSubscriber
    {
        void Subscribe(IEventListener listener);
        void Unsubscribe(IEventListener listener);
    }

    public static class ReflectionHelper
    {
        public static bool IsEventListener(this Type type)
        {
            return type.IsDefined(typeof (EventListenersAttribute), true);
        }
    }
}