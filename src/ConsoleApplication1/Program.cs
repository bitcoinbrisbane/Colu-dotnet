using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ColuClient client = new ColuClient())
            {
                var address = client.GetAddressAsync().Result;

                var stake = new GetStakeHoldersRequest()
                {
                    id = "1"
                };

                stake.Params.AssetId = "Ua9V5JgADia5zJdSnSTDDenKhPuTVc6RbeNmsJ";
                stake.Params.numConfirmations = "0";

                var x = client.GetStakeHoldersAsync(stake).Result;

                Asset asset = new Asset() { amount = 1, divisibility = 0 };
                //asset.amount = 1;
                //asset.divisibility = 0;
                //asset.issueAddress = "16mftBEkJgGpZdXx2Yh6cP7qbSa8cuPJJb";

                MetaData metadata = new MetaData(); // { key = "Description", value = "Membership" };
                metadata.Decription = "Annual Membership";

                asset.metadata = metadata;

                Transfer pud = new Transfer() { amount = 1 }; //address = "13r7hhidTLHo1tpu9aWxCvQx1FgKGbsJPv", 
                asset.transfer.Add(pud);

                To pudx = new To() { amount = 1, address = "13r7hhidTLHo1tpu9aWxCvQx1FgKGbsJPv" };

                SendAssetRequest request = new SendAssetRequest();
                request.param = asset;
                request.to.Add(pudx);

                var actual = client.SendAssetAsync(request).Result;
                
            }
        }
    }
}
