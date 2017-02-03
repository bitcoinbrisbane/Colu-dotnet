using System;
using System.Threading.Tasks;

namespace Colu
{
    public interface ISecurityClient : IDisposable
    {
        Task<Models.GetPrivateSeed.Response> GetPrivateSeedAsync();

        Task<Models.GetMnemonic.Response> GetMnemonicAsync();
    }
}
