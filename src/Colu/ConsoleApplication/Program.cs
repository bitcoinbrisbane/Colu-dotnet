using Colu;
using System;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //const String HOST = "http://colunode.cloudapp.net";
            const String HOST = "http://192.168.0.9:8081";
            const String USERNAME = "bitcoinbrisbane";
            const String PASSWORD = "Test1234";

            using (IAddressClient addressClient = new Client(HOST))
            {
                String id = Guid.NewGuid().ToString();
                var response = addressClient.GetAddressAsync(id).Result;
                String address = response.Address;

                using (Client client = new Client(HOST))
                {
                    var request = new Colu.Models.IssueAsset.Request()
                    {
                        Id = Guid.NewGuid().ToString()
                    };

                    request.Param.Amount = 1000;
                    request.Param.Divisibility = 0;
                    request.Param.Reissueable = true;
                    request.Param.IssueAddress = address;

                    var actual = client.IssueAsync(request).Result;

                }
            }
        }
    }
}
