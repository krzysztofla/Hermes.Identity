using Hermes.Identity.Command.User;
using Hermes.Identity.Dto;
using Hermes.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Identity.Services
{
    public interface IIdentityService
    {
        Task<AuthDto> SignIn(SignIn command);
        Task SignUp(SignIn command);
    }
}
