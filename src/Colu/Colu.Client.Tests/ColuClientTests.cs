using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Colu;
using System.Collections.Generic;

namespace ColuClient.Tests
{
    [TestClass]
    public class ColuClientTests
    {
        private const String HOST = "http://colunode.cloudapp.net"; //"http://192.168.0.12:8080";
        private const String USERNAME = "bitcoinbrisbane";
        private const String PASSWORD = "Test1234";

        private const String BITPOKER_ASSET_ID = "Ua72z6CSPuSWV2fN5Rs1T23m5s3qGL7oAW9wry"; //"Ua9V5JgADia5zJdSnSTDDenKhPuTVc6RbeNmsJ";

        //HD Addresses created with the private seed for testing
        private const String TESTNET_ADDRESS = "n1nNHbM9c7s88sYQEcK9kdYEthqiAah39k";
        //private const String TESTNET_ADDRESS_2 = "mtePqcTfyTfD8hGztZ4zHpqPBPQwjVdCna";
        //private const String TESTNET_ADDRESS_3 = "mhEeZWdMzXVLMzWBUHueij27h2smvaAdUc";

        private const String RANDOM_ADDRESS_TO_RECEIVE = "mvaHph557j63CyJxmEaJ8F38SC3cNetvaa";

        //Include seed to test
        private const String PRIVATE_SEED = "789c72ef27583c1a864bda1065ebea4fb723c44e2316723b4be8e2037edd769e";

        [TestMethod]
        public async Task Should_Get_Private_Seed()
        {
            using (Client client = new Client(HOST, USERNAME, PASSWORD))
            {
                var response = await client.GetPrivateSeed();
                Assert.IsFalse(String.IsNullOrEmpty(response.Result));
                
                //Assert the seeds are the same so users can unit test.
                Assert.AreEqual(response.Result, PRIVATE_SEED);
            }
        }

