using Colu.Client.Models;
using System;
using System.Threading.Tasks;

namespace Colu.Client
{
    public interface IAddressClient : IDisposable
    {
        Task<GetAddressResponse> GetAddressAsync(String id);
    }
}
