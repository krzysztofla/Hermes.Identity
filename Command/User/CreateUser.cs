namespace Hermes.Identity.Command.User
{
    public class CreateUser : ICommand
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}