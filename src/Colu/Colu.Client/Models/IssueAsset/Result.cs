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

        [JsonProperty("financeTxid")]
        public String FinanceTxid { get; set; }

        [JsonProperty("assetId")]
        public String AssetId { get; set; }

        [JsonProperty("issueAddress")]
        public String IssueAddress { get; set; }
    }
}
