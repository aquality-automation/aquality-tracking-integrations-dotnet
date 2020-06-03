using Newtonsoft.Json;
using System.Collections.Generic;

namespace AqualityTracking.Integrations.Core.Models
{
    public class Test
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("project_id")]
        public int? ProjectId { get; set; }

        [JsonProperty("suites")]
        public IList<Suite> Suites { get; set; }

        [JsonProperty("resolution_colors")]
        public string ResolutionColors { get; set; }

        [JsonProperty("result_colors")]
        public string ResultColors { get; set; }

        [JsonProperty("result_ids")]
        public string ResultIds { get; set; }
    }
}
