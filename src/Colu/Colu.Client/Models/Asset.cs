using System;
using System.Collections.Generic;

namespace Colu.Models
{
    public class Asset
    {
        public Int64 amount { get; set; }

        public Boolean reissueable { get; set; }

        public Object metadata { get; set; }

        public List<Transfer> transfer { get; set; }

        public String issueAddress { get; set; }

        public Int32 divisibility { get; set; }

        public Asset()
        {
            //this.metadata = new List<MetaData>();
            this.transfer = new List<Transfer>();
        }
    }
}
