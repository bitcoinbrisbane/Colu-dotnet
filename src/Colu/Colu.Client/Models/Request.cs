using Newtonsoft.Json;
using System;

namespace Colu.Client
{
    public class Request
    {
        public String jsonrpc { get; set; }

        [JsonProperty("method")]
        public String Method { get; set; }

        public String id { get; set; }

        public Request()
        {
            this.jsonrpc = "2.0";
        }
    }
}
