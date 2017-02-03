using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Colu
{
    public abstract class BaseClient
    {
        //private const String MEDIA_TYPE = "application/json";

        internal String _host;
        internal String username;
        internal String password;

        internal async Task<String> Post(StringContent requestContent, String url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password))
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", username, password))));
                }

                using (HttpResponseMessage responseMessage = await httpClient.PostAsync(url, requestContent))
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        String responseContent = await responseMessage.Content.ReadAsStringAsync();
                        return responseContent;
                    }
                    else
                    {
                        //maybe here?
                        throw new InvalidOperationException();
                    }
                }
            }
        }
    }
}
