
using Colu.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Colu
{
    public class Client : IDisposable, IAddressClient
    {
        private readonly String _host;
        private readonly HttpClient _httpClient;

        private const String MEDIA_TYPE = "application/json";

        public Client(String host)
        {
            _httpClient = new HttpClient() { Timeout = new TimeSpan(0, 0, 10) };
            _host = host;
        }

        public Client(String host, String username, String password)
        {
            _httpClient = new HttpClient();
            _host = host;
        }

        public async Task<Models.GetPrivateSeed.Response> GetPrivateSeed()
        {
            Models.GetPrivateSeed.Request request = new Models.GetPrivateSeed.Request();
            String json = JsonConvert.SerializeObject(request);
            StringContent requestContent = new StringContent(json, Encoding.UTF8, MEDIA_TYPE);
            String url = String.Format("{0}", _host);

            String content = await Get(requestContent, url);
            return JsonConvert.DeserializeObject<Models.GetPrivateSeed.Response>(content);
        }

        /// <summary>
        /// Get a HD address
        /// </summary>
        /// <param name="id">Request id</param>
        /// <returns></returns>
        public async Task<Colu.Models.GetAddress.Response> GetAddressAsync(String id)
        {
            Models.GetAddress.Request request = new Models.GetAddress.Request() { Id = id };
            String json = JsonConvert.SerializeObject(request);
            StringContent requestContent = new StringContent(json, Encoding.UTF8, MEDIA_TYPE);
            String url = String.Format("{0}", _host);

            String content = await Get(requestContent, url);
            return JsonConvert.DeserializeObject<Models.GetAddress.Response>(content);
        }

        public async Task<Models.GetAddress.Response> GetAddressAsync(Models.GetAddress.Request request)
        {
            String json = JsonConvert.SerializeObject(request);
            StringContent requestContent = new StringContent(json, Encoding.UTF8, MEDIA_TYPE);
            String url = String.Format("{0}", _host);

            String response = await Get(requestContent, url);
            return JsonConvert.DeserializeObject<Models.GetAddress.Response>(response);
        }

        public async Task<Decimal> GetAddressBalanceAsync(String id, String bitcoinAddress, String assetId, Int32 numberOfConfirmations = 0)
        {
            var addressInfo = await GetAddressInfoAsync(bitcoinAddress);

            IEnumerable<Asset> assets = addressInfo.Result.Utxos.SelectMany(u => u.Assets).Where(u => u.AssetId == assetId);
            var total = assets.Sum(a => a.Amount);

            return total;
        }

        public async Task<Models.GetAddressInfo.Response> GetAddressInfoAsync(String bitcoinAddress)
        {
            Models.GetAddressInfo.Request request = new Models.GetAddressInfo.Request() { Id = Guid.NewGuid().ToString() };
            request.Params.Address = bitcoinAddress;

            String json = JsonConvert.SerializeObject(request);
            StringContent requestContent = new StringContent(json, Encoding.UTF8, MEDIA_TYPE);
            String url = String.Format("{0}", _host);

            String content = await Get(requestContent, url);
            return JsonConvert.DeserializeObject<Models.GetAddressInfo.Response> (content);
        }

        //public async Task<Models.GetAddress.Response> GetAddressAsync(Models.GetAddress.Request request)
        //{
        //    String json = JsonConvert.SerializeObject(request);
        //    StringContent requestContent = new StringContent(json, Encoding.UTF8, MEDIA_TYPE);
        //    String url = String.Format("{0}", _host);

        //    String response = await Get(requestContent, url);
        //    return JsonConvert.DeserializeObject<Models.GetAddress.Response>(response);
        //}

        public async Task<Models.GetAssetData.Response> GetAssetDataAsync(String assetId, Int32 numberOfConfirmations = 0)
        {
            Models.GetAssetData.Request request = new Models.GetAssetData.Request()
            {
                Id = Guid.NewGuid().ToString()
            };
            request.Params.AssetId = assetId;

            String json = JsonConvert.SerializeObject(request);
            StringContent requestContent = new StringContent(json, Encoding.UTF8, MEDIA_TYPE);
            String url = String.Format("{0}", _host);

            String content = await Get(requestContent, url);
            return JsonConvert.DeserializeObject<Models.GetAssetData.Response>(content);
        }

        public async Task<Models.GetStakeHolders.Response> GetStakeHoldersAsync(String assetId, Int32 numberOfConfirmations)
        {
            var request = new Colu.Models.GetStakeHolders.Request()
            {
                Id = Guid.NewGuid().ToString()
            };
            request.Params.AssetId = assetId;
            request.Params.NumberConfirmations = numberOfConfirmations;

            String json = JsonConvert.SerializeObject(request);
            StringContent requestContent = new StringContent(json, Encoding.UTF8, MEDIA_TYPE);
            String url = String.Format("{0}", _host);

            String response = await Get(requestContent, url);
            return JsonConvert.DeserializeObject<Models.GetStakeHolders.Response>(response);
        }

        [Obsolete]
        public async Task<Models.GetStakeHolders.Response> GetStakeHoldersAsync(Models.GetStakeHolders.Request request)
        {
            String json = JsonConvert.SerializeObject(request);
            StringContent requestContent = new StringContent(json, Encoding.UTF8, MEDIA_TYPE);
            String url = String.Format("{0}", _host);

            String response = await Get(requestContent, url);
            return JsonConvert.DeserializeObject<Models.GetStakeHolders.Response>(response);
        }

        public async Task<Models.IssueAsset.Response> IssueAsync(Models.IssueAsset.Request request)
        {
            String json = JsonConvert.SerializeObject(request);
            StringContent requestContent = new StringContent(json, Encoding.UTF8, MEDIA_TYPE);
            String url = String.Format("{0}", _host);

            using (HttpResponseMessage responseMessage = await _httpClient.PostAsync(url, requestContent))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    String responseContent = await responseMessage.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Models.IssueAsset.Response>(responseContent);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public async Task<Models.SendAsset.Response> SendAssetAsync(Models.SendAsset.Request request)
        {
            String json = JsonConvert.SerializeObject(request);
            StringContent requestContent = new StringContent(json, Encoding.UTF8, MEDIA_TYPE);
            String url = String.Format("{0}", _host);

            String response = await Get(requestContent, url);
            return JsonConvert.DeserializeObject<Models.SendAsset.Response>(response);
        }

        private async Task<String> Get(StringContent requestContent, String url)
        {
            using (HttpResponseMessage responseMessage = await _httpClient.PostAsync(url, requestContent))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    String responseContent = await responseMessage.Content.ReadAsStringAsync();
                    //Models.User.UpdateUserResponse response = JsonConvert.DeserializeObject<Models.User.UpdateUserResponse>(responseContent);

                    return responseContent;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}