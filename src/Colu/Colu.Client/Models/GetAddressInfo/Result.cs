using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Colu.Models.GetAddressInfo
{
    public class Result
    {
        [JsonProperty("address")]
        public String Address { get; set; }

        [JsonProperty("utxos")]
        public IList<UTXO> Utxos { get; set; }
    }
}
