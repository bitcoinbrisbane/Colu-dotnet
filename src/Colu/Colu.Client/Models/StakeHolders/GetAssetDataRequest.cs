using Newtonsoft.Json;

namespace Colu.Client.Models
{
    public class GetAssetDataRequest : Response
    {
        [JsonProperty("params")]
        public Asset param { get; set; }
    }
}
