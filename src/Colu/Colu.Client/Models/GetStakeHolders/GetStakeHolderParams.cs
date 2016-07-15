using Newtonsoft.Json;
using System;

namespace Colu.Models
{
    public class GetStakeHolderParams
    {
        [JsonProperty("assetId")]
        public String AssetId { get; set; }

        [JsonProperty("numConfirmations")]
        public String NumberConfirmations { get; set; }
    }
}
