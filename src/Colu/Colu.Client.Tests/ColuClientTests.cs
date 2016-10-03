using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Colu;

namespace ColuClient.Tests
{
    [TestClass]
    public class ColuClientTests
    {
        private const String MAINNET_HOST = "http://bitcoinaa3.cloudapp.net:8081";
        private const String TESTNET_HOST = "http://bitcoinbrisbane.cloudapp.net:8081";
        private const String HOME_HOST = "http://127.0.0.1:8080";

        private const String BITPOKER_ASSET_ID = "Ua9V5JgADia5zJdSnSTDDenKhPuTVc6RbeNmsJ";
        
        private const String TESTNET_ADDRESS = "mq7Q4GWWWkedjxsDTQJznwWgBMm5s5CnEE";
        private const String TESTNET_ADDRESS_2 = "mtePqcTfyTfD8hGztZ4zHpqPBPQwjVdCna";
        private const String TESTNET_ADDRESS_3 = "mhEeZWdMzXVLMzWBUHueij27h2smvaAdUc";

        private String _address;

        //[TestInitialize]
        //public void Setup()
        //{
        //    using (IAddressClient client = new Client(TESTNET_HOST))
        //    {
        //        String id = Guid.NewGuid().ToString();
        //        var response = client.GetAddressAsync(id).Result;

        //        _address = response.Address;
        //    }
        //}

        [TestMethod]
        public async Task Should_Get_Private_Seed()
        {
            using (Client client = new Client(HOME_HOST))
            {
                var response = await client.GetPrivateSeed();
                Assert.IsFalse(String.IsNullOrEmpty(response.Result));
            }
        }

        [TestMethod]
        public async Task Should_Get_HD_Address()
        {
            using (IAddressClient client = new Client(TESTNET_HOST))
            {
                String id = Guid.NewGuid().ToString();
                var response = await client.GetAddressAsync(id);

                Assert.IsFalse(String.IsNullOrEmpty(response.Address));
                Assert.AreEqual(id, response.Id);

                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[2mn][1-9A-HJ-NP-Za-km-z]{26,35}");
                var match = regex.Match(response.Address);

                Assert.IsTrue(match.Success);
            }
        }

