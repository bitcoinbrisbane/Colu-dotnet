using Newtonsoft.Json;
using System;

namespace Colu.Models.IssueAsset
{
    public class Experation
    {
        [JsonProperty("validUntil")]
        public Int64 ValidUntil { get; set; }

        [JsonProperty("locked")]
        public Boolean Locked { get; set; }
    }
}
