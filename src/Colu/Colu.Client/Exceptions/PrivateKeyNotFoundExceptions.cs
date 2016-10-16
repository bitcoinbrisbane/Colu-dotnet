using System;

namespace Colu.Exceptions
{
    public class PrivateKeyNotFoundExceptions : Exception
    {
        public PrivateKeyNotFoundExceptions()
        {
        }

        public PrivateKeyNotFoundExceptions(string message)
        : base(message)
        {
        }

        public PrivateKeyNotFoundExceptions(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
