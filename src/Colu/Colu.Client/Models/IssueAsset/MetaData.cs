using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Colu.Models.IssueAsset
{
    public class MetaData
    {
        [JsonProperty("assetName")]
        public String AssetName { get; set; }

        [JsonProperty("issuer")]
        public String Issuer { get; set; }
    }
}
