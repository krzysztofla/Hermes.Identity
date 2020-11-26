using System;
using System.Threading.Tasks;
using AutoMapper;
using Hermes.Identity.Entities;
using Hermes.Identity.Mongo.Documents;
using MongoDB.Driver;

namespace Hermes.Identity.Repository
{
    public class UserRepository : IMongoRepository
    {
        private readonly IMongoCollection<UserDocument> _context;

        private readonly IMapper _mapper;

        public UserRepository(IMongoDatabase context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context.GetCollection<UserDocument>("Users");
        }

        public async Task Add(UserDocument userDocument)
        {
            await _context.InsertOneAsync(userDocument);
        }

        public async Task<User> GetByEmail(string email)
        {

            var userDocument = await _context.Find(x => x.Email == email).FirstOrDefaultAsync();
            return _mapper.Map<UserDocument, User>(userDocument);

        }
        public async Task<User> GetById(Guid id)
        {

            var userDocument = await _context.Find(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<UserDocument, User>(userDocument);
        }

        private async Task<UserDocument> GetUserDocumentById(Guid id) => await _context.Find(x => x.Id == id).FirstOrDefaultAsync();



        public async Task Update(UserDocument userDocument)
        {
             await _context.ReplaceOneAsync(x => x.Id == userDocument.Id, userDocument);
        }

        public async Task Delete(Guid id)
        {
            await _context.DeleteOneAsync(x => x.Id == id);
        }
    }
}