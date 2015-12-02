using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colu.Client.Models
{
    public class UTXO
    {
        [JsonProperty(PropertyName = "_id")]
        public String Id { get; set; }

        [JsonProperty(PropertyName = "txid")]
        public String TxId { get; set; }

        [JsonProperty(PropertyName = "index")]
        public Int32 Index { get; set; }
    }
}
