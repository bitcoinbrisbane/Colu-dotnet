using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Colu.Models.GetAssets
{
    public class Response : Colu.Models.Response
    {
        [JsonProperty(PropertyName = "result")]
        public Asset[] Result { get; set; }
    }
}
