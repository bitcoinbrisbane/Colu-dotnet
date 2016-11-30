using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Colu.Models.BurnAsset
{
    public class BurnAsset
    {
        [JsonProperty("from")]
        public ICollection<String> From { get; set; }

        [JsonProperty("burn")]
        public ICollection<Burn> Burn { get; set; }
    }
}
