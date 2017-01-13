using System;
using System.Threading.Tasks;

namespace Colu
{
    public interface IIsuanceClient : IDisposable
    {
        Task<Models.IssueAsset.Response> IssueAsync(Models.IssueAsset.Request request);
    }
}
