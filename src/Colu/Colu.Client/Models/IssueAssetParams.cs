using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colu.Client.Models
{
    public class IssueAssetParams
    {
        public Int64 amount { get; set; }

        public String issueAddress { get; set; }

        public Int64 divisibility { get; set; }

        public Boolean reissueable { get; set; }
    }
}
