using Newtonsoft.Json;
using System;

namespace Colu.Client
{
    public class GetStakeHolderParams
    {
        [JsonProperty("assetId")]
        public String AssetId { get; set; }

        public String numConfirmations { get; set; }
    }
}
