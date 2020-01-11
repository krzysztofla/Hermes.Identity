using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hermes.Identity.Common;
using Hermes.Identity.Models;
using Hermes.Identity.Repository;

namespace Hermes.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        private readonly IEncrypter encrypter;

        public UserService(IUserRepository userRepository, IEncrypter encrypter)
        {
            this.encrypter = encrypter;
            this.userRepository = userRepository;
        }

        public async Task Register(string name, string email, string password)
        {
            var user = await userRepository.Get(email);

            if (user == null)
            {
                throw new IdentityException(IdentityErrorCodes.user_in_use, $"User with provided {email} is already in use exist!");
            }

            var newUser = new User(email, name);
            newUser.SetPassword(password, encrypter);

            await userRepository.Add(user);
        }

        public async Task Login(string email, string password)
        {
            var user = await userRepository.Get(email);

            if (user == null)
            {
                throw new IdentityException(IdentityErrorCodes.user_not_valid, $"User with provided {email} doesn't exist!");
            }

            if (!user.ValidatePassword(password, encrypter))
            {
                throw new IdentityException(IdentityErrorCodes.invalid_login_or_password, $"User email or password is invalid!");
            }
        }

        public async Task<IEnumerable<User>> GetAll() => await userRepository.Browse();

        public async Task Update(Guid id, string name, string email, string password)
        {
            var user = await userRepository.Get(id);
            if (user == null)
            {
                throw new IdentityException(IdentityErrorCodes.user_in_use, $"User with provided {email} doesn't exist!");
            }
            user.SetName(name);
            user.SetEmail(email);
            if (!user.ValidatePassword(password, encrypter))
            {
                throw new IdentityException(IdentityErrorCodes.invalid_login_or_password, $"User password cannot  be the same!");
            }
            user.SetPassword(password, encrypter);
            await userRepository.Update(user);
        }

        public async Task Delete(Guid id)
        {
            var user = await userRepository.Get(id);
            if (user == null)
            {
                throw new IdentityException(IdentityErrorCodes.user_in_use, $"User with provided {user.Email} doesn't exist!");
            }
            await userRepository.Delete(id);
        }
    }
}