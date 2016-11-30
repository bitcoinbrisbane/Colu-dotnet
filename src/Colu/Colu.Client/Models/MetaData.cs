using Colu.Models.IssueAsset;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Colu.Models
{
    public class MetaData
    {
        [JsonProperty("assetId")]
        public String AssetId { get; set; }

        [JsonProperty("assetName")]
        public String assetName { get; set; }

        [JsonProperty("assetGenesis")]
        public String AssetGenesis { get; set; }

        [JsonProperty("issuer")]
        public String Issuer { get; set; }

        [JsonProperty("description")]
        public String Description { get; set; }

        [JsonProperty("urls")]
        public ICollection<Url> Urls { get; set; }

        [JsonProperty("userData")]
        public Object UserData { get; set; }

        public MetaData()
        {
            this.Urls = new List<Url>();
        }
    }
}
