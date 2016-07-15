using Newtonsoft.Json;
using System;

namespace Colu.Models.GetStakeHolders
{
    public class Request : Models.Request, IRequest
    {
        [JsonProperty("params")]
        public GetStakeHolderParams Params { get; set; }

        public Request()
        {
            this.Method = "coloredCoins.getAssetData";
            this.Id = "1";
            this.Params = new GetStakeHolderParams();
        }
    }
}
