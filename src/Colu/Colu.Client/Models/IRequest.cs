using System;

namespace Colu.Client
{
    public interface IRequest
    {
        String jsonrpc { get; }

        String Method { get; }
    }
}
