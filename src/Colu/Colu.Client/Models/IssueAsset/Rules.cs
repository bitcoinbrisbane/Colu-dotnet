using Newtonsoft.Json;
using System;

namespace Colu.Models.IssueAsset
{
    public class Rules
    {
        [JsonProperty("version")]
        public Int32 Version { get; set; }

        [JsonProperty("fees")]
        public Fee Fees { get; set; }

        [JsonProperty("expiration")]
        public Expiration Expiration { get; set; }

        [JsonProperty("callback")]
        public Object CallBack { get; set; }
    }
}
