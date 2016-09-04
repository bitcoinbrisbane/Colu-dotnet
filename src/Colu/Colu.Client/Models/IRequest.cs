using System;

namespace Colu.Models
{
    public interface IRequest
    {
        String Jsonrpc { get; }

        String Method { get; }
    }
}
