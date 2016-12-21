using Newtonsoft.Json;
using System;

namespace Colu.Models
{
    public class Rules
    {
        [JsonProperty("version")]
        public String Version { get; set; }

        //[JsonProperty("fees")]
        //public Fees Fees { get; set; }

        //[JsonProperty("expiration")]
        //public Expiration Expiration { get; set; }

        //[JsonProperty("callback")]
        //public Object CallBack { get; set; }

        public Rules()
        {
        }

        public Rules(Int32 version)
        {
            this.Version = version.ToString();
        }
    }
}
