namespace Go2.Architecture.Domain.Commands
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public interface ICommand
    {
        bool IsValid();

        ICollection<ValidationResult> ValidationResults();
    }
}