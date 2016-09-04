using Newtonsoft.Json;
using System;

namespace Colu.Models
{
    public class Request
    {
        [JsonProperty("jsonrpc")]
        public string Jsonrpc { get; private set; }

        [JsonProperty("method")]
        public String Method { get; internal set; }

        [JsonProperty("id")]
        public String Id { get; set; }

        public Request()
        {
            this.Jsonrpc = "2.0";
        }
    }
}
