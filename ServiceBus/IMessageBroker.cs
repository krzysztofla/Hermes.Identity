using Hermes.Identity.Events;
using System.Threading.Tasks;

namespace Hermes.Identity.ServiceBus
{
    public interface IMessageBroker
    {
        Task SendMessagesAsync(params IDomainEvent[] events);
    }
}