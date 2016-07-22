using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Colu;

namespace ColuClient.Tests
{
    [TestClass]
    public class ColuClientTests
    {
        private const String HOST = "http://bitcoinaa3.cloudapp.net:8081";
        //private const String HOST = "http://autarky.cloudapp.net:8081";

        [TestMethod]
        public async Task Should_Get_HD_Address()
        {
            using (IAddressClient client = new Client(HOST))
            {
                var response = await client.GetAddressAsync("1");

                Assert.IsFalse(String.IsNullOrEmpty(response.Address));
                Assert.AreEqual("1", response.Id);
            }
        }

        [TestMethod]
        public async Task Should_Get_Asset_Holders()
        {
            const String BITPOKER_ASSET_ID = "Ua9V5JgADia5zJdSnSTDDenKhPuTVc6RbeNmsJ";

            using (Client client = new Client(HOST))
            {
                var request = new Colu.Models.GetStakeHolders.Request()
                {
                    Id = Guid.NewGuid().ToString()
                };
                request.Params.AssetId = BITPOKER_ASSET_ID;
                request.Params.NumberConfirmations = 1;

                var acutal = await client.GetStakeHoldersAsync(request);
                Assert.IsNotNull(acutal);
                Assert.IsNotNull(acutal.Result);
                Assert.AreEqual(BITPOKER_ASSET_ID, acutal.Result.AssetId);
                Assert.IsTrue(acutal.Result.Holders.Count > 0);
            }
        }

        [TestMethod]
        public async Task Should_Issue_Asset()
        {
            using (Client client = new Client(HOST))
            {
                var request = new Colu.Models.IssueAsset.Request()
                {
                    Id = "1"
                };

                request.Param.Amount = 1000;
                request.Param.Divisibility = 0;
                request.Param.Reissueable = false;
                //request.Param.IssueAddress = "1MbLLmDNc3UmZcvDb2Qv128aTdtPHYiP5N";
                request.Param.IssueAddress = "mftCzxjSGWRRXh5QDKaTpsCXWmGNEtHX3S";

                //IS TO REQUIRED?
                //request.Param.IssueAddress = "mkNCMkfqKJaR5Ex1gjk9rKFqePk95kDVaC";
                //request.to.Add(new Models.To() { PhoneNumber = "61407928417", Amount = 1 });

                //request.Params.AssetId = "Ua9V5JgADia5zJdSnSTDDenKhPuTVc6RbeNmsJ";
                //request.Params.numConfirmations = "0";

                var acutal = await client.IssueAsync(request);
                Assert.IsNotNull(acutal);
            }
        }

        [TestMethod]
        public async Task Should_Issue_Asset_With_Metadata()
        {
            using (Client client = new Client(HOST))
            {
                var request = new Colu.Models.IssueAsset.Request()
                {
                    Id = Guid.NewGuid().ToString()
                };

                request.Param.Amount = 100;
                request.Param.Divisibility = 0;
                request.Param.Reissueable = false;
                request.Param.IssueAddress = "1DNjKtYCjrJJgQCkzYqSfrcd8ahzBZXPzR";

                request.Param.MetaData.AssetName = "General Fisheries Permit";
                request.Param.MetaData.Issuer = "Queensland Government";

                var acutal = await client.IssueAsync(request);
                Assert.IsNotNull(acutal);
            }
        }

        [TestMethod]
        public async Task Should_Issue_Asset_With_Metadata_And_Image()
        {
            using (Client client = new Client(HOST))
            {
                var request = new Colu.Models.IssueAsset.Request()
                {
                    Id = Guid.NewGuid().ToString()
                };

                request.Param.Amount = 100;
                request.Param.Divisibility = 0;
                request.Param.Reissueable = false;
                request.Param.IssueAddress = "1DNjKtYCjrJJgQCkzYqSfrcd8ahzBZXPzR";

                request.Param.MetaData.AssetName = "General Fisheries Permit";
                request.Param.MetaData.Issuer = "Queensland Government";

                var acutal = await client.IssueAsync(request);
                Assert.IsNotNull(acutal);
            }
        }

        [TestMethod]
        public async Task Should_Issue_And_Transfer_Asset()
        {
            using (Client client = new Client(HOST))
            {
                var request = new Colu.Models.IssueAsset.Request()
                {
                    Id = "1"
                };

                request.Param.Amount = 10;
                request.Param.Divisibility = 0;
                request.Param.Reissueable = false;
                //request.Param.IssueAddress = "1MbLLmDNc3UmZcvDb2Qv128aTdtPHYiP5N";
                request.Param.IssueAddress = "mftCzxjSGWRRXh5QDKaTpsCXWmGNEtHX3S";

                //IS TO REQUIRED?
                //request.Param.IssueAddress = "mkNCMkfqKJaR5Ex1gjk9rKFqePk95kDVaC";
                //mjgNvJhN6g8rkANZZKqpPQDNtrMux5LvT9 random bitaddress address
                request.Transfer.Add(new Colu.Models.To() { address = "mjgNvJhN6g8rkANZZKqpPQDNtrMux5LvT9", Amount = 1 });

                //request.Params.AssetId = "Ua9V5JgADia5zJdSnSTDDenKhPuTVc6RbeNmsJ";
                //request.Params.numConfirmations = "0";

                var acutal = await client.IssueAsync(request);
                Assert.IsNotNull(acutal);
            }
        }

