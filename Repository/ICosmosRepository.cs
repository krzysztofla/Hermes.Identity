using Hermes.Identity.Entities;
using Hermes.Identity.Mongo.Documents;
using System;
using System.Threading.Tasks;

namespace Hermes.Identity.Repository
{
    public interface ICosmosRepository : IRepository
    {
        Task<User> GetByEmail(string email);
        Task<User> GetById(Guid id);
        Task Add(UserDocument userDocument);
        Task Update(UserDocument userDocument);
        Task Delete(Guid id);
    }
}
