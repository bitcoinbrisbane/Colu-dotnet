using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Colu.Client
{
    public class GetAddressResponse
    {
        [JsonProperty(PropertyName="address")]
        public String Address { get; set; }

        [JsonProperty(PropertyName = "utxos")]
        public ICollection<Colu.Client.Models.UTXO> Utxos { get; set; }
    }
}