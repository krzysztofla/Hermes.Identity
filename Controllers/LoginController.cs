using Hermes.Identity.Command;
using Hermes.Identity.Command.Identity;
using Hermes.Identity.Dto;
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

        [Route("sign-up")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SignUp command)
        {
            await SendAsync(command);
            return Created($"users/{command.Email}", null);
        }


        [Route("sign-in")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SignIn query)
        {
            var token = await QueryAsync<SignIn, AuthDto>(query);
            return Json(token);
        }
    }
}