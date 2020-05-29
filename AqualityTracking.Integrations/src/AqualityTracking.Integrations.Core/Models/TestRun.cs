using Newtonsoft.Json;

namespace AqualityTracking.Integrations.Core.Models
{
    public class TestRun
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("build_name")]
        public string BuildName { get; set; }

        [JsonProperty("project_id")]
        public int? ProjectId { get; set; }
        
        [JsonProperty("start_time")]
        public string StartTime { get; set; }
        
        [JsonProperty("finish_time")]
        public string FinishTime { get; set; }

        [JsonProperty("test_suite_id")]
        public int? TestSuiteId { get; set; }

        [JsonProperty("debug")]
        public int? Debug { get; set; }

        [JsonProperty("label_id")]
        public int? LabelId { get; set; }

        [JsonProperty("ci_build")]
        public string CiBuild { get; set; }

        [JsonProperty("execution_environment")]
        public string ExecutionEnvironment { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("milestone_id")]
        public int? MilestoneId { get; set; }
    }
}
