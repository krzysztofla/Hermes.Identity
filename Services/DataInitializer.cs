using Hermes.Identity.Entities;
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
            var user = new User("krzysztof.lach@icloud.com", "Kris");
            await _userRepository.Add(user);
        }
    }
}
