using Hermes.Identity.Settings;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Identity.Services
{
    public class CosmosDataInitializer : ICosmosDataInitializer
    {
        private readonly CosmosClient _cosmosClient;
        private readonly CosmosSettings _cosmosSettings;
        public CosmosDataInitializer(CosmosClient cosmosClient, CosmosSettings cosmosSettings)
        {
            _cosmosClient = cosmosClient;
            _cosmosSettings = cosmosSettings;   
        }

        public async Task SeedAsync()
        {
            var database = await _cosmosClient.CreateDatabaseIfNotExistsAsync(_cosmosSettings.Database);
            await database.Database.CreateContainerAsync(_cosmosSettings.Container, "/id", 400);
        }
    }
}
