using System;

namespace ConsoleApplication1
{
    public interface IRequest
    {
        String jsonrpc { get; set; }

        String method { get; set; }
    }
}
