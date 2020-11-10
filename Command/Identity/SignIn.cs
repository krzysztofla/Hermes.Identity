using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Identity.Command.Identity
{
    public class SignIn : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
