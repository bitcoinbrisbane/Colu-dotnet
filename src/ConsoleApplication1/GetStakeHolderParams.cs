using Newtonsoft.Json;
using System;

namespace ConsoleApplication1
{
    public class GetStakeHolderParams
    {
        [JsonProperty("assetId")]
        public String AssetId { get; set; }

        public String numConfirmations { get; set; }
    }
}
