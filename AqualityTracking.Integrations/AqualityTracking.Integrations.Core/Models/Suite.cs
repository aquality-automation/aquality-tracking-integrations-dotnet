using Newtonsoft.Json;

namespace AqualityTracking.Integrations.Core.Models
{
    public class Suite
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("project_id")]
        public int? ProjectId { get; set; }
    }
}
