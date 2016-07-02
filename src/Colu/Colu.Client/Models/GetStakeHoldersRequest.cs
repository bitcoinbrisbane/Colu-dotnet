using Newtonsoft.Json;
using System;

namespace Colu.Client
{
    public class GetStakeHoldersRequest : Request, IRequest
    {
        [JsonProperty("params")]
        public GetStakeHolderParams Params { get; set; }

        public GetStakeHoldersRequest()
        {
            this.Method = "coloredCoins.getAssetData";
            this.jsonrpc = "2.0";
            this.id = "1";

            this.Params = new GetStakeHolderParams();
        }
    }
}
