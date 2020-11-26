using System.Threading.Tasks;
using Hermes.Identity.Command.User;
using Hermes.Identity.Services;
using Hermes.Identity.Entities;

namespace Hermes.Identity.Command.Handlers
{
    public class UpdateUserHandler : ICommandHandler<UpdateUser>
    {
        private readonly IUserService userService;

        public UpdateUserHandler(IUserService userService)
        {
            this.userService = userService;            
        }
        public async Task Handle(UpdateUser command)
        {
          await userService.Update(command.Id, command.Username, command.Email, command.Password);
        }
    }
}