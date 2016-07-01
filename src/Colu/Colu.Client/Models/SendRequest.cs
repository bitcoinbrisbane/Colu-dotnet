using Newtonsoft.Json;
using System;

namespace Colu.Client
{
    public class SendRequest
    {
        public String jsonrpc { get; set; }

        public String method { get; set; }

        [JsonProperty("params")]
        public Asset param { get; set; }

        public SendRequest()
        {
            this.method = "issueAsset";
            this.jsonrpc = "2.0";
        }
    }
}
