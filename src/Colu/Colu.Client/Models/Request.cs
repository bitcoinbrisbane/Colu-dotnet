using System;

namespace Colu.Client
{
    public class Request
    {
        public String jsonrpc { get; set; }

        public String method { get; set; }

        public String id { get; set; }

        public Request()
        {
            this.jsonrpc = "2.0";
        }
    }
}
