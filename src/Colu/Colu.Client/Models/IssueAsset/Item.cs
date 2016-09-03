using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colu.Models.IssueAsset
{
    public class Item
    {
        [JsonProperty("address")]
        public String Address { get; set; }

        [JsonProperty("assetId")]
        public String AssetId { get; set; }

        [JsonProperty("value")]
        public Int64 Value { get; set; }
    }
}
