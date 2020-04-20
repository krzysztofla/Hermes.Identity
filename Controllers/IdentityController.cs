using System.Threading.Tasks;
using Hermes.Identity.Command;
using Hermes.Identity.Command.User;
using Hermes.Identity.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hermes.Identity.Controllers
{
    public class IdentityController : ControllerBase
    {
        private readonly IUserService userService;
        public IdentityController(IUserService userService, ICommandDispacher commandDispacher) : base(commandDispacher)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            await Dispatch(command);

            return Created($"users/{command.Email}", null);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await userService.GetAll();

            return Json(users);
        }
    }
}