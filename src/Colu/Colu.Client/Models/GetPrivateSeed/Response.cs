using Newtonsoft.Json;
using System;

namespace Colu.Models.GetPrivateSeed
{
    public class Response : Colu.Models.Response
    {
        [JsonProperty("result")]
        public String Result { get; set; }
    }
}
