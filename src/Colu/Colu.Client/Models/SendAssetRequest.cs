using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Colu.Client
{
    //http://documentation.colu.co/#SendAsset36
    public class SendAssetRequest : Request
    {
        [JsonProperty("params")]
        public Asset param { get; set; }

        public IList<To> to { get; set; }

        public SendAssetRequest()
        {
            this.method = "issueAsset";
            this.jsonrpc = "2.0";
            this.to = new List<To>();
        }
    }
}
