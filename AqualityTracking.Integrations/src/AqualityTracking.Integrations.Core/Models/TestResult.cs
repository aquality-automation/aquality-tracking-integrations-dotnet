using Newtonsoft.Json;

namespace AqualityTracking.Integrations.Core.Models
{
    public class TestResult
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("project_id")]
        public int? ProjectId { get; set; }

        [JsonProperty("test_id")]
        public int? TestId { get; set; }
        
        [JsonProperty("final_result_id")]
        public FinalResultId? FinalResultId { get; set; }
        
        [JsonProperty("test_run_id")]
        public int? TestRunId { get; set; }

        [JsonProperty("debug")]
        public int? Debug { get; set; }

        [JsonProperty("updated")]
        public string Updated { get; set; }
        
        [JsonProperty("start_date")]
        public string StartDate { get; set; }

        [JsonProperty("finish_date")]
        public string FinishDate { get; set; }

        [JsonProperty("final_result_updated")]
        public string FinalResultUpdated { get; set; }

        [JsonProperty("pending")]
        public int? Pending { get; set; }

        [JsonProperty("fail_reason")]
        public string FailReason { get; set; }
    }
}
