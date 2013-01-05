using Go2.Architecture.Domain.Commands;

namespace Tests.Go2.Architecture.Domain.Commands
{
    public class TestCommandHandlerWithResult<TCommand> : ICommandHandler<TCommand, CommandResult<TCommand>> where TCommand : ICommand
    {
        public CommandResult<TCommand> Handle(TCommand command)
        {
            return new CommandResult<TCommand> { Command = command, Success = true };
        }
    }
}