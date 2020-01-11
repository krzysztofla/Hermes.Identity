using System;

namespace Hermes.Identity.Command.User
{
    public class DeleteUser : ICommand
    {
        public Guid Id { get; set; }
    }
}