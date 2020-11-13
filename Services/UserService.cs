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
        private readonly ICosmosRepository userRepository;

        private readonly IPasswordService _passwordService;

        private readonly IMapper mapper;

        public UserService(ICosmosRepository userRepository, IPasswordService passwordService, IMapper mapper)
        {
            this._passwordService = passwordService;
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
            newUser.SetPassword(password, _passwordService);

            await userRepository.Add(mapper.Map<User, UserDocument>(newUser));
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
            user.SetPassword(password, _passwordService);
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

        public async Task<UserDto> Get(string email)
        {
            return mapper.Map<User, UserDto>(await userRepository.GetByEmail(email));
        }
    }
}