using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Colu.Models.IssueAsset
{
    public class Asset
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

        [JsonProperty("transfer")]
        public ICollection<To> Transfer { get; set; }

        [JsonProperty("rules")]
        public Rules Rules { get; set; }

        [JsonProperty("minters")]
        public ICollection<Minters> Minters { get; set; }

        [JsonProperty("userData")]
        public Object UserData { get; set; }

        public Asset()
        {
            this.MetaData = new MetaData();
            this.Transfer = new List<To>();
        }
    }
}
