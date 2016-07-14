using Newtonsoft.Json;
using System;

namespace Colu.Client
{
    public class GetStakeHoldersRequest : Response, IRequest
    {
        [JsonProperty("params")]
        public GetStakeHolderParams Params { get; set; }

        public GetStakeHoldersRequest()
        {
            this.Method = "coloredCoins.getAssetData";
            this.jsonrpc = "2.0";
            this.Id = "1";

            this.Params = new GetStakeHolderParams();
        }
    }
}
