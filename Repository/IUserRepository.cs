using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hermes.Identity.Entities;
using Hermes.Identity.Mongo.Documents;

namespace Hermes.Identity.Repository
{
    public interface IUserRepository : IRepository
    {
        Task<User> GetByEmail(string email);
        Task<User> GetById(Guid id);
        Task Add(UserDocument userDocument);
        Task Update(UserDocument userDocument);
        Task Delete(Guid id);
    }
}