using Newtonsoft.Json;
using System;

namespace Colu.Models.GetAddress
{
    public class Response : Colu.Models.Response
    {
        [JsonProperty(PropertyName="result")]
        public String Address { get; set; }
    }
}