using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colu.Models.IssueAsset
{
    public class Rules
    {
        [JsonProperty("version")]
        public Int32 Version { get; set; }

        public Decimal Fees { get; set; }
    }
}
