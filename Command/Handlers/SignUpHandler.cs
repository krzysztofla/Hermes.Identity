using Hermes.Identity.Command.Identity;
using System;
using System.Threading.Tasks;

namespace Hermes.Identity.Command.Handlers
{
    public class SignUpHandler : ICommandHandler<SignUp>
    {
        public Task Handle(SignUp command)
        {
            throw new NotImplementedException();
        }
    }
}
