namespace Tests.Go2.Architecture.Domain.Commands
{
    using System.ComponentModel.DataAnnotations;

    using global::Go2.Architecture.Domain.Commands;

    public class ValidCommand : CommandBase
    {
        public ValidCommand()
        {
            Valid = true;
        }

        [Required]
        public bool? Valid { get; set; }
    }
}