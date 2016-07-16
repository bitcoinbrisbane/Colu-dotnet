using Newtonsoft.Json;
using System;

namespace Colu.Models.GetAddressInfo
{
    public class Request : Models.Request, IRequest
    {
        [JsonProperty("params")]
        public AddressParam Params { get; set; }

        public Request()
        {
            this.Method = "coloredCoins.getAddressInfo";
            this.Params = new AddressParam();
        }
    }
}
