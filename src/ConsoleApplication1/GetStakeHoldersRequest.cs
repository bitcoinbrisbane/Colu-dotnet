using Newtonsoft.Json;
using System;

namespace ConsoleApplication1
{
    public class GetStakeHoldersRequest : Request, IRequest
    {
        [JsonProperty("params")]
        public GetStakeHolderParams Params { get; set; }

        public GetStakeHoldersRequest()
        {
            this.method = "coloredCoins.getAssetData";
            this.jsonrpc = "2.0";
            this.id = "1";

            this.Params = new GetStakeHolderParams();
        }
    }
}
