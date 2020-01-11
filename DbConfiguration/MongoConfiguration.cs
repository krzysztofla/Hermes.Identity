using MongoDB.Bson.Serialization.Conventions;

namespace Hermes.Identity.DbConfiguration
{
    public static class MongoConfiguration
    {
        private static bool initialized;

        public static void Initialize() {
            if(initialized) {
                return;
            }
            RegisterMongoConventions();
        }
        
        public static void RegisterMongoConventions() {
            ConventionRegistry.Register("Identity", new IdentityConventions(), x => true);
            initialized = true;
        }
    }
}