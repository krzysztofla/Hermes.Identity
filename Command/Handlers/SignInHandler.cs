using Hermes.Identity.Command.Identity;
using Hermes.Identity.Command.User;
using Hermes.Identity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Identity.Command.Handlers
{
    public class SignInHandler : ICommandHandler<SignIn>
    {
        private readonly IIdentityService identityService;

        public SignInHandler(IIdentityService identityService)
        {
            this.identityService = identityService;
        }
        public async Task Handle(SignIn command)
        {
            await identityService.SignIn(command);
        }
    }
}
