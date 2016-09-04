using Newtonsoft.Json;
using System;

namespace Colu.Models.GetStakeHolders
{
    public class Holder
    {
        [JsonProperty("address")]
        public String Address { get; set; }

        [JsonProperty("amount")]
        public Int64 Amount { get; set; }
    }
}
