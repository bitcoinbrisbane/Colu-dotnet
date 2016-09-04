using Newtonsoft.Json;
using System;

namespace Colu.Models.SendAsset
{
    public class Result
    {
        [JsonProperty("txHex")]
        public String TxHex { get; set; }

        [JsonProperty("assetId")]
        public String AssetId { get; set; }

        [JsonProperty("txid")]
        public String TxId { get; set; }
    }
}
