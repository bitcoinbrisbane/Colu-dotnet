using Newtonsoft.Json;
using System;

namespace Colu.Models.IssueAsset
{
    public class Minters
    {
        [JsonProperty("address")]
        public String Address { get; set; }

        [JsonProperty("locked")]
        public Boolean Locked { get; set; }
    }
}
