using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class GetAssetData : Request
    {
        [JsonProperty("params")]
        public Asset param { get; set; }
    }
}
