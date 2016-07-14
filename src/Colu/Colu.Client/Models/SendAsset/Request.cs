using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Colu.Client.Models.SendAsset
{
    //http://documentation.colu.co/#SendAsset36
    public class Request : Response
    {
        [JsonProperty("params")]
        public Asset param { get; set; }

        public IList<To> to { get; set; }

        public Request()
        {
            this.Method = "issueAsset";
            this.jsonrpc = "2.0";
            this.to = new List<To>();
        }
    }
}