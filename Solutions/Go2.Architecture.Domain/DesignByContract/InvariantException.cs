using System;

namespace Go2.Architecture.Domain.DesignByContract
{
    /// <summary>
    ///     Exception raised when an invariant fails.
    /// </summary>
    public class InvariantException : DesignByContractException
    {
        /// <summary>
        ///     Invariant Exception.
        /// </summary>
        public InvariantException()
        {
        }

        /// <summary>
        ///     Invariant Exception.
        /// </summary>
        public InvariantException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Invariant Exception.
        /// </summary>
        public InvariantException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}