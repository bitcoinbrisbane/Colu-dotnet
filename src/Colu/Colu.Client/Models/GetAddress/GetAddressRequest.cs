using System;

namespace Colu.Client.Models
{
    public class GetAddressRequest : Request, IRequest
    {
        public GetAddressRequest()
        {
            this.Method = "hdwallet.getAddress";
        }
    }
}
