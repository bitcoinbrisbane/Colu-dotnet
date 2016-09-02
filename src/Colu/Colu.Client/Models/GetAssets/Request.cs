using Newtonsoft.Json;
using System;

namespace Colu.Models.GetAssets
{
    public class Request : Models.Request
    {
        private const String METHOD_NAME = "getAssets";

        public Request()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Method = METHOD_NAME;
        }
    }
}
