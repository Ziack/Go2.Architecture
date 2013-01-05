using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Go2.Architecture.Events.Application
{
    public interface IApplicationEventPublisher
    {
        void Publish<T>(T domainEvent) where T : IApplicationEvent;
    }
}
