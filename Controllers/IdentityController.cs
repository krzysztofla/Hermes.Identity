using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hermes.Identity.Command;
using Hermes.Identity.Command.User;
using Hermes.Identity.Dto;
using Hermes.Identity.Entities;
using Hermes.Identity.Query;
using Hermes.Identity.Query.User;
using Hermes.Identity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;

namespace Hermes.Identity.Controllers
{
    [Authorize]
    public class IdentityController : ControllerBase
    {
        private readonly IUserService userService;
        public IdentityController(IUserService userService, ICommandDispacher commandDispacher, IQueryDispacher queryDispacher) : base(commandDispacher, queryDispacher)
        {
            this.userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Json(await QueryAsync<BrowseUser, UserDto>(new BrowseUser(id)));
        }
    }
}