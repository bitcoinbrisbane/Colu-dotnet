using System;

namespace Colu.Client
{
    public class GetAddressRequest : Request, IRequest
    {
        public GetAddressRequest()
        {
            this.method = "hdwallet.getAddress";
            this.jsonrpc = "2.0";
        }
    }
}
