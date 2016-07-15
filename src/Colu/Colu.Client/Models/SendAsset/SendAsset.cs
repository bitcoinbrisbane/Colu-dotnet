using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Colu.Models.SendAsset
{
    public class SendAsset
    {
        [JsonProperty("from")]
        public IList<String> from { get; set; }

        public IList<To> to { get; set; }

        public SendAsset()
        {
            this.from = new List<String>();
            this.to = new List<To>();
        }
    }
}
