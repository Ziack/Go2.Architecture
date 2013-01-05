using System;

namespace Go2.Architecture.Events.Infraestructure
{
    [AttributeUsage(AttributeTargets.Method)]
    public class EventListenerAttribute : Attribute
    {
        public bool IsAsync { get; set; }

        public EventListenerAttribute()
        {
            
        }

        public EventListenerAttribute(bool isAsync)
        {
            IsAsync = isAsync;
        }
    }
}
