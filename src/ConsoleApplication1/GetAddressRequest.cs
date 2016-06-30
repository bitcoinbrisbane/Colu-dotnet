using System;

namespace ConsoleApplication1
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
