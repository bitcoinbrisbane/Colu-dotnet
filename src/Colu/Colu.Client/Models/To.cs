using Newtonsoft.Json;
using System;

namespace Colu.Client
{
    public class To
    {
        [JsonProperty("address")]
        public String address { get; set; }

        [JsonProperty("phoneNumber")]
        public String PhoneNumber { get; set; }

        [JsonProperty("assetId")]
        public String AssetId { get; set; }

        [JsonProperty("amount")]
        public UInt64 Amount { get; set; } 

    }
}
