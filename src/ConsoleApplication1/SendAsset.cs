using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    //http://documentation.colu.co/#SendAsset36
    public class SendAsset
    {
        public String jsonrpc { get; set; }

        public String method { get; set; }

        [JsonProperty("params")]
        public Asset param { get; set; }

        public IList<To> to { get; set; }

        public SendAsset()
        {
            this.method = "issueAsset";
            this.jsonrpc = "2.0";
            this.to = new List<To>();
        }
    }
}
