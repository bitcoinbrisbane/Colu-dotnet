using Newtonsoft.Json;
using System;

namespace Colu.Models.GetStakeHolders
{
    public class Request : Models.Request, IRequest
    {
        private const String METHOD_NAME = "coloredCoins.getStakeHolders";

        [JsonProperty("params")]
        public GetStakeHolderParams Params { get; set; }

        [JsonProperty("result")]
        public Result Result { get; set; }

        public Request()
        {
            this.Method = METHOD_NAME;
            this.Id = Guid.NewGuid().ToString();
            this.Params = new GetStakeHolderParams();
        }
    }
}
