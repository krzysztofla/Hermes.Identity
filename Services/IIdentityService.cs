using Hermes.Identity.Command.Identity;
using Hermes.Identity.Common.Markers;
using Hermes.Identity.Dto;
using System.Threading.Tasks;

namespace Hermes.Identity.Services
{
    public interface IIdentityService : IService
    {
        Task<AuthDto> SignIn(SignIn command);
        Task SignUp(SignUp command);
    }
}
