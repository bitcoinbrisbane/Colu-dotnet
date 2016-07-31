using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colu.Models.GetPrivateSeed
{
    public class Request : Colu.Models.Request
    {
        public Request()
        {
            this.Method = "hdwallet.getPrivateSeed";
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
