using System;
using System.Collections.Generic;
using Microsoft.Practices.ServiceLocation;

namespace Go2.Architecture.Events.Domain
{
    public class DomainEvents
	{
        [ThreadStatic]
        private static List<Delegate> _actions;

        public static IServiceLocator ServiceLocator { get; set; }

        public static void ClearCallbacks()
        {
            _actions = null;
        }

        public static void Raise<T>(T args) where T : IDomainEvent
        {
            if (ServiceLocator != null)
            {
                foreach (var handler in ServiceLocator.GetAllInstances<IHandles<T>>())
                {
                    handler.Handle(args);
                }
            }

            if (_actions != null)
            {
                foreach (var action in _actions)
                {
                    if (action is Action<T>)
                    {
                       ((Action<T>)action)(args);
                    }
                }
            }
        }

        public static void Register<T>(Action<T> callback) where T : IDomainEvent
        {
            if (_actions == null)
            {
                _actions = new List<Delegate>();
            }
            _actions.Add(callback);
        }
    }
}