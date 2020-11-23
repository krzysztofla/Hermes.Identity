using System;
using System.Collections.Generic;
using System.Linq;
using Hermes.Identity.Auth;
using Hermes.Identity.Command.User;
using Hermes.Identity.Common;
using Hermes.Identity.Services;

namespace Hermes.Identity.Entities
{
    public class User : AggregateRoot
    {
        public string Name { get; protected set; }

        public string Surname { get; protected set; }

        public string Email { get; protected set; }

        public string Password { get; protected set; }

        public string Role { get; private set; }
        public IEnumerable<string> Permissions { get; private set; }

        public DateTime CreatedAt { get; protected set; }

        public DateTime UpdatedAt { get; protected set; }

        public User()
        {

        }

        public User(string email, string name, string password, string role, IEnumerable<string> permissions)
        {
            Id = Guid.NewGuid();
            SetName(name);
            SetEmail(email);
            Password = password;
            CreatedAt = DateTime.UtcNow;
            SetRole(role);
            Permissions = permissions ?? Enumerable.Empty<string>();
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new IdentityException("User name cannot be empty");
            }
            Name = name;
            SetUpdateTime();
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new IdentityException("User email cannot be empty");
            }
            Email = email.ToLowerInvariant();
            SetUpdateTime();
        }

        public void SetPassword(string password, IPasswordService passwordService)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new IdentityException("User password cannot be empty");
            }
            Password = passwordService.Hash(password);
        }

        public void SetUpdateTime()
        {
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetRole(string role)
        {
            if (!Entities.Role.IsValid(role))
            {
                throw new Exception(role);
            }
            Role = role.ToLowerInvariant();
        }
    }
}