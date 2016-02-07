using Newtonsoft.Json;
using System;

namespace Colu.Client.Models
{
    public class Settings
    {
        [JsonProperty(PropertyName = "network")]
        public String Network { get; set; }

        [JsonProperty(PropertyName = "apiKey")]
        public String ApiKey { get; set; }

        public String colourCoinsHost { get; set; }

        public String coluHost { get; set; }
    }
}
