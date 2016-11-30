using Newtonsoft.Json;
using System;

namespace Colu.Models
{
    public class Item
    {
        [JsonProperty("address")]
        public String Address { get; set; }

        [JsonProperty("assetId")]
        public String AssetId { get; set; }

        [JsonProperty("value")]
        public Int64 Value { get; set; }
    }
}
