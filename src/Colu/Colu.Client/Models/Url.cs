using Newtonsoft.Json;
using System;


namespace Colu.Models.IssueAsset
{
    public class Url
    {
        [JsonProperty("name")]
        public String Name { get; set; }

        public String url { get; set; }

        [JsonProperty("mimeType")]
        public String MimeType { get; set; }

        [JsonProperty("dataHash")]
        public String DataHash { get; set; }
    }
}
