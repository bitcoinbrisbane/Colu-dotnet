using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Colu.Models.GetAddressInfo
{
    public class Response : Models.Response
    {
        [JsonProperty("result")]
        public Result Result { get; set; }
    }
}
