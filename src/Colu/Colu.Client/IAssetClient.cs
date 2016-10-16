using System;
using System.Threading.Tasks;

namespace Colu
{
    public interface IAssetClient : IDisposable
    {
        Task<Models.GetAssets.Response> GetAssetsAsync();

        Task<Models.GetAssetData.Response> GetAssetDataAsync(String assetId, Int32 numberOfConfirmations = 0);
    }
}