using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace Hermes.Identity.Mongo.Documents
{
    public class UserDocument
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
