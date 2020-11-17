using AutoMapper;
using Hermes.Identity.Auth;
using Hermes.Identity.Command.Identity;
using Hermes.Identity.Dto;
using Hermes.Identity.Entities;
using Hermes.Identity.Mongo.Documents;
using Hermes.Identity.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly ICosmosRepository cosmosRepository;
        private readonly IPasswordService passwordService;
        private readonly ILogger<IdentityService> logger;
        private readonly IMapper mapper;
        private readonly IJwtProvider jwtProvider;

        public IdentityService(ICosmosRepository cosmosRepository, IPasswordService passwordService, ILogger<IdentityService> logger, IMapper mapper, IJwtProvider jwtProvider)
        {
            this.cosmosRepository = cosmosRepository;
            this.passwordService = passwordService;
            this.logger = logger;
            this.mapper = mapper;
            this.jwtProvider = jwtProvider;
        }

        public async Task<AuthDto> SignIn(SignIn command)
        {
            var user = await cosmosRepository.GetByEmail(command.Email);
            if (user is null || !passwordService.IsValid(user.Password, command.Password))
            {
                throw new NotImplementedException();
            }

            if (!passwordService.IsValid(user.Password, command.Password))
            {
                throw new NotImplementedException();
            }
            var claims = user.Permissions.Any()
                            ? new Dictionary<string, IEnumerable<string>>
                            {
                                ["permissions"] = user.Permissions
                            }
                            : null;
            var auth = jwtProvider.Create(user.Id, user.Role, claims: claims);
            //auth.RefreshToken = await refreshTokenService.CreateAsync(user.Id);

            logger.LogInformation($"User with id: {user.Id} has been authenticated.");

            return null;
        }

        public async Task SignUp(SignUp command)
        {
            var user = await cosmosRepository.GetByEmail(command.Email);
            if (user is { })
            {
                logger.LogError($"Email already in use: {command.Email}");
                throw new NotImplementedException(command.Email);
            }

            var role = string.IsNullOrWhiteSpace(command.Role) ? "user" : command.Role.ToLowerInvariant();
            var password = passwordService.Hash(command.Password);
            user = new User(command.Email, command.Name, password, role, command.Permissions);
            await cosmosRepository.Add(mapper.Map<User, UserDocument>(user));

            logger.LogInformation($"Created an account for the user with id: {user.Id}.");
        }
    }
}
