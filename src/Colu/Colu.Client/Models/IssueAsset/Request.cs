using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Colu.Models.IssueAsset
{
    public class Request : Response, IRequest
    {
        [JsonProperty("params")]
        public IssueAsset.Params Param { get; set; }

        [JsonProperty("transfer")]
        public IList<To> Transfer { get; set; }

        public Request()
        {
            this.jsonrpc = "2.0";
            this.Method = "issueAsset";
            this.Param = new IssueAsset.Params();
            this.Transfer = new List<To>();
        }

        public Request(Int32 n)
        {
            this.jsonrpc = "2.0";
            this.Method = "issueAsset";
            this.Param = new IssueAsset.Params();
            this.Transfer = new List<To>(n);
        }
    }
}
