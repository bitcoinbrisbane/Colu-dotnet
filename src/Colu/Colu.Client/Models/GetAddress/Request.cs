using System;

namespace Colu.Client.Models.GetAddress
{
    public class Request : Colu.Client.Models.Request, IRequest
    {
        public Request()
        {
            this.Method = "hdwallet.getAddress";
        }
    }
}
