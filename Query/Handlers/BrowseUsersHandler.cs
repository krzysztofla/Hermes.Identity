using Hermes.Identity.Query.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hermes.Identity.Entities;
using Hermes.Identity.Services;
using Hermes.Identity.Dto;

namespace Hermes.Identity.Query.Handlers
{
    public class BrowseUsersHandler : IQueryHandler<BrowseUser, UserDto>
    {

        private readonly IUserService _userService;
        public BrowseUsersHandler(IUserService userService)
        {
            _userService = userService;
        }

        async Task<UserDto> IQueryHandler<BrowseUser, UserDto>.Handle(BrowseUser query)
        {
            return await _userService.Get(query.Id);
        }
    }
}
