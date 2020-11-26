using Hermes.Identity.Entities;

namespace Hermes.Identity.Events
{
    public class IdentityCreated : IDomainEvent
    {
        public User User { get; }

        public IdentityCreated(User user) => User = user; 
    }
}
