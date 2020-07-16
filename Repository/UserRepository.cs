using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hermes.Identity.DbConfiguration;
using Hermes.Identity.Models;
using Hermes.Identity.WebApi.DbConfiguration;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Hermes.Identity.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlAzConnectionContext _context;


        public UserRepository(SqlAzConnectionContext context)
        {
            _context = context;
        }

        public async Task Add(User user)
        {
            await _context.Database.EnsureCreatedAsync();
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
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