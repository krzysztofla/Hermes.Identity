using Hermes.Identity.Command.Identity;
using Hermes.Identity.Dto;
using Hermes.Identity.Services;
using System.Threading.Tasks;

namespace Hermes.Identity.Query.Handlers
{
    public class SignInHandler : IQueryHandler<SignIn, AuthDto>
    {
        private readonly IIdentityService identityService;

        public SignInHandler(IIdentityService identityService)
        {
            this.identityService = identityService;
        }
        public async Task<AuthDto> Handle(SignIn query)
        {
           return await identityService.SignIn(query);
        }
    }
}
