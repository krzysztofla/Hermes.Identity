

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hermes.Identity.Common.Markers;
using Hermes.Identity.Models;

namespace Hermes.Identity.Services
{
    public interface IUserService : IService
    {
        Task Register(string name, string email, string password);

        Task Login(string email, string password);

        Task Update(Guid id, string name, string email, string password);
        
        Task Delete(Guid id);

        Task<IEnumerable<User>> GetAll();
    }
}