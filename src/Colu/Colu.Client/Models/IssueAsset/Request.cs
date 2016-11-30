using Newtonsoft.Json;
using System;

namespace Colu.Models.IssueAsset
{
    public class Request : Models.Request, IRequest
    {
        [JsonProperty("params")]
        public Asset Param { get; set; }

        public Request()
        {
            this.Method = "issueAsset";
            this.Param = new IssueAsset.Asset();
        }

        //public Request(Int32 n)
        //{
        //    this.Method = "issueAsset";
        //    this.Param = new IssueAsset.AssetParams();
        //}
    }
}
