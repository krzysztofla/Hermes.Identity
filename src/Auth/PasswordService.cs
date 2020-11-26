using Microsoft.AspNetCore.Identity;
namespace Hermes.Identity.Auth
{
    public class PasswordService : IPasswordService
    {
        private readonly IPasswordHasher<IPasswordService> passwordHasher;

        public PasswordService(IPasswordHasher<IPasswordService> passwordHasher)
        {
            this.passwordHasher = passwordHasher;
        }

        public bool IsValid(string hash, string password)
            => passwordHasher.VerifyHashedPassword(this, hash, password) != PasswordVerificationResult.Failed;

        public string Hash(string password)
            => passwordHasher.HashPassword(this, password);
    }
}
