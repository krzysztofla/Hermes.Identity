using System.Collections.Generic;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson;

namespace Hermes.Identity.DbConfiguration
{
    public class IdentityConventions : IConventionPack
    {
        public IEnumerable<IConvention> Conventions => new List<IConvention> {
            new CamelCaseElementNameConvention(),
            new IgnoreExtraElementsConvention(true),
            new EnumRepresentationConvention(BsonType.String)             
        };
    }
}