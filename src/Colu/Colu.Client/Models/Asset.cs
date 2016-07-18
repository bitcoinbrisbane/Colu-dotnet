using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Colu.Models
{
    public class Asset
    {
        [JsonProperty(PropertyName = "amount")]
        public Int64 Amount { get; set; }

        public Boolean reissueable { get; set; }

        public Object metadata { get; set; }

        public List<Transfer> transfer { get; set; }

        [JsonProperty(PropertyName = "issueAddress")]
        public String IssueAddress { get; set; }

        [JsonProperty(PropertyName = "assetId")]
        public String AssetId { get; set; }

        [JsonProperty(PropertyName = "divisibility")]
        public Int64 Divisibility { get; set; }

        public Asset()
        {
            this.transfer = new List<Transfer>();
        }
    }
}
