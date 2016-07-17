using Newtonsoft.Json;
using System;

namespace Colu.Models.SendAsset
{
    public class Result
    {
        [JsonProperty("txid")]
        public String TxId { get; set; }
    }
}
