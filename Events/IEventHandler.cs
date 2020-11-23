using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Identity.Events
{
    public interface IEventHandler<T> where T : IDomainEvent
    {
        Task Handle(T eventPayload);
    }
}
