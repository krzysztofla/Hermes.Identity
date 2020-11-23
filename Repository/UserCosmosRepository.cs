using AutoMapper;
using Hermes.Identity.Entities;
using Hermes.Identity.Mongo.Documents;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Identity.Repository
{
    public class UserCosmosRepository : ICosmosRepository, IUserRepository, IRepository
    {
        private readonly Microsoft.Azure.Cosmos.Container _cosmosContainer;
        private readonly IMapper _mapper;
        public UserCosmosRepository(Microsoft.Azure.Cosmos.Container container, IMapper mapper)
        {
            _cosmosContainer = container;
            _mapper = mapper;
        }

        public async Task Add(UserDocument userDocument)
        {
            await _cosmosContainer.CreateItemAsync<UserDocument>(userDocument, new PartitionKey(userDocument.Id.ToString()));
        }

        public async Task Delete(Guid id)
        {
            await _cosmosContainer.DeleteItemAsync<UserDocument>(id.ToString(), new PartitionKey(id.ToString()));
        }

        public async Task<Entities.User> GetByEmail(string email)
        {
            var queryable = _cosmosContainer.GetItemLinqQueryable<UserDocument>(false);
            var userDocument = await queryable.Where(x => x.Email.Equals(email))
                                              .ToFeedIterator()
                                              .ReadNextAsync();
            var user = userDocument.Resource.FirstOrDefault();
            return _mapper.Map<UserDocument, Entities.User>(user);
        }

        public async Task<Entities.User> GetById(Guid id)
        {
            var payload = await _cosmosContainer.ReadItemAsync<UserDocument>(id.ToString(), new PartitionKey(id.ToString()));
            return _mapper.Map<UserDocument, Entities.User>(payload.Resource);
        }

        public async Task Update(UserDocument userDocument)
        {
            var payload = await _cosmosContainer.ReadItemAsync<UserDocument>(userDocument.Id.ToString(), new PartitionKey(userDocument.Id.ToString()));
            var user = payload.Resource;
            
            await _cosmosContainer.ReplaceItemAsync<UserDocument>(userDocument, user.Id.ToString(), new PartitionKey(user.Id.ToString()));
        }

        public async Task<List<Entities.User>> Browse()
        {
            var queryDefinition = new QueryDefinition($"SELECT * FROM c");
            FeedIterator<UserDocument> queryResultSetIterator = _cosmosContainer.GetItemQueryIterator<UserDocument>(queryDefinition);
            var users = new List<UserDocument>();

            while (queryResultSetIterator.HasMoreResults)
            {
                var currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (UserDocument user in currentResultSet)
                {
                    users.Add(user);
                }
            }
            return _mapper.Map<List<UserDocument>, List<Entities.User>>(users);
        }
    }
}
