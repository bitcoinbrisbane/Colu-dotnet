using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Colu.Models.GetAddress
{
    public class Response : Colu.Models.Response
    {
        [JsonProperty(PropertyName="result")]
        public String Address { get; set; }
    }
}