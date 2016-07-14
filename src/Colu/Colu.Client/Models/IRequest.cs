using System;

namespace Colu.Client.Models
{
    public interface IRequest
    {
        String jsonrpc { get; }

        String Method { get; }
    }
}
