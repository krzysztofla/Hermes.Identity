using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Identity.Events
{
    public class EventDispacher : IEventDispacher
    {
        private readonly IComponentContext componentContext;
        public EventDispacher(IComponentContext componentContext)
        {
            this.componentContext = componentContext;
        }

        public async Task SendAsync<T>(T eventPayload) where T: IDomainEvent
        {
            if (eventPayload == null)
            {
                throw new ArgumentNullException();
            }
            await componentContext.Resolve<IEventHandler<T>>().Handle(eventPayload);
        }
    }
}
