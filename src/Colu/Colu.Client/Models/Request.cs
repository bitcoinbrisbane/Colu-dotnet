using Newtonsoft.Json;
using System;

namespace Colu.Models
{
    public class Request
    {
        public String jsonrpc { get; private set; }

        [JsonProperty("method")]
        public String Method { get; internal set; }

        [JsonProperty("id")]
        public String Id { get; set; }

        public Request()
        {
            this.jsonrpc = "2.0";
        }
    }
}
