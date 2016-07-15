using Newtonsoft.Json;

namespace Colu.Models.SendAsset
{
    public class Request : Colu.Models.Request, IRequest
    {
        [JsonProperty("params")]
        public SendAsset param { get; set; }

        public Request()
        {
            this.Method = "sendAsset";
            this.param = new SendAsset();
        }
    }
}
