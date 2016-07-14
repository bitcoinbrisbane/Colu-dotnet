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
                var request = new GetStakeHoldersRequest()
                {
                    id = "1"
                };

                request.Params.AssetId = "Ua9V5JgADia5zJdSnSTDDenKhPuTVc6RbeNmsJ";
                request.Params.NumberConfirmations = "0";

                var acutal = await client.GetStakeHoldersAsync(request);
                Assert.IsNotNull(acutal);
                Assert.IsTrue(acutal.Length > 0);
            }
        }

        [TestMethod]
        public async Task Should_Issue_Asset()
        {
            using (ColuClient client = new ColuClient("http://bitcoinaa3.cloudapp.net:8081"))
            {
                var request = new Models.IssueAssetRequest()
                {
                    id = "1"
                };

                request.Param.Amount = 1;
                request.Param.Divisibility = 0;
                request.Param.Reissueable = false;
                request.Param.IssueAddress = "15rF4harWH9AJ8UPyAmn2Q3WnQ9SD9tdsX";

                request.to.Add(new To() { PhoneNumber = 61407928417, Amount = 1 });

                //request.Params.AssetId = "Ua9V5JgADia5zJdSnSTDDenKhPuTVc6RbeNmsJ";
                //request.Params.numConfirmations = "0";

                var acutal = await client.IssueAsync(request);
                Assert.IsNotNull(acutal);
            }
        }
    }
}
