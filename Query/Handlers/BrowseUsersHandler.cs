using Hermes.Identity.Query.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hermes.Identity.Entities;
using Hermes.Identity.Services;

namespace Hermes.Identity.Query.Handlers
{
    public class BrowseUsersHandler : IQueryHandler<BrowseUsers, IEnumerable<Entities.User>>
    {

        private readonly IUserService _userService;
        public BrowseUsersHandler(IUserService userService)
        {
            _userService = userService;
        }

        async Task<IEnumerable<Entities.User>> IQueryHandler<BrowseUsers, IEnumerable<Entities.User>>.Handle(BrowseUsers query)
        {
            return await _userService.GetAll();
        }
    }
}
