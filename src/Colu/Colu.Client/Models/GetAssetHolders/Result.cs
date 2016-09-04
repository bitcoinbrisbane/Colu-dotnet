using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Colu.Models.GetStakeHolders
{
    public class Result
    {
        [JsonProperty("assetId")]
        public String AssetId { get; set; }

        [JsonProperty("divisibility")]
        public Decimal Divisibility { get; set; }

        [JsonProperty("holders")]
        public IList<Holder> Holders { get; set; }
    }
}
