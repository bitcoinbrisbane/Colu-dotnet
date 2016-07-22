using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colu.Models.IssueAsset
{
    public class Url
    {
        [JsonProperty("name")]
        public String Name { get; set; }

        public String url { get; set; }

        [JsonProperty("mineType")]
        public String MineType { get; set; }

        [JsonProperty("dataHash")]
        public String DataHash { get; set; }
    }
}
