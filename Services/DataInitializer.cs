using Hermes.Identity.Entities;
using Hermes.Identity.Mongo.Documents;
using Hermes.Identity.Repository;
using System.Threading.Tasks;

namespace Hermes.Identity.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IUserRepository _userRepository;
        public DataInitializer(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task SeedAsync()
        {
            var user = new UserDocument();
            await _userRepository.Add(user);
        }
    }
}
