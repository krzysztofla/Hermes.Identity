using Hermes.Identity.Common.Markers;

namespace Hermes.Identity.Auth
{
    public interface IPasswordService : IService
    {
        bool IsValid(string hash, string password);
        string Hash(string password);
    }
}
