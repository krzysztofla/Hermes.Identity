using Hermes.Identity.Entities;
using Hermes.Identity.Mongo.Documents;
using Hermes.Identity.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Hermes.Identity.Mongo
{
    public class UserContext
    {
        private readonly IMongoDatabase _database;

        public UserContext(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);

        }

        public IMongoCollection<UserDocument> Users
        {
            get
            {
                return _database.GetCollection<UserDocument>("User");
            }
        }

        public static IMongoCollection<UserDocument> CreateUserContext(IOptions<MongoSettings> settings) => new UserContext(settings).Users;
    }
}
