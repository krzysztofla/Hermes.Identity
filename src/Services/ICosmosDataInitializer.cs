using Hermes.Identity.Common.Markers;
using System.Threading.Tasks;

namespace Hermes.Identity.Services
{
    interface ICosmosDataInitializer : IService
    {
        Task SeedAsync();
    }
}
