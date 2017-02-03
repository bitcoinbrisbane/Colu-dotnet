using Newtonsoft.Json;
using System;

namespace Colu.Models.GetMnemonic
{
    public class Response : Colu.Models.Response
    {
        [JsonProperty(PropertyName="result")]
        public String Result { get; set; }
    }
}