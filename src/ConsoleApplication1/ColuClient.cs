using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class ColuClient : IDisposable
    {
        private readonly String _apiUrl = "http://bitcoinaa3.cloudapp.net:8081";
        private readonly HttpClient _httpClient;

        public ColuClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<String> IssueAsync(SendRequest request)
        {
            String json = JsonConvert.SerializeObject(request);
            StringContent requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            String url = String.Format("{0}", _apiUrl);

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

        public async Task<String> SendAssetAsync(SendAsset request)
        {
            String json = JsonConvert.SerializeObject(request);
            StringContent requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            String url = String.Format("{0}", _apiUrl);

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
            String url = String.Format("{0}", _apiUrl);

            return await Get(requestContent, url);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }

    [Obsolete]
    public class GetAddress
    {
        public String jsonrpc { get; set; }

        public String method { get; set; }

        public String id { get; set; }

        public GetAddress()
        {
            this.method = "hdwallet.getAddress";
            this.jsonrpc = "2.0";
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
}
