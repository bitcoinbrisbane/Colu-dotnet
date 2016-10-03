using System;
using System.Threading.Tasks;

namespace Colu
{
    public interface IAssetClient : IDisposable
    {
        Task<Models.GetAssets.Response> GetAssetsAsync();
    }
}
