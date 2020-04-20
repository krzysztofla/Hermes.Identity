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

        public ControllerBase()
        {

        }

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