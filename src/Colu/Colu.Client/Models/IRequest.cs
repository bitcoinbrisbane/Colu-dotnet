using System;

namespace Colu.Client
{
    public interface IRequest
    {
        String jsonrpc { get; set; }

        String Method { get; set; }
    }
}