        [TestMethod]
        public async Task Should_Get_HD_Address_With_Credentials()
        {
            using (IAddressClient client = new Client("http://192.168.0.12:8080", "bitcoinbrisbane", "Test1234"))
            {
                String id = Guid.NewGuid().ToString();
                var response = await client.GetAddressAsync(id);

                Assert.IsFalse(String.IsNullOrEmpty(response.Address));
                Assert.AreEqual(id, response.Id);

                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[2mn][1-9A-HJ-NP-Za-km-z]{26,35}");
                var match = regex.Match(response.Address);

                Assert.IsTrue(match.Success);
            }
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public async Task Should_Not_Get_HD_Address_With_Invalid_Credentials()
        {
            using (IAddressClient client = new Client("http://192.168.0.12:8080", "bitcoinbrisbane", "InvalidPassword"))
            {
                String id = Guid.NewGuid().ToString();
                var response = await client.GetAddressAsync(id);

                Assert.IsFalse(String.IsNullOrEmpty(response.Address));
            }
        }

        [TestMethod]
        public async Task Should_Get_Asset_Holders()
        {
            using (Client client = new Client(MAINNET_HOST))
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

        [TestMethod]
        public async Task Should_Issue_1000_Asset()
        {
            using (Client client = new Client(TESTNET_HOST))
            {
                var request = new Colu.Models.IssueAsset.Request()
                {
                    Id = Guid.NewGuid().ToString()
                };

                request.Param.Amount = 1000;
                request.Param.Divisibility = 0;
                request.Param.Reissueable = false;
                request.Param.IssueAddress = TESTNET_ADDRESS;

                var actual = await client.IssueAsync(request);
                Assert.IsNotNull(actual);
            }
        }

        [TestMethod, TestCategory("Testnet")]
        public async Task Should_Issue_Asset_With_Metadata()
        {
            using (Client client = new Client(TESTNET_HOST))
            {
                var request = new Colu.Models.IssueAsset.Request()
                {
                    Id = Guid.NewGuid().ToString()
                };

                request.Param.Amount = 1000;
                request.Param.Divisibility = 0;
                request.Param.Reissueable = false;
                request.Param.IssueAddress = TESTNET_ADDRESS_2;

                request.Param.MetaData.AssetName = "General Fisheries Permit";
                request.Param.MetaData.Issuer = "Queensland Government";

                var actual = await client.IssueAsync(request);
                Assert.IsNotNull(actual);
            }
        }

        [TestMethod]
        public async Task Should_Issue_Asset_With_Metadata_And_Image()
        {
            using (Client client = new Client(TESTNET_HOST))
            {
                var request = new Colu.Models.IssueAsset.Request()
                {
                    Id = Guid.NewGuid().ToString()
                };

                request.Param.Amount = 10;
                request.Param.Divisibility = 0;
                request.Param.Reissueable = false;
                request.Param.IssueAddress = TESTNET_ADDRESS_2;

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

        [TestMethod]
        public async Task Should_Issue_Asset_With_Metadata_And_Verification()
        {
            using (Client client = new Client(TESTNET_HOST))
            {
                var request = new Colu.Models.IssueAsset.Request()
                {
                    Id = Guid.NewGuid().ToString()
                };

                request.Param.Amount = 1;
                request.Param.Divisibility = 0;
                request.Param.Reissueable = true;
                request.Param.IssueAddress = "n3QVmkB9xQgxEgQVR8kGTzq2EHVyqqktwf";// "n3c8uGR9SPiWcPV3fYmLFDojaCH7P8TFgS";

                request.Param.MetaData.AssetName = "Test Bitpoker";
                //request.Param.MetaData.Verification = new Colu.Models.IssueAsset.Verification();
                //request.Param.MetaData.Verification.Domain = new Colu.Models.IssueAsset.Domain() { url = "https://www.bitpoker.io/assets.txt" };

                var actual = await client.IssueAsync(request);
                Assert.IsNotNull(actual);
            }
        }

        [TestMethod]
        public async Task Should_Issue_Asset_With_Metadata_And_Rules()
        {
            using (Client client = new Client(TESTNET_HOST))
            {
                var request = new Colu.Models.IssueAsset.Request()
                {
                    Id = Guid.NewGuid().ToString()
                };

                request.Rules = new Colu.Models.IssueAsset.Rules();
                request.Rules.Expiration = new Colu.Models.IssueAsset.Expiration();

                TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
                Int64 epoch = (Int64)t.TotalSeconds;
                request.Rules.Expiration.ValidUntil = epoch + 24 * 60 * 60;

                request.Param.Amount = 10;
                request.Param.Divisibility = 0;
                request.Param.Reissueable = true;
                request.Param.IssueAddress = _address;

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

        [TestMethod, Ignore]
        public async Task Should_Issue_And_Transfer_Asset()
        {
            using (Client client = new Client(TESTNET_HOST))
            {
                var request = new Colu.Models.IssueAsset.Request()
                {
                    Id = Guid.NewGuid().ToString()
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

                var actual = await client.IssueAsync(request);
                Assert.IsNotNull(actual);
            }
        }

        [TestMethod]
        public async Task Should_Send_Asset()
        {
            const String TESTNET_ASSET_ID = "La7xWL4k6mr5h5Yi8p3YmN3oxaKPn7x8Ub3YUG";
            const String TEST_NET_ADDRESS = "mftCzxjSGWRRXh5QDKaTpsCXWmGNEtHX3S";

            using (Client client = new Client(TESTNET_HOST))
            {
                var request = new Colu.Models.SendAsset.Request()
                {
                    Id = Guid.NewGuid().ToString()
                };

                request.param.From.Add(TEST_NET_ADDRESS);

                request.param.To.Add(new Colu.Models.To()
                {
                    address = "mkK8GmN4q5TnPEZkJmY6LVa5i5kimxwNXB",
                    Amount = 1,
                    AssetId = TESTNET_ASSET_ID
                });
                var actual = await client.SendAssetAsync(request);
                Assert.IsNotNull(actual);
                Assert.IsNotNull(actual.Result);
                Assert.IsNotNull(actual.Result.TxId);
            }
        }

        [TestMethod]
        public async Task Should_Send_Asset_via_Phone()
        {
            //fishing permit
            const String ASSET_ID = "LaAXAraoJfPYRovBtR4DctaLsxiHEcAuBwMWGb";

            using (Client client = new Client(TESTNET_HOST))
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
            using (Client client = new Client("https://192.168.0.12:443"))
            {
                var actual = await client.GetAddressInfoAsync(TESTNET_ADDRESS);
                Assert.IsNotNull(actual);
                Assert.AreEqual(TESTNET_ADDRESS, actual.Result.Address);
            }
        }

        [TestMethod]
        public async Task Should_Get_Asset_Data()
        {
            using (Client client = new Client(MAINNET_HOST))
            {
                var actual = await client.GetAssetDataAsync(BITPOKER_ASSET_ID);
                Assert.IsNotNull(actual);
                Assert.AreEqual(BITPOKER_ASSET_ID, actual.Result.AssetId);
                Assert.AreEqual(1000000000, actual.Result.AssetTotalAmount);
            }
        }

        [TestMethod]
        public async Task Should_Get_Assets()
        {
            using (Client client = new Client(MAINNET_HOST))
            {
                var actual = await client.GetAssetsAsync();
                Assert.IsNotNull(actual);
            }
        }
    }
}