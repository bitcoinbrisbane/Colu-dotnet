using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Colu.Models.IssueAsset
{
    public class Request : Models.Request, IRequest
    {
        [JsonProperty("params")]
        public AssetParams Param { get; set; }

        [JsonProperty("transfer")]
        public IList<To> Transfer { get; set; }

        [JsonProperty("experation")]
        public Experation Experation { get; set; }

        [JsonProperty("minters")]
        public IList<Minters> Minters { get; set; }

        public Request()
        {
            this.Method = "issueAsset";
            this.Param = new IssueAsset.AssetParams();
            this.Transfer = new List<To>();
        }

        public Request(Int32 n)
        {
            this.Method = "issueAsset";
            this.Param = new IssueAsset.AssetParams();
            this.Transfer = new List<To>(n);
        }
    }
}
