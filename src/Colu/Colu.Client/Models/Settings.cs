using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colu.Client.Models
{
    public class Settings
    {
        [JsonProperty(PropertyName="apiKey")]
        public String Network { get; set; }

        public String ApiKey { get; set; }
    }
}
