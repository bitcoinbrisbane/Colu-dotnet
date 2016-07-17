using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Colu.Models
{
    public class UTXO
    {
        //[JsonProperty(PropertyName = "_id")]
        //public String Id { get; set; }

        [JsonProperty(PropertyName = "txid")]
        public String TxId { get; set; }

        [JsonProperty(PropertyName = "index")]
        public Int32 Index { get; set; }

        [JsonProperty(PropertyName = "used")]
        public Boolean Used { get; set; }

        [JsonProperty(PropertyName = "value")]
        public Int64 Value { get; set; }

        [JsonProperty(PropertyName = "blocktime")]
        public Int64 BlockTime { get; set; }

        [JsonProperty(PropertyName = "blockheight")]
        public Int64 BlockHeight { get; set; }

        [JsonProperty(PropertyName = "assets")]
        public IList<Asset> Assets { get; set; }
    }
}
