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
            await _cosmosContainer.CreateItemAsync(userDocument, new PartitionKey(userDocument.Id.ToString()));
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Entities.User> GetByEmail(string email)
        {
            try
            {
                var queryable = _cosmosContainer.GetItemLinqQueryable<UserDocument>(false);
                var userDocument = await queryable.Where(x => x.Email.Equals(email))
                                                  .ToFeedIterator()
                                                  .ReadNextAsync();
                var user = userDocument.Resource.FirstOrDefault();
                return _mapper.Map<UserDocument, Entities.User>(user);
            }
            catch (CosmosException ex)
            {
                return null;
            }
        }

        public Task<Entities.User> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(UserDocument userDocument)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserDocument>> Browse()
        {
            var queryDefinition = new QueryDefinition($"SELECT * FROM c");
            FeedIterator<UserDocument> queryResultSetIterator = _cosmosContainer.GetItemQueryIterator<UserDocument>(queryDefinition);
            var users = new List<UserDocument>();

            while (queryResultSetIterator.HasMoreResults)
            {
                var currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (UserDocument family in currentResultSet)
                {
                    users.Add(family);
                }
            }
            return null;
        }
    }
}
