using AutoMapper;
using Hermes.Identity.Entities;
using Hermes.Identity.Mongo.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Identity.Repository
{
    public class InMemoryUserRepository : ICosmosRepository
    {
        private readonly ISet<UserDocument> context;

        private readonly IMapper mapper;

        public InMemoryUserRepository(IMapper mapper)
        {
            this.mapper = mapper;
            this.context = new HashSet<UserDocument>();
            SeedUsersData(context);
        }

        private void SeedUsersData(ISet<UserDocument> context)
        {
            context.Add(new UserDocument() { Id = Guid.Parse("75994b75-5412-419e-8fb6-bd22e930fca8"), CreatedAt = DateTime.Parse("2020-11-20T14:49:27.9096633Z"), Email = "krzysztof.lach@icloud.com", Name = "Krzysztof", Password = "AQAAAAEAACcQAAAAEAVHj0Amgfm6+oEmfoQisoSxVSuziamFl2qkrjDvnEkOLRjGH53K0dloUib9q5cGUA==", Permissions = new List<string>() { "moderator", "user", "admin" }, Role = "admin" });
            context.Add(new UserDocument() { Id = Guid.Parse("c8068ba2-ce11-49f5-9634-4dd8d66f6657"), CreatedAt = DateTime.Parse("2020-11-23T14:59:57.4117121Z"), Email = "aga.lach@icloud.com", Name = "Aga", Password = "AQAAAAEAACcQAAAAEMFchLCzfIJWYTjs/va6KZB4n7dBIo03Otako8JRMrebGoMJ0JxgPJ65SCgskN7Msg==", Permissions = new List<string>() { "moderator", "user" , "admin" }, Role = "admin" });
            context.Add(new UserDocument() { Id = Guid.Parse("5adda437-206b-42db-acd3-c7931ca10123"), CreatedAt = DateTime.Parse("2020-11-23T15:01:16.5965115Z"), Email = "aga2.lach@icloud.com", Name = "Aga2", Password = "AQAAAAEAACcQAAAAELNub8OhSI2Z6iVVdGO9yRDIL9k+4bvaPhebqj12I5dL1yH7O62Yspri3aCRiT27wg==", Permissions = new List<string>() { "user" }, Role = "user" });
            context.Add(new UserDocument() { Id = Guid.Parse("8adc6e86-32c9-4d39-bc76-dfd567c1caca"), CreatedAt = DateTime.Parse("2020-11-23T15:01:55.8055948Z"), Email = "aga3.lach@icloud.com", Name = "Aga3", Password = "AQAAAAEAACcQAAAAEIkQmAyd0xYsBMZgeo+VH4gkFqgm6YPmphuMunjBmCtxwR7oTT92HRvaPCvmn/6Gkg==", Permissions = new List<string>() { "user" }, Role = "user" });
        }

        public async Task Add(UserDocument userDocument)
        {
            await Task.FromResult(context.Add(userDocument));
        }

        public async Task<User> GetByEmail(string email)
        {

            var userDocument = await Task.FromResult(context.Where(x => x.Email == email).FirstOrDefault());
            return mapper.Map<UserDocument, User>(userDocument);

        }
        public async Task<User> GetById(Guid id)
        {

            var userDocument = await Task.FromResult(context.Where(x => x.Id == id).FirstOrDefault());
            return mapper.Map<UserDocument, User>(userDocument);
        }

        private async Task<UserDocument> GetUserDocumentById(Guid id) => await Task.FromResult(context.Where(x => x.Id == id).FirstOrDefault());



        public async Task Update(UserDocument userDocument)
        {
            await Task.CompletedTask;
        }

        public async Task Delete(Guid id)
        {
            var user = await GetUserDocumentById(id);
            await Task.FromResult(context.Remove(user));
        }
    }
}
