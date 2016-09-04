using Newtonsoft.Json;
using System;

namespace Colu.Models.GetAssetData
{
    public class AssetData
    {
        [JsonProperty("address")]
        public String Address { get; set; }

        [JsonProperty("amount")]
        public Int64 Amount { get; set; }

        [JsonProperty("utxo")]
        public String Utxo { get; set; }
    }
}
