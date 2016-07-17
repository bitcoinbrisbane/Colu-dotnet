using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Colu.Models.SendAsset
{
    public class Response : Colu.Models.Response
    {
        [JsonProperty("result")]
        public Result Result { get; set; }
    }
}
