using Newtonsoft.Json;
using System;

namespace Colu.Models.GetAssetData
{
    public class GetAddressDataParams
    {
        [JsonProperty("assetId")]
        public String AssetId { get; set; }

        [JsonProperty("numConfirmations")]
        public Int32 NumberOfConfirmations { get; set; }
    }
}
