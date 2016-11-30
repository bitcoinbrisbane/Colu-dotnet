using Newtonsoft.Json;
using System;

namespace Colu.Models.BurnAsset
{
    public class Burn
    {
        [JsonProperty("amount")]
        public Int64 Amount { get; set; }

        [JsonProperty("assetId")]
        public String AssetId { get; set; }
    }
}