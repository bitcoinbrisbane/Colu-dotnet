using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colu.Client.Models
{
    public class IssueAssetRequest : Request
    {
        [JsonProperty("params")]
        public IssueAssetParams param { get; set; }

        public IssueAssetRequest()
        {
            this.param = new IssueAssetParams();
        }
    }
}
