

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hermes.Identity.Common.Markers;
using Hermes.Identity.Dto;
using Hermes.Identity.Entities;

namespace Hermes.Identity.Services
{
    public interface IUserService : IService
    {
        Task Update(Guid id, string name, string email, string password);
        
        Task Delete(Guid id);

        Task<UserDto> Get(Guid id);

        Task<UserDto> Get(string email);
    }
}