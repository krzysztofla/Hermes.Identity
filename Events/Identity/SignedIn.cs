using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Identity.Events.Identity
{
    public class SignedIn : IDomainEvent
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string  Role { get; set; }
        public SignedIn(Guid id, string email, string role)
        {
            Id = id;
            Email = email;
            Role = role;
        }
    }
}
