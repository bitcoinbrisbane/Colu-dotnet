using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Colu.Models.SendAsset
{
    public class SendAsset
    {
        [JsonProperty("from")]
        public IList<String> From { get; set; }

        [JsonProperty("sendutxos")]
        public IList<String> SendUtxos { get; set; }

        [JsonProperty("to")]
        public IList<To> To { get; set; }

        [JsonProperty("metadata")]
        public MetaData MetaData { get; set; }

        public SendAsset()
        {
            this.From = new List<String>();
            this.To = new List<To>();
        }
    }
}
