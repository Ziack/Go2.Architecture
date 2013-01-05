using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Go2.Architecture.Events.Domain
{
    public interface IDomainEventPublisher
    {
        void Publish<T>(T domainEvent) where T : IDomainEvent;
    }
}
