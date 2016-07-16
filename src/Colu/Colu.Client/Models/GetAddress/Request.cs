using System;

namespace Colu.Models.GetAddress
{
    public class Request : Models.Request, IRequest
    {
        public Request()
        {
            this.Method = "hdwallet.getAddress";
        }
    }
}
