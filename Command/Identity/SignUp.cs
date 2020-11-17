using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Identity.Command.Identity
{
    public class SignUp : ICommand
    {
        public Guid UserId { get; }
        public string Email { get; }
        public string Password { get; }
        public string Role { get; }
        public string Name { get; set; }
        public IEnumerable<string> Permissions { get; set; }

        public SignUp(string email, string name, string password, string role, IEnumerable<string> permissions)
        {
            Email = email;
            Name = name;
            Password = password;
            Role = role;
            Permissions = permissions;
        }
    }
}
