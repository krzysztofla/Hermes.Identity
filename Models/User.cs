using System;
using Hermes.Identity.Common;
using Hermes.Identity.Services;

namespace Hermes.Identity.Models
{
    public class User
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Surname { get; protected set; }

        public string Email { get; protected set; }

        public string Salt { get; protected set; }

        public string Password { get; protected set; }
        
        public DateTime CreatedAt { get; protected set; }

        public DateTime UpdatedAt { get; protected set; }

        protected User()
        {

        }

        public User(string email, string name)
        {
            Id = Guid.NewGuid();
            SetName(name); 
            SetEmail(email);
            CreatedAt = DateTime.UtcNow;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new IdentityException("empty name", "User name cannot be empty");
            }
            Name = name;
            SetUpdateTime();
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new IdentityException("empty email", "User email cannot be empty");
            }
            Email = email.ToLowerInvariant();
            SetUpdateTime();
        }

        public void SetPassword(string password, IEncrypter encrypter)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new IdentityException("empty email", "User password cannot be empty");
            }
            Salt = encrypter.GetSalt(password);
            Password = encrypter.GetHash(password, Salt);
        }

        public void SetUpdateTime() {
            UpdatedAt = DateTime.UtcNow;
        }

        public bool ValidatePassword(string password, IEncrypter encrypter)
            => Password.Equals(encrypter.GetHash(password, Salt));
    }
}