using System;

namespace Hermes.Identity.Command
{
    public interface IAuthenticationCommand
    {
        Guid UserId { get; set; }
    }
}