        [TestMethod]
        public async Task Should_Send_Asset()
        {
            //TEST NET ADDRESS TO RECEIVE
            //91i8uCM3dbdCQfxFnkZURTkvsf5vS3rPu7MPDQ3c3LgUBmi26Y6
            //mkK8GmN4q5TnPEZkJmY6LVa5i5kimxwNXB

            //const String BITPOKER_ISSUANCE_ADDRESS = "1JDMS9JbAfnpi8FD24ksQMjS9rRCLLpScM";
            //const String BITPOKER_ASSET_ID = "Ua9V5JgADia5zJdSnSTDDenKhPuTVc6RbeNmsJ";

            const String ASSET_ID = "La6Dvxak74TyB77RxHQt1ciFqZAESXMYHHBKYx";
            const String TESTNET_ASSET_ID = "La7xWL4k6mr5h5Yi8p3YmN3oxaKPn7x8Ub3YUG";

            const String TEST_NET_ADDRESS = "mftCzxjSGWRRXh5QDKaTpsCXWmGNEtHX3S";

            using (Client client = new Client(HOST))
            {
                var request = new Colu.Models.SendAsset.Request()
                {
                    Id = Guid.NewGuid().ToString()
                };

                //request.param.from.Add("1MbLLmDNc3UmZcvDb2Qv128aTdtPHYiP5N");
                request.param.from.Add(TEST_NET_ADDRESS);

                //request.param.to.Add(new Models.To() { PhoneNumber = "61407928417", Amount = 1, AssetId = ASSET_ID });
                request.param.to.Add(new Colu.Models.To() { address= "mkK8GmN4q5TnPEZkJmY6LVa5i5kimxwNXB", Amount = 1, AssetId = TESTNET_ASSET_ID });
                var acutal = await client.SendAssetAsync(request);
                Assert.IsNotNull(acutal);
                Assert.IsNotNull(acutal.Result);
                Assert.IsNotNull(acutal.Result.TxId);
            }
        }

        [TestMethod]
        public async Task Should_Send_Asset_via_Phone()
        {
            //fishing permit
            const String ASSET_ID = "LaAXAraoJfPYRovBtR4DctaLsxiHEcAuBwMWGb";

            using (Client client = new Client(HOST))
            {
                var request = new Colu.Models.SendAsset.Request()
                {
                    Id = Guid.NewGuid().ToString()
                };

                request.param.from.Add("1DNjKtYCjrJJgQCkzYqSfrcd8ahzBZXPzR");
                request.param.to.Add(new Colu.Models.To() { PhoneNumber = "61407928417", Amount = 1, AssetId = ASSET_ID });

                var acutal = await client.SendAssetAsync(request);
                Assert.IsNotNull(acutal);
                Assert.IsNotNull(acutal.Result);
                Assert.IsNotNull(acutal.Result.TxId);
            }
        }

        [TestMethod, TestCategory("Autarky")]
        public async Task Should_Send_Asset_via_Autarky()
        {
            const String ASSET_ID = "Ua5QZpRpQLg5YsHY4h9QCCbbo6Z5HJBx6CUJvn";
            //const String ADDRESS = "mzVuTFivD1bxTNWmYoY5NSB9VY4k1zhKDs";
            const String FROM_ADDRESS = "mkoffnrkGEMKvswwWXR2LWyXFan68B1UGv";
            const String TO_ADDRESS = "mvBea3GT2B7iUxESsDioTVcmP492bNzUmf"; //mkXE4k1JqY3fYQ6TJJVGyRze9dM7dE53PD

            using (Client client = new Client("http://autarky.cloudapp.net:8081"))
            {
                var request = new Colu.Models.SendAsset.Request()
                {
                    Id = Guid.NewGuid().ToString()
                };

                request.param.from.Add(FROM_ADDRESS);

                request.param.to.Add(new Colu.Models.To() { address = TO_ADDRESS, Amount = 100, AssetId = ASSET_ID });
                var acutal = await client.SendAssetAsync(request);
                Assert.IsNotNull(acutal);
                Assert.IsNotNull(acutal.Result.TxId);
            }
        }

        [TestMethod, TestCategory("Autarky")]
        public async Task Should_Issue_Autarky_Asset()
        {
            using (Client client = new Client("http://autarky.cloudapp.net:8081"))
            {
                var request = new Colu.Models.IssueAsset.Request()
                {
                    Id = "1"
                };

                request.Param.Amount = 1000;
                request.Param.Divisibility = 2;
                request.Param.Reissueable = true;
                request.Param.IssueAddress = "mzVuTFivD1bxTNWmYoY5NSB9VY4k1zhKDs";

                var acutal = await client.IssueAsync(request);
                Assert.IsNotNull(acutal);
            }
        }

        [TestMethod]
        public async Task Should_Get_Address_Info()
        {
            using (Client client = new Client("http://bitcoinaa3.cloudapp.net:8081"))
            {
                //mkXE4k1JqY3fYQ6TJJVGyRze9dM7dE53PD
                //1DNjKtYCjrJJgQCkzYqSfrcd8ahzBZXPzR - Permits
                //mkK8GmN4q5TnPEZkJmY6LVa5i5kimxwNXB - Autarky
                var acutal = await client.GetAddressInfoAsync("1DNjKtYCjrJJgQCkzYqSfrcd8ahzBZXPzR");
                Assert.IsNotNull(acutal);
            }
        }
    }
}