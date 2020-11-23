using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Identity.Events
{
    public interface IEventDispacher
    {
        Task SendAsync<T>(T eventPayload) where T : IDomainEvent;
    }
}
 