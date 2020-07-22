using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hermes.Identity.DbConfiguration;
using Hermes.Identity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hermes.Identity.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoRepository<UserDocument, Guid> _repository;

        public UserRepository(IMongoRepository<UserDocument, Guid> repository)
        {
            _repository = repository;
        }

        public async Task Add(User user)
        {
            await _repository.Database.EnsureCreatedAsync();
            await _repository.Users.AddAsync(user);
            await _repository.SaveChangesAsync();
        }

        public async Task<User> GetByEmail(string email) => await _repository.Users.AsQueryable().FirstOrDefaultAsync(x => x.Email == email);

        public async Task<User> GetById(Guid id) => await _repository.Users.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<User>> Browse() => await _repository.Users.AsQueryable().ToListAsync();

        public async Task Update(User user)
        {
            _repository.Users.Update(user);
            await _repository.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var user = await GetById(id);
            _repository.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
        public async Task<User> Get(Guid id) => await _context.Users.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
    }
}