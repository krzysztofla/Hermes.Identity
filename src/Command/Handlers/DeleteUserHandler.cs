using System.Threading.Tasks;
using Hermes.Identity.Command.User;
using Hermes.Identity.Services;

namespace Hermes.Identity.Command.Handlers
{
    public class DeleteUserHandler : ICommandHandler<DeleteUser>
    {
        private readonly IUserService userService;

        public DeleteUserHandler(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task Handle(DeleteUser command)
        {
            await userService.Delete(command.Id);
        }
    }
}