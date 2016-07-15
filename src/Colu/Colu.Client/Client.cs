
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
            _httpClient = new HttpClient();
            _host = host;
        }

        public Client(String host, String username, String password)
        {
            _httpClient = new HttpClient();
            _host = host;
        }

        public async Task<Colu.Models.GetAddress.Response> GetAddressAsync(String id)
        {
            Colu.Models.GetAddress.Request request = new Colu.Models.GetAddress.Request() { Id = id };
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

        public async Task<Models.GetStakeHolders.Response> GetStakeHoldersAsync(Models.GetStakeHolders.Request request)
        {
            String json = JsonConvert.SerializeObject(request);
            StringContent requestContent = new StringContent(json, Encoding.UTF8, MEDIA_TYPE);
            String url = String.Format("{0}", _host);

            String response = await Get(requestContent, url);
            return JsonConvert.DeserializeObject<Models.GetStakeHolders.Response>(response);
        }

        public async Task<String> IssueAsync(Models.IssueAsset.Request request)
        {
            String json = JsonConvert.SerializeObject(request);
            StringContent requestContent = new StringContent(json, Encoding.UTF8, MEDIA_TYPE);
            String url = String.Format("{0}", _host);

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

        public async Task<String> SendAssetAsync(Models.SendAsset.Request request)
        {
            String json = JsonConvert.SerializeObject(request);
            StringContent requestContent = new StringContent(json, Encoding.UTF8, MEDIA_TYPE);
            String url = String.Format("{0}", _host);

            return await Get(requestContent, url);
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