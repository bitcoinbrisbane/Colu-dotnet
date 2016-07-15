using Newtonsoft.Json;
using System;

namespace Colu.Models.IssueAsset
{
    public class Result
    {
        [JsonProperty("txHex")]
        public String TxHex { get; set; }

        [JsonProperty("txId")]
        public String TxId { get; set; }

        [JsonProperty("assetId")]
        public String AssetId { get; set; }
    }
}
