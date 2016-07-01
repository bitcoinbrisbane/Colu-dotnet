using System;

namespace Colu.Client
{
    public interface IRequest
    {
        String jsonrpc { get; set; }

        String method { get; set; }
    }
}
