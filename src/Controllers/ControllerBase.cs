using System;
using System.Threading.Tasks;
using Hermes.Identity.Command;
using Hermes.Identity.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hermes.Identity.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public abstract class ControllerBase : Controller
    {
        private readonly ICommandDispacher _commandDispatcher;
        private readonly IQueryDispacher _queryDispacher;

        protected Guid UserId => User?.Identity?.IsAuthenticated == true ?
                                Guid.Parse(User.Identity.Name) :
                                Guid.Empty;

        public ControllerBase()
        {

        }

        protected ControllerBase(ICommandDispacher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        protected ControllerBase(IQueryDispacher queryDispacher)
        {
            _queryDispacher = queryDispacher;
        }

        protected ControllerBase(ICommandDispacher commandDispatcher, IQueryDispacher queryDispacher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispacher = queryDispacher;
        }

        protected async Task SendAsync<T>(T command) where T : ICommand
        {
            if (command is IAuthenticationCommand authenticatedCommand)
            {
                authenticatedCommand.UserId = UserId;
            }
            await _commandDispatcher.SendAsync(command);
        }

        protected async Task<TResult> QueryAsync<T, TResult>(T query) where T : IQuery 
        {
            if (query is IAuthenticationCommand authenticatedCommand)
            {
                authenticatedCommand.UserId = UserId;
            }
            return await _queryDispacher.Execute<T, TResult>(query);
        }
    }
}