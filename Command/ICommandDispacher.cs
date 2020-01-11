using System.Threading.Tasks;

namespace Hermes.Identity.Command
{
    public interface ICommandDispacher
    {
         Task Dispatch<T>(T command) where T : ICommand;
    }
}