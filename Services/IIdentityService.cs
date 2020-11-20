using Hermes.Identity.Command.Identity;
using Hermes.Identity.Command.User;
using Hermes.Identity.Common.Markers;
using Hermes.Identity.Dto;
using Hermes.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Identity.Services
{
    public interface IIdentityService : IService
    {
        Task<AuthDto> SignIn(SignIn command);
        Task SignUp(SignUp command);
    }
}
