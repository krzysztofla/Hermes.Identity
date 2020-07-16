using System;
using System.Threading.Tasks;
using Hermes.Identity.Command;
using Microsoft.AspNetCore.Mvc;

namespace Hermes.Identity.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public abstract class ControllerBase : Controller
    {
        private readonly ICommandDispacher CommandDispatcher;

        protected Guid UserId => User?.Identity?.IsAuthenticated == true ?
                                Guid.Parse(User.Identity.Name) :
                                Guid.Empty;

        public ControllerBase()
        {

        }

        protected ControllerBase(ICommandDispacher commandDispatcher)
        {
            CommandDispatcher = commandDispatcher;
        }

        protected async Task Dispatch<T>(T command) where T : ICommand
        {
            if (command is IAuthenticationCommand authenticatedCommand)
            {
                authenticatedCommand.UserId = UserId;
            }
            await CommandDispatcher.Dispatch(command);
        }
    }
}