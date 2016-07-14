using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colu.Client
{
    public interface IAddressClient : IDisposable
    {
        Task<GetAddressResponse> GetAddressAsync(String id);
    }
}
