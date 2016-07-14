using Newtonsoft.Json;
using System;

namespace Colu.Client
{
    public class SendRequest : Request, IRequest
    {

        [JsonProperty("params")]
        public Asset param { get; set; }

        public SendRequest()
        {
            this.Method = "issueAsset";
            this.jsonrpc = "2.0";
        }
    }
}
