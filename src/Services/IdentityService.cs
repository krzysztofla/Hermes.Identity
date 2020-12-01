using AutoMapper;
using Hermes.Identity.Auth;
using Hermes.Identity.Command.Identity;
using Hermes.Identity.Common;
using Hermes.Identity.Dto;
using Hermes.Identity.Entities;
using Hermes.Identity.Events.Identity;
using Hermes.Identity.Mongo.Documents;
using Hermes.Identity.Repository;
using Hermes.Identity.ServiceBus;
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
        private readonly IMessageBroker messageBroker;

        public IdentityService(
                    ICosmosRepository cosmosRepository, 
                    IPasswordService passwordService, 
                    ILogger<IdentityService> logger, 
                    IMapper mapper, 
                    IJwtProvider jwtProvider, 
                    IMessageBroker messageBroker)
        {
            this.cosmosRepository = cosmosRepository;
            this.passwordService = passwordService;
            this.logger = logger;
            this.mapper = mapper;
            this.jwtProvider = jwtProvider;
            this.messageBroker = messageBroker;
        }

        public async Task<AuthDto> SignIn(SignIn query)
        {
            var user = await cosmosRepository.GetByEmail(query.Email);
            if (user is null || !passwordService.IsValid(user.Password, query.Password))
            {
                throw new IdentityException($"Wrong password or username", IdentityErrorCodes.invalid_login_or_password);
            }

            if (!passwordService.IsValid(user.Password, query.Password))
            {
                throw new IdentityException($"Wrong password or username", IdentityErrorCodes.invalid_login_or_password);
            }
            var claims = user.Permissions.Any()
                            ? new Dictionary<string, IEnumerable<string>>
                            {
                                ["permissions"] = user.Permissions
                            }
                            : null;
            var auth = jwtProvider.Create(user.Id, user.Role, claims: claims);

            logger.LogInformation($"User with id: {user.Id} has been authenticated.");
            await messageBroker.SendMessagesAsync(new SignedIn(user.Id, user.Email, user.Role));

            return auth;
        }

        public async Task SignUp(SignUp command)
        {
            var user = await cosmosRepository.GetByEmail(command.Email);
            if (user is { })
            {
                logger.LogError($"Email already in use: {command.Email}");
                throw new IdentityException($"Email already in use: {command.Email}", IdentityErrorCodes.user_in_use);
            }

            var role = string.IsNullOrWhiteSpace(command.Role) ? "user" : command.Role.ToLowerInvariant();
            var password = passwordService.Hash(command.Password);
            user = new User(command.Email, command.Name, password, role, command.Permissions);
            await cosmosRepository.Add(mapper.Map<User, UserDocument>(user));

            logger.LogInformation($"Created an account for the user with id: {user.Id}.");
            await messageBroker.SendMessagesAsync(new SignedUp(user.Id, user.Email, user.Role));
        }
    }
}
