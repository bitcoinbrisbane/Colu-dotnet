using Colu;
using System;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //const String HOST = "http://colunode.cloudapp.net";
            const String HOST = "http://60.226.74.183:8081"; // "http://192.168.0.9:8081";
            const String USERNAME = "bitcoinbrisbane";
            const String PASSWORD = "Test1234";


            const String VOUCHER_PUBLIC_KEY_HASH = "mqrRa9ETyDpS6jS91i6hEs6TsXhAwATzws";
            const String VOUCHER_ASSET_ID = "Ua84c979MsqkHrfrN5ojy6meXNmzyij6XFoocH";
            const String TEST_USER_ID = "mrtFz4tKAXSjBiN7mikE2CUWTerfR3cgMh";


            using (IAddressClient addressClient = new Client(HOST))
            {
                String id = Guid.NewGuid().ToString();
                //var response = addressClient.GetAddressAsync(id).Result;
                //String address = response.Result;

                using (Client client = new Client(HOST))
                {

                    var nm = client.GetMnemonicAsync().Result;

                    Colu.Models.SendAsset.Request request = new Colu.Models.SendAsset.Request()
                    {
                        Id = Guid.NewGuid().ToString()
                    };

                    request.param.From.Add(TEST_USER_ID);

                    request.param.To.Add(new Colu.Models.To()
                    {
                        Address = "n2T5RDM4kPLfd4mThzArHtdK9KN8mcDgxu",
                        Amount = 1,
                        AssetId = VOUCHER_ASSET_ID
                    });

                    try
                    {
                        var sendResponse = client.SendAssetAsync(request).Result;
                        //Models.RedeemResponseViewModel viewModel = new Models.RedeemResponseViewModel()
                        //{
                        //    TxId = response.Result.TxId
                        //};

                        //return View(viewModel);
                    }
                    catch (Exception ex)
                    {
                        //ViewBag.Error = ex.Message;
                    }

                    //var request = new Colu.Models.IssueAsset.Request()
                    //{
                    //    Id = Guid.NewGuid().ToString()
                    //};

                    //request.Param.Amount = 1000;
                    //request.Param.Divisibility = 0;
                    //request.Param.Reissueable = true;
                    //request.Param.IssueAddress = address;

                    //var actual = client.IssueAsync(request).Result;

                }
            }
        }
    }
}
