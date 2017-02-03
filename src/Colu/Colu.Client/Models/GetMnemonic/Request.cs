using System;

namespace Colu.Models.GetMnemonic
{
    public class Request : Colu.Models.Request
    {
        public Request()
        {
            this.Method = "hdwallet.getMnemonic";
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
