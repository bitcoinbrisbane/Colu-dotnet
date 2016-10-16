using Newtonsoft.Json;
using System;

namespace Colu.Models
{
    public class Error
    {
        [JsonProperty(PropertyName = "code")]
        public Int32 Code { get; set; }

        [JsonProperty(PropertyName = "message")]
        public String Message { get; set; }

        [JsonProperty(PropertyName = "data")]
        public String Data { get; set; }
    }
}
