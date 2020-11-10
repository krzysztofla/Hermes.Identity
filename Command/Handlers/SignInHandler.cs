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
        private readonly IUserService userService;

        public SignInHandler(IUserService userService)
        {
            this.userService = userService;
        }
        public async Task Handle(SignIn command)
        {

        }
    }
}
