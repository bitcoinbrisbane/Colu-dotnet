using Newtonsoft.Json;
using System;

namespace Colu.Models
{
    public class Response
    {
        [JsonProperty("jsonrpc")]
        public String jsonrpc { get; set; }

        [Obsolete]
        [JsonProperty("method")]
        public String Method { get; set; }

        [JsonProperty("id")]
        public String Id { get; set; }
    }
}
