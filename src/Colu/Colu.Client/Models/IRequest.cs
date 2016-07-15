using System;

namespace Colu.Models
{
    public interface IRequest
    {
        String jsonrpc { get; }

        String Method { get; }
    }
}
