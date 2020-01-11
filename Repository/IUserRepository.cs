using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hermes.Identity.Models;

namespace Hermes.Identity.Repository
{
    public interface IUserRepository : IRepository
    {
        Task<User> Get(string email);
        Task<User> Get(Guid id);
        Task Add(User user);
        Task Update(User user);
        Task Delete(Guid id);
        Task<IEnumerable<User>> Browse();
    }
}