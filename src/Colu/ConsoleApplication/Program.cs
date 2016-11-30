using Colu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            const String HOST = "http://colunode.cloudapp.net";
            const String USERNAME = "bitcoinbrisbane";
            const String PASSWORD = "Test1234";
            string a;

            using (IAddressClient client = new Client(HOST))
            {
                String id = Guid.NewGuid().ToString();
                var response = client.GetAddressAsync(id).Result;
                a = response.Address;
            }

            using (Client client = new Client(HOST))
            {
                var request = new Colu.Models.IssueAsset.Request()
                {
                    Id = Guid.NewGuid().ToString()
                };

                request.Param.Amount = 1000;
                request.Param.Divisibility = 0;
                request.Param.Reissueable = true;
                request.Param.IssueAddress = a;

                var actual = client.IssueAsync(request).Result;

            }
        }
    }
}