        [TestMethod]
        public async Task Should_Get_HD_Address()
        {
            using (IAddressClient client = new Client(HOST, USERNAME, PASSWORD))
            {
                String id = Guid.NewGuid().ToString();
                var response = await client.GetAddressAsync(id);

                Assert.IsFalse(String.IsNullOrEmpty(response.Result));
                Assert.AreEqual(id, response.Id);

                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[2mn][1-9A-HJ-NP-Za-km-z]{26,35}");
                var match = regex.Match(response.Result);

                Assert.IsTrue(match.Success);
            }
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public async Task Should_Not_Get_HD_Address_With_Invalid_Credentials()
        {
            using (IAddressClient client = new Client(HOST, USERNAME, "InvalidPassword"))
            {
                String id = Guid.NewGuid().ToString();
                var response = await client.GetAddressAsync(id);

                Assert.IsFalse(String.IsNullOrEmpty(response.Result));
            }
        }

        [TestMethod]
        public async Task Should_Get_Asset_Holders()
        {
            using (Client client = new Client(HOST, USERNAME, PASSWORD))
            {
                var request = new Colu.Models.GetStakeHolders.Request()
                {
                    Id = Guid.NewGuid().ToString()
                };
                request.Params.AssetId = BITPOKER_ASSET_ID;
                request.Params.NumberConfirmations = 1;

                var actual = await client.GetStakeHoldersAsync(request);
                Assert.IsNotNull(actual);
                Assert.IsNotNull(actual.Result);
                Assert.AreEqual(BITPOKER_ASSET_ID, actual.Result.AssetId);
                Assert.IsTrue(actual.Result.Holders.Count > 0);
            }
        }

        [TestMethod, TestCategory("Issue")]
        public async Task Should_Issue_1000_Assets()
        {
            using (Client client = new Client(HOST))
            {
                var request = new Colu.Models.IssueAsset.Request()
                {
                    Id = Guid.NewGuid().ToString()
                };

                request.Param.Amount = 1000;
                request.Param.Divisibility = 0;
                request.Param.Reissueable = true;
                request.Param.IssueAddress = TESTNET_ADDRESS;

                var actual = await client.IssueAsync(request);
                Assert.IsNotNull(actual);
                Assert.IsNull(actual.Error);
            }
        }

        [TestMethod, TestCategory("Issue")]
        public async Task Should_Issue_Asset_With_Metadata()
        {
            using (Client client = new Client(HOST, USERNAME, PASSWORD))
            {
                var request = new Colu.Models.IssueAsset.Request()
                {
                    Id = Guid.NewGuid().ToString()
                };

                request.Param.Amount = 1000;
                request.Param.Divisibility = 0;
                request.Param.Reissueable = true;
                request.Param.IssueAddress = TESTNET_ADDRESS;

                request.Param.MetaData.AssetName = "General Fisheries Permit";
                request.Param.MetaData.Issuer = "Queensland Government";

                var actual = await client.IssueAsync(request);
                Assert.IsNotNull(actual);
            }
        }

        [TestMethod, TestCategory("Issue")]
        public async Task Should_Issue_Asset_With_Metadata_And_Image()
        {
            using (Client client = new Client(HOST, USERNAME, PASSWORD))
            {
                var request = new Colu.Models.IssueAsset.Request()
                {
                    Id = Guid.NewGuid().ToString()
                };

                request.Param.Amount = 10;
                request.Param.Divisibility = 0;
                request.Param.Reissueable = false;
                request.Param.IssueAddress = TESTNET_ADDRESS;

                request.Param.MetaData.AssetName = "General Fisheries Permit";
                request.Param.MetaData.Issuer = "Queensland Government";

                var iconUrl = new Colu.Models.IssueAsset.Url()
                {
                    Name = "icon",
                    MimeType = "image/png",
                    url = "https://blockchainpermits.azurewebsites.net/images/Fishing-Licence2.png"
                };
                request.Param.MetaData.Urls.Add(iconUrl);

                var actual = await client.IssueAsync(request);
                Assert.IsNotNull(actual);
            }
        }

        [TestMethod, TestCategory("Issue")]
        public async Task Should_Issue_Asset_With_Metadata_And_Verification()
        {
            using (Client client = new Client(HOST, USERNAME, PASSWORD))
            {
                var request = new Colu.Models.IssueAsset.Request()
                {
                    Id = Guid.NewGuid().ToString()
                };

                request.Param.Amount = 1;
                request.Param.Divisibility = 0;
                request.Param.Reissueable = true;
                request.Param.IssueAddress = TESTNET_ADDRESS;

                request.Param.MetaData.AssetName = "Test";
                //request.Param.MetaData.Verification = new Colu.Models.IssueAsset.Verification();
                //request.Param.MetaData.Verification.Domain = new Colu.Models.IssueAsset.Domain() { url = "https://www.bitpoker.io/assets.txt" };

                var actual = await client.IssueAsync(request);
                Assert.IsNotNull(actual);
            }
        }

        [TestMethod, TestCategory("Issue")]
        public async Task Should_Issue_Asset_With_Metadata_And_Rules()
        {
            using (Client client = new Client(HOST))
            {
                var request = new Colu.Models.IssueAsset.Request()
                {
                    Id = Guid.NewGuid().ToString()
                };

                request.Param.Rules = new Colu.Models.Rules(1);


                //TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
                //Int64 epoch = (Int64)t.TotalSeconds;
                //request.Param.Rules.Expiration.ValidUntil = 500000;

                request.Param.Amount = 10;
                request.Param.Divisibility = 0;
                request.Param.Reissueable = true;
                request.Param.IssueAddress = TESTNET_ADDRESS;
 
                request.Param.MetaData.AssetName = "General Fisheries Permit";
                request.Param.MetaData.Issuer = "Queensland Government";

                var iconUrl = new Colu.Models.IssueAsset.Url()
                {
                    Name = "icon",
                    MimeType = "image/png",
                    url = "https://blockchainpermits.azurewebsites.net/images/Fishing-Licence2.png"
                };

                request.Param.MetaData.Urls.Add(iconUrl);

                

                var actual = await client.IssueAsync(request);
                Assert.IsNotNull(actual);
            }
        }

        [TestMethod, TestCategory("Issue")]
        public async Task Should_Issue_And_Transfer_Asset()
        {
            using (Client client = new Client(HOST))
            {
                var request = new Colu.Models.IssueAsset.Request()
                {
                    Id = Guid.NewGuid().ToString()
                };

                request.Param.MetaData.AssetName = "Unit test";
                request.Param.Amount = 100;
                request.Param.Divisibility = 0;
                request.Param.Reissueable = true;
                request.Param.IssueAddress = TESTNET_ADDRESS;

                request.Param.Transfer = new List<Colu.Models.To>(1);
                request.Param.Transfer.Add(new Colu.Models.To() { Address = RANDOM_ADDRESS_TO_RECEIVE, Amount = 1 });

                var actual = await client.IssueAsync(request);
                Assert.IsNotNull(actual);
            }
        }

        [TestMethod]
        public async Task Should_Send_Asset()
        {
            const String TESTNET_ASSET_ID = "La7xWL4k6mr5h5Yi8p3YmN3oxaKPn7x8Ub3YUG";
            const String TESTNET_ADDRESS = "mftCzxjSGWRRXh5QDKaTpsCXWmGNEtHX3S";

            using (Client client = new Client(HOST, USERNAME, PASSWORD))
            {
                var request = new Colu.Models.SendAsset.Request()
                {
                    Id = Guid.NewGuid().ToString()
                };

                request.param.From.Add(TESTNET_ADDRESS);

                request.param.To.Add(new Colu.Models.To()
                {
                    Address = "mkK8GmN4q5TnPEZkJmY6LVa5i5kimxwNXB",
                    Amount = 1,
                    AssetId = TESTNET_ASSET_ID
                });

                var actual = await client.SendAssetAsync(request);
                Assert.IsNotNull(actual);
                Assert.IsNotNull(actual.Result);
                Assert.IsNotNull(actual.Result.TxId);
            }
        }

        [TestMethod, TestCategory("Exceptions")]
        public async Task Should_Raise_Key_Not_Found_Error()
        {
            const String TESTNET_ASSET_ID = "La7xWL4k6mr5h5Yi8p3YmN3oxaKPn7x8Ub3YUG";
            const String TESTNET_ADDRESS = "mwcDHAuNMDkXhANEByVfJmKKTZ4G6V3tvh";

            using (Client client = new Client(HOST, USERNAME, PASSWORD))
            {
                var request = new Colu.Models.SendAsset.Request()
                {
                    Id = Guid.NewGuid().ToString()
                };

                request.param.From.Add(TESTNET_ADDRESS);

                request.param.To.Add(new Colu.Models.To()
                {
                    Address = "mkK8GmN4q5TnPEZkJmY6LVa5i5kimxwNXB",
                    Amount = 1,
                    AssetId = TESTNET_ASSET_ID
                });

                var actual = await client.SendAssetAsync(request);
                Assert.IsNotNull(actual);
                Assert.IsNotNull(actual.Error);
                Assert.AreEqual("Address mwcDHAuNMDkXhANEByVfJmKKTZ4G6V3tvh privateKey not found.", actual.Error.Data);
            }
        }

        [TestMethod]
        public async Task Should_Send_Asset_via_Phone()
        {
            //fishing permit on mainnet
            const String ASSET_ID = "LaAXAraoJfPYRovBtR4DctaLsxiHEcAuBwMWGb";

            using (Client client = new Client(HOST))
            {
                var request = new Colu.Models.SendAsset.Request()
                {
                    Id = Guid.NewGuid().ToString()
                };

                request.param.From.Add("1DNjKtYCjrJJgQCkzYqSfrcd8ahzBZXPzR");
                request.param.To.Add(new Colu.Models.To() { PhoneNumber = "61407928417", Amount = 1, AssetId = ASSET_ID });

                var actual = await client.SendAssetAsync(request);
                Assert.IsNotNull(actual);
                Assert.IsNotNull(actual.Result);
                Assert.IsNotNull(actual.Result.TxId);
            }
        }

        [TestMethod]
        public async Task Should_Get_Address_Info()
        {
            using (Client client = new Client(HOST, USERNAME, PASSWORD))
            {
                var actual = await client.GetAddressInfoAsync(TESTNET_ADDRESS);
                Assert.IsNotNull(actual);
                Assert.AreEqual(TESTNET_ADDRESS, actual.Result.Address);
            }
        }

        [TestMethod]
        public async Task Should_Get_Asset_Data()
        {
            using (Client client = new Client(HOST, USERNAME, PASSWORD))
            {
                var actual = await client.GetAssetDataAsync(BITPOKER_ASSET_ID);
                Assert.IsNotNull(actual);
                Assert.AreEqual(BITPOKER_ASSET_ID, actual.Result.AssetId);
                //Assert.AreEqual(1000000000, actual.Result.AssetTotalAmount);
            }
        }

        [TestMethod]
        public async Task Should_Get_Assets()
        {
            using (Client client = new Client(HOST, USERNAME, PASSWORD))
            {
                var actual = await client.GetAssetsAsync();
                Assert.IsNotNull(actual);
            }
        }

        [TestMethod]
        public async Task Should_Burn_Assets()
        {
            using (Client client = new Client(HOST, USERNAME, PASSWORD))
            {
                Colu.Models.BurnAsset.Request request = new Colu.Models.BurnAsset.Request();
                request.Param.Burn.Add(new Colu.Models.BurnAsset.Burn() { Amount = 1, AssetId = "Ua56JfLDxtaHoXWeNYmwPyi3QzuJkFW1H3wjXy" });
                var actual = await client.BurnAssetAsync(request);
                Assert.IsNotNull(actual);
            }
        }
    }
}