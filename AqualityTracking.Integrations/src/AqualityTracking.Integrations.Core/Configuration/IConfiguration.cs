namespace AqualityTracking.Integrations.Core.Configuration
{
    public interface IConfiguration
    {
        bool Enabled { get; set; }

        string Host { get; set; }

        string Token { get; set; }

        int ProjectId { get; set; }

        string Executor { get; set; }

        string SuiteName { get; set; }

        string BuildName { get; set; }

        string Environment { get; set; }

        string CiBuild { get; set; }

        bool Debug { get; set; }
    }
}
