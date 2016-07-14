using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Colu.Client.Models.GetAddress
{
    public class Response : Colu.Client.Models.Response
    {
        [JsonProperty(PropertyName="result")]
        public String Address { get; set; }
    }
}