using Colu.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Colu.Client
{
    public class ColuClient : IDisposable, IAddressClient
    {
        private readonly String _host;
        private readonly HttpClient _httpClient;

        private const String MEDIA_TYPE = "application/json";

        public ColuClient(String host)
        {
            _httpClient = new HttpClient();
            _host = host;
        }

        public ColuClient(String host, String username, String password)
        {
            _httpClient = new HttpClient();
            _host = host;
        }

        public async Task<GetAddressResponse> GetAddressAsync(String id)
        {
            GetAddressRequest request = new GetAddressRequest() { Id = id };
            String json = JsonConvert.SerializeObject(request);
            StringContent requestContent = new StringContent(json, Encoding.UTF8, MEDIA_TYPE);
            String url = String.Format("{0}", _host);

            String content = await Get(requestContent, url);
            return JsonConvert.DeserializeObject<GetAddressResponse>(content);
        }

        public async Task<GetAddressResponse> GetAddressAsync(GetAddressRequest request)
        {
            String json = JsonConvert.SerializeObject(request);
            StringContent requestContent = new StringContent(json, Encoding.UTF8, MEDIA_TYPE);
            String url = String.Format("{0}", _host);

            String content = await Get(requestContent, url);
            return JsonConvert.DeserializeObject<GetAddressResponse>(content);
        }

        public async Task<String> GetStakeHoldersAsync(GetStakeHoldersRequest request)
        {
            String json = JsonConvert.SerializeObject(request);
            StringContent requestContent = new StringContent(json, Encoding.UTF8, MEDIA_TYPE);
            String url = String.Format("{0}", _host);

            return await Get(requestContent, url);
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