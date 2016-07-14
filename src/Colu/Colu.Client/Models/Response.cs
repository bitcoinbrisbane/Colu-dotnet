using Newtonsoft.Json;
using System;

namespace Colu.Client
{
    public class Response
    {
        public String jsonrpc { get; set; }

        [JsonProperty("method")]
        public String Method { get; set; }

        [JsonProperty("id")]
        public String Id { get; set; }
    }
}
