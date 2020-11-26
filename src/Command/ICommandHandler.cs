using System.Threading.Tasks;

namespace Hermes.Identity.Command
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task Handle(T command);
    }
}