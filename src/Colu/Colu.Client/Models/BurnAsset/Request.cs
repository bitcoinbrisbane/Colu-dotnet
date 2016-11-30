using Newtonsoft.Json;
using System;

namespace Colu.Models.BurnAsset
{
    public class Request : Models.Request, IRequest
    {
        [JsonProperty("params")]
        public BurnAsset Param { get; set; }

        public Request()
        {
            this.Method = "burnAsset";
            this.Param = new BurnAsset();
        }
    }
}