using System;

namespace Colu.Client
{
    public class GetAddressRequest : Request, IRequest
    {
        public GetAddressRequest()
        {
            this.Method = "hdwallet.getAddress";
            this.jsonrpc = "2.0";
        }
    }
}
