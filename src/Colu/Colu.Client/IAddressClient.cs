using Colu.Client.Models;
using System;
using System.Threading.Tasks;

namespace Colu.Client
{
    public interface IAddressClient : IDisposable
    {
        Task<Models.GetAddress.Response> GetAddressAsync(String id);
    }
}
