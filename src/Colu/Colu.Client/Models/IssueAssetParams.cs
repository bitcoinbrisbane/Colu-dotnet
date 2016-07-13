using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colu.Client.Models
{
    public class IssueAssetParams
    {
        [JsonProperty("amount")]
        public Int64 Amount { get; set; }

        [JsonProperty("issueAddress")]
        public String IssueAddress { get; set; }

        [JsonProperty("divisibility")]
        public Int64 Divisibility { get; set; }

        [JsonProperty("reissueable")]
        public Boolean Reissueable { get; set; }
    }
}
