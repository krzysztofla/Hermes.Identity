using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Identity.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly IPasswordHasher<IPasswordService> _passwordHasher;

        public PasswordService(IPasswordHasher<IPasswordService> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public bool IsValid(string hash, string password)
            => _passwordHasher.VerifyHashedPassword(this, hash, password) != PasswordVerificationResult.Failed;

        public string Hash(string password)
            => _passwordHasher.HashPassword(this, password);
    }
}
