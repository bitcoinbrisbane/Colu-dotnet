using Newtonsoft.Json;

namespace Colu.Models.IssueAsset
{
    public class Verification
    {
        [JsonProperty("domain")]
        public Domain Domain { get; set; }
    }
}
