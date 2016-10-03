using Colu.Models;
using System;
using System.Threading.Tasks;

namespace Colu
{
    public interface IAddressClient : IDisposable
    {
        Task<Models.GetAddress.Response> GetAddressAsync(String id);

        Task<Models.GetAddressInfo.Response> GetAddressInfoAsync(String id);
    }
}
