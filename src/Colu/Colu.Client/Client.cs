using Colu.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Colu.Client
{
    public class Client
    {
        private String coluHost;

        public Client(Settings settings)
        {
            //var mainnetColuHost = 'https://engine.colu.co'
            //var testnetColuHost = 'https://testnet.engine.colu.co'

            if (settings.Network == "Testnet")
            {
                coluHost = "https://testnet.engine.colu.co";
            }
            else
            {
                coluHost = "https://engine.colu.co";
            }
        }

        /// <summary>
        /// Get Address Info http://documentation.colu.co/#GetAddressInfo
        /// </summary>
        /// <param name="address">Asset address</param>
        /// <returns></returns>
        public async Task<GetAddressResponse> GetAddressInfoAsync(String address)
        {
            using (HttpClient client = new HttpClient())
            {
                String json = await client.GetStringAsync(String.Format("{0}/coloredcoins?func=addressinfo&address={1}", coluHost, address));
                GetAddressResponse response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetAddressResponse>(json);
                return response;
            }
        }
    }
}
