using System;
using System.Threading.Tasks;
using Autofac;

namespace Hermes.Identity.Command
{
    public class CommandDispacher : ICommandDispacher
    {
        private readonly IComponentContext componentContext;

        public CommandDispacher(IComponentContext componentContext)
        {
            this.componentContext = componentContext;
        }

        public async Task Dispatch<T>(T command) where T : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException();
            }
            await componentContext.Resolve<ICommandHandler<T>>().Handle(command);
        }
    }
}