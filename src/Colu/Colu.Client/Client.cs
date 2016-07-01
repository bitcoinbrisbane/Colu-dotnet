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
    public class ColuClient : IDisposable
    {
        private readonly String _host;
        private readonly HttpClient _httpClient;

        public ColuClient(String host)
        {
            _httpClient = new HttpClient();
            _host = host;
        }

        public async Task<String> GetStakeHoldersAsync(GetStakeHoldersRequest request)
        {
            String json = JsonConvert.SerializeObject(request);
            StringContent requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            String url = String.Format("{0}", _host);

            return await Get(requestContent, url);
        }

        public async Task<String> IssueAsync(SendRequest request)
        {
            String json = JsonConvert.SerializeObject(request);
            StringContent requestContent = new StringContent(json, Encoding.UTF8, "application/json");
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

        public async Task<String> GetAddressAsync(GetAddressRequest request)
        {
            String json = JsonConvert.SerializeObject(request);
            StringContent requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            String url = String.Format("{0}", _host);

            return await Get(requestContent, url);
        }

        public async Task<String> SendAssetAsync(SendAssetRequest request)
        {
            String json = JsonConvert.SerializeObject(request);
            StringContent requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            String url = String.Format("{0}", _host);

            return await Get(requestContent, url);
        }

        private async Task<string> Get(StringContent requestContent, string url)
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

        public async Task<String> GetAddressAsync()
        {
            Request request = new Request() { id = "1", method = "hdwallet.getAddress" };

            String json = JsonConvert.SerializeObject(request);
            StringContent requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            String url = String.Format("{0}", _host);

            return await Get(requestContent, url);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}

    public class MetaData
    {
        public String Decription { get; set; }

        public DateTime Expires { get; set; }
    }

    public class Transfer
    {
        //13r7hhidTLHo1tpu9aWxCvQx1FgKGbsJPv
        //public string address { get; set; }

        public Int32 amount { get; set; }
    }
    

