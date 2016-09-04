using Newtonsoft.Json;
using System;

namespace Colu.Models.GetAssetData
{
    public class MetaDataOfIssuance
    {
        [JsonProperty("assetid")]
        public String AssetId { get; set; }

        [JsonProperty("assetName")]
        public String AssetName { get; set; }

        [JsonProperty("assetGenesis")]
        public String AssetGenesis { get; set; }

        [JsonProperty("issuer")]
        public String Issuer { get; set; }

        [JsonProperty("description")]
        public String Description { get; set; }
    }
}
