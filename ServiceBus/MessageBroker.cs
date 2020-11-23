using Hermes.Identity.Common.Markers;
using Hermes.Identity.Events;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Identity.ServiceBus
{
    public class MessageBroker : IMessageBroker, IService
    {
        private readonly IQueueClient queueClient;
        private readonly ILogger<MessageBroker> logger;
        public MessageBroker(IQueueClient queueClient, ILogger<MessageBroker> logger)
        {
            this.queueClient = queueClient;
            this.logger = logger;
        }

        public async Task SendMessagesAsync(params IDomainEvent[] events)
        {
            try
            {
                foreach (var @event in events)
                {
                    var messageBody = JsonConvert.SerializeObject(@event);
                    var message = new Message(Encoding.UTF8.GetBytes(messageBody));
                    await queueClient.SendAsync(message);
                }
            }
            catch (Exception exception)
            {

                logger.LogInformation($"{DateTime.Now} :: Exception: {exception.Message}");
            }
        }
    }
}
