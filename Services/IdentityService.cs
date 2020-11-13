using Hermes.Identity.Command.Identity;
using Hermes.Identity.Dto;
using Hermes.Identity.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly ICosmosRepository _cosmosRepository;
        private readonly IPasswordService _passwordService;

        public IdentityService(ICosmosRepository cosmosRepository, IPasswordService passwordService)
        {
            _cosmosRepository = cosmosRepository;
            _passwordService = passwordService;
        }

        public async Task<AuthDto> SignIn(SignIn command)
        {
            var user = await _cosmosRepository.GetByEmail(command.Email);
            if (user is null || !_passwordService.IsValid(user.Password, command.Password))
            {
                throw new NotImplementedException();
            }

            if (!_passwordService.IsValid(user.Password, command.Password))
            {
                throw new NotImplementedException();
            }
        }

        public Task SignUp(SignIn command)
        {
            throw new NotImplementedException();
        }
    }
}
