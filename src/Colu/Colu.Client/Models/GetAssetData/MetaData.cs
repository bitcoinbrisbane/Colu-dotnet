using Newtonsoft.Json;
using System;

namespace Colu.Models.GetAssetData
{
    public class MetaData
    {
        [JsonProperty("divisibility")]
        public Int64 Divisibility { get; set; }

        [JsonProperty("version")]
        public String Version { get; set; }

        [JsonProperty("totalSupply")]
        public Int64 TotalSupply { get; set; }

        [JsonProperty("numOfHolders")]
        public Int64 NumberOfHolders { get; set; }

        [JsonProperty("numOfTransactions")]
        public Int64 NumberOfTransactions { get; set; }

        [JsonProperty("numOfIssuance")]
        public Int64 NumberOfIssuance { get; set; }

        [JsonProperty("firstAppearsInBlock")]
        public Int64 FirstAppearsInBlock { get; set; }

        [JsonProperty("metadataOfIssuance")]
        public MetaDataOfIssuance MetaDataOfIssuance { get; set; }
    }
}
