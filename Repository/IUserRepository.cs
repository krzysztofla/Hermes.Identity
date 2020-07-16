using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hermes.Identity.Models;

namespace Hermes.Identity.Repository
{
    public interface IUserRepository : IRepository
    {
        Task<User> GetByEmail(string email);
        Task<User> GetById(Guid id);
        Task Add(User user);
        Task Update(User user);
        Task Delete(Guid id);
        Task<IEnumerable<User>> Browse();
    }
}