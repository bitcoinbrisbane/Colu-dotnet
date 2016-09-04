using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colu.Models.GetAssetData
{
    public class AssetData
    {
        [JsonProperty("utxo")]
        public String Utxo { get; set; }

        [JsonProperty("metadata")]
        public IList<MetaData> MetaData { get; set; }

        public AssetData()
        {
            this.MetaData = new List<MetaData>();
        }
    }
}
