using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Hermes.Identity.Common;
using Hermes.Identity.Dto;
using Hermes.Identity.Entities;
using Hermes.Identity.Mongo.Documents;
using Hermes.Identity.Repository;

namespace Hermes.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        private readonly IEncrypter encrypter;

        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IEncrypter encrypter, IMapper mapper)
        {
            this.encrypter = encrypter;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task Register(string name, string email, string password)
        {
            var user = await userRepository.GetByEmail(email);

            if (user != null)
            {
                throw new IdentityException($"User with provided {email} is already in use exist!");
            }

            var newUser = new User(email, name);
            newUser.SetPassword(password, encrypter);

            await userRepository.Add(mapper.Map<User, UserDocument>(newUser));
        }

        public async Task Login(string email, string password)
        {
            var user = await userRepository.GetByEmail(email);

            if (user == null)
            {
                throw new IdentityException($"User with provided {email} doesn't exist!");
            }

            if (!user.ValidatePassword(password, encrypter))
            {
                throw new IdentityException($"User email or password is invalid!");
            }
        }

        public async Task Update(Guid id, string name, string email, string password)
        {
            var user = await userRepository.GetById(id);
            if (user == null)
            {
                throw new IdentityException($"User with provided {email} doesn't exist!");
            }
            user.SetName(name);
            user.SetEmail(email);
            if (!user.ValidatePassword(password, encrypter))
            {
                throw new IdentityException($"User password cannot  be the same!");
            }
            user.SetPassword(password, encrypter);
            await userRepository.Update(mapper.Map<User, UserDocument>(user));
        }

        public async Task Delete(Guid id)
        {
            var user = await userRepository.GetById(id);
            if (user == null)
            {
                throw new IdentityException($"User with provided {user.Email} doesn't exist!");
            }
            await userRepository.Delete(id);
        }

        public async Task<UserDto> Get(Guid id)
        {
            return mapper.Map<User, UserDto>(await userRepository.GetById(id));
        }
    }
}