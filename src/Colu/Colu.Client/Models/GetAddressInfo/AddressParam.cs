using Newtonsoft.Json;
using System;

namespace Colu.Models
{
    public class AddressParam
    {
        [JsonProperty("address")]
        public String Address { get; set; }
    }
}
