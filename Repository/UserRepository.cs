using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hermes.Identity.DbConfiguration;
using Hermes.Identity.Entities;
using Hermes.Identity.Mongo;
using Hermes.Identity.Mongo.Documents;
using Hermes.Identity.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Hermes.Identity.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<UserDocument> _context;

        public UserRepository(IOptions<MongoSettings> settings)
        {
            _context = UserContext.CreateUserContext(settings);
        }

        public async Task Add(User user)
        {

            _context.InsertOneAsync();
        }

        public async Task<User> GetByEmail(string email) => await _context.Users.AsQueryable().FirstOrDefaultAsync(x => x.Email == email);

        public async Task<User> GetById(Guid id) => await _context.Users.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<User>> Browse() => await _context.Users.AsQueryable().ToListAsync();

        public async Task Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var user = await GetById(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
        public async Task<User> Get(Guid id) => await _context.Users.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
    }
}