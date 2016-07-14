using Newtonsoft.Json;
using System;

namespace Colu.Client.Models.IssueAsset
{
    public class Response : Colu.Client.Models.Response
    {
        [JsonProperty("result")]
        public IssueAsset.Result Result { get; set; }
    }
}