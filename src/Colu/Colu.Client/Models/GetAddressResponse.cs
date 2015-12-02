using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Colu.Client.Models
{
    public class GetAddressResponse
    {
        [JsonProperty(PropertyName="address")]
        public String Address { get; set; }

        [JsonProperty(PropertyName = "utxos")]
        public ICollection<UTXO> Utxos { get; set; }
    }
}