using Newtonsoft.Json;
using System;

namespace Colu.Models.GetStakeHolders
{
    public class GetStakeHolderParams
    {
        [JsonProperty("assetId")]
        public String AssetId { get; set; }

        [JsonProperty("numConfirmations")]
        public Int32 NumberConfirmations { get; set; }
    }
}
