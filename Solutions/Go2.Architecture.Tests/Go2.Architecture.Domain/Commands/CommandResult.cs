namespace Tests.Go2.Architecture.Domain.Commands
{
    public class CommandResult<T>
    {
        public bool Success { get; set; }

        public T Command { get; set; }
    }
}