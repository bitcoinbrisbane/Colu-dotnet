using System;

namespace Colu.Models.GetAddress
{
    public class Request : Models.Request, IRequest
    {
        private const String METHOD_NAME = "hdwallet.getAddress";

        public Request()
        {
            this.Method = METHOD_NAME;
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
