using Newtonsoft.Json;

namespace Colu.Models
{
    public class GetAssetDataRequest : Response
    {
        [JsonProperty("params")]
        public Asset param { get; set; }
    }
}
