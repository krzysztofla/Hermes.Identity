using System;
namespace Hermes.Identity.Command.User
{
    public class UpdateUser : ICommand
    {
        public Guid Id { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}