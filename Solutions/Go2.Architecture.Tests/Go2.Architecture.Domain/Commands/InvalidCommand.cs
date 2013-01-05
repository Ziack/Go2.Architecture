namespace Tests.Go2.Architecture.Domain.Commands
{
    using System.ComponentModel.DataAnnotations;

    using global::Go2.Architecture.Domain.Commands;

    public class InvalidCommand : CommandBase
    {
        [Required]
        public bool? Invalid { get; set; }

        [Range(100, 199)]
        public int InvalidInt { get; set; }
    }
}