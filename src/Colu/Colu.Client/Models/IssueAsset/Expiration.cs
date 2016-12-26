using Newtonsoft.Json;
using System;

namespace Colu.Models.IssueAsset
{
    //[JsonProperty("expiration")]
    public class Expiration
    {
        [JsonProperty("validUntil")]
        public UInt64 ValidUntil { get; set; }

        [JsonProperty("locked")]
        public Boolean Locked { get; set; }
    }
}
