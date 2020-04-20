using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hermes.Identity.DbConfiguration;
using Hermes.Identity.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Hermes.Identity.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoDatabase database;

        public UserRepository(IMongoSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            this.database = client.GetDatabase(settings.DatabaseName);
            //Users.InsertOneAsync(new User("krzysztof.lkach@icik.com","1231332"));
        }

        public async Task Add(User user) => await Users.InsertOneAsync(user);

        public async Task<User> Get(string email) => await Users.AsQueryable().FirstOrDefaultAsync(x => x.Email == email);

        public async Task<IEnumerable<User>> Browse() => await Users.AsQueryable().ToListAsync();

        public async Task Update(User user) => await Users.ReplaceOneAsync(u => u.Id == user.Id, user);
        
        public async Task Delete(Guid id) => await Users.DeleteOneAsync(u => u.Id == id);

        public async Task<User> Get(Guid id) => await Users.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);

        private IMongoCollection<User> Users => database.GetCollection<User>("Users");
    }
}