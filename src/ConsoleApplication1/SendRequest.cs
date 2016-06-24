using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class SendRequest
    {
        public String jsonrpc { get; set; }

        public String method { get; set; }

        [JsonProperty("params")]
        public Asset param { get; set; }

        public SendRequest()
        {
            this.method = "issueAsset";
            this.jsonrpc = "2.0";
        }
    }
}
