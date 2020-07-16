using System;
using System.Threading.Tasks;
using Hermes.Identity.Command.User;
using Hermes.Identity.Services;

namespace Hermes.Identity.Command.Handlers
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserService userService;

        public CreateUserHandler(IUserService userService)
        {
            this.userService = userService;
        }
        
        public async Task Handle(CreateUser command)
        {
            await userService.Register(command.Username, command.Email, command.Password);
        }
    }
}