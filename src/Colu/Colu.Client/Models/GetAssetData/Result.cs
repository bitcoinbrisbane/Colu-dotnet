using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Colu.Models.GetAssetData
{
    public class Result
    {
        [JsonProperty("assetId")]
        public String AssetId { get; set; }

        [JsonProperty("assetAmount")]
        public Int64 AssetAmount { get; set; }

        [JsonProperty("assetTotalAmount")]
        public Int64 AssetTotalAmount { get; set; }
    }
}
