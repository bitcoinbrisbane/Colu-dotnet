using Newtonsoft.Json;
using System;

namespace Colu.Models.IssueAsset
{
    public class Domain
    {
        [JsonProperty("url")]
        public String Url { get; set; }
    }
}