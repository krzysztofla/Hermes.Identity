using System;
using System.Threading.Tasks;
using AutoMapper;
using Hermes.Identity.Auth;
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

        private readonly IPasswordService passwordService;

        private readonly IMapper mapper;

        public UserService(ICosmosRepository userRepository, IPasswordService passwordService, IMapper mapper)
        {
            this.passwordService = passwordService;
            this.userRepository = userRepository;
            this.mapper = mapper;
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
            user.SetPassword(password, passwordService);
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