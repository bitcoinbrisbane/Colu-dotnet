using Newtonsoft.Json;
using System;

namespace Colu.Models.GetAddressInfo
{
    public class Request : Models.Request, IRequest
    {
        private const String METHOD_NAME = "coloredCoins.getAddressInfo";

        [JsonProperty("params")]
        public AddressParam Params { get; set; }

        public Request()
        {
            this.Method = METHOD_NAME;
            this.Id = Guid.NewGuid().ToString();
            this.Params = new AddressParam();
        }
    }
}
