using Newtonsoft.Json;
using System;

namespace Colu.Models.IssueAsset
{
    public class Response : Colu.Models.Response
    {
        [JsonProperty("result")]
        public Result Result { get; set; }
    }
}