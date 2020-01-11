using System.Threading.Tasks;
using Hermes.Identity.Command;
using Microsoft.AspNetCore.Mvc;

namespace Hermes.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ControllerBase : Controller
    {
        private readonly ICommandDispacher CommandDispatcher;
        protected ControllerBase(ICommandDispacher commandDispatcher)
        {
            CommandDispatcher = commandDispatcher;
        }

        protected async Task Dispatch<T>(T command) where T : ICommand
        {
            await CommandDispatcher.Dispatch(command);
        }
    }
}