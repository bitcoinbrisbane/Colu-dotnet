using System;

namespace Colu.Exceptions
{
    public class NotEnoughFundsExceptions : Exception
    {
        public NotEnoughFundsExceptions()
        {
        }

        public NotEnoughFundsExceptions(string message)
        : base(message)
        {
        }

        public NotEnoughFundsExceptions(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
