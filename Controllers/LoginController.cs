using Hermes.Identity.Command;
using Hermes.Identity.Command.Identity;
using Hermes.Identity.Query;
using Hermes.Identity.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Hermes.Identity.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService userService;
        public LoginController(IUserService userService, ICommandDispacher commandDispacher, IQueryDispacher queryDispacher) : base(commandDispacher, queryDispacher)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SignIn command)
        {
            await SendAsync(command);

            return Json("jwt");
        }
    }
}