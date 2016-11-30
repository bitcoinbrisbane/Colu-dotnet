using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Colu.Models
{
    public class Fees
    {
        [JsonProperty("items")]
        public ICollection<Item> Items { get; set; }

        [JsonProperty("locked")]
        public Boolean Locked { get; set; }
    }
}
