using System;
using System.Collections.Generic;

namespace Colu.Models.GetAssetData
{
    public class Request : Colu.Models.Request
    {
        private const String METHOD_NAME = "coloredCoins.getAssetData";

        public Request()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Method = METHOD_NAME;
        }
    }
}
