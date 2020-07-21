using System.Threading.Tasks;

namespace Hermes.Identity.Command
{
    public interface ICommandDispacher
    {
         Task SendAsync<T>(T command) where T : ICommand;
    }
}