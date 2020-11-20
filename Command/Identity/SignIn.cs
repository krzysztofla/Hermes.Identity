using Hermes.Identity.Query;

namespace Hermes.Identity.Command.Identity
{
    public class SignIn : IQuery
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
