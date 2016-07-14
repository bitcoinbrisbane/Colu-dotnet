using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Colu.Client.Models
{
    public class GetAddressResponse : Response
    {
        [JsonProperty(PropertyName="result")]
        public String Address { get; set; }
    }
}