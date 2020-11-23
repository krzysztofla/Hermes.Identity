using Hermes.Identity.Command.Identity;
using Hermes.Identity.Services;
using System;
using System.Threading.Tasks;

namespace Hermes.Identity.Command.Handlers
{
    public class SignUpHandler : ICommandHandler<SignUp>
    {
        private readonly IIdentityService identityService;

        public SignUpHandler(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        public async Task Handle(SignUp command)
        {
            await this.identityService.SignUp(command);
        }
    }
}
