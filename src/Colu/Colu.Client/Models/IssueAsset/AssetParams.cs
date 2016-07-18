using Newtonsoft.Json;
using System;

namespace Colu.Models.IssueAsset
{
    public class AssetParams
    {
        [JsonProperty("amount")]
        public Int64 Amount { get; set; }

        [JsonProperty("issueAddress")]
        public String IssueAddress { get; set; }

        [JsonProperty("divisibility")]
        public Int64 Divisibility { get; set; }

        [JsonProperty("reissueable")]
        public Boolean Reissueable { get; set; }

        [JsonProperty("metadata")]
        public MetaData MetaData { get; set; }

        public AssetParams()
        {
            this.MetaData = new MetaData();
        }
    }
}
