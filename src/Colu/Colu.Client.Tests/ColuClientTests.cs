using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Colu.Client.Tests
{
    [TestClass]
    public class ColuClientTests
    {
        [TestMethod]
        public async Task Should_Get_HD_Address()
        {
            using (ColuClient client = new ColuClient("http://bitcoinaa3.cloudapp.net:8081"))
            {
                var response = await client.GetAddressAsync();
                Assert.IsFalse(String.IsNullOrEmpty(response.Address));
            }
        }

        [TestMethod]
        public async Task Should_Get_Asset_Holders()
        {
            using (ColuClient client = new ColuClient("http://bitcoinaa3.cloudapp.net:8081"))
            {
                var address = await client.GetAddressAsync();

                var stake = new GetStakeHoldersRequest()
                {
                    id = "1"
                };

                stake.Params.AssetId = "Ua9V5JgADia5zJdSnSTDDenKhPuTVc6RbeNmsJ";
                stake.Params.numConfirmations = "0";

                var acutal = await client.GetStakeHoldersAsync(stake);
            }
        }
    }
}
