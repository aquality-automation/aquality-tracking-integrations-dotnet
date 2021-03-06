﻿using static AqualityTracking.Integrations.Core.Utilities.EnvironmentReader;

namespace AqualityTracking.Integrations.Core.Configuration
{
    public class AqualityConfiguration : IConfiguration
    {
        private bool enabled;
        private string host;
        private string token;
        private int projectId;
        private string executor;
        private string suiteName;
        private string buildName;
        private string environment;
        private string ciBuild;
        private bool debug;

        public bool Enabled
        {
            get { return GetValueOrDefault("aquality.enabled", enabled); } 
            set { enabled = value; }
        }

        public string Host
        {
            get { return GetValueOrDefault("aquality.host", host); }
            set { host = value; }
        }

        public string Token
        {
            get { return GetValueOrDefault("aquality.token", token); }
            set { token = value; }
        }

        public int ProjectId
        {
            get { return GetValueOrDefault("aquality.projectId", projectId); }
            set { projectId = value; }
        }

        public string Executor
        {
            get { return GetValueOrDefault("aquality.executor", executor); }
            set { executor = value; }
        }

        public string SuiteName
        {
            get { return GetValueOrDefault("aquality.suiteName", suiteName); }
            set { suiteName = value; }
        }

        public string BuildName
        {
            get { return GetValueOrDefault("aquality.buildName", buildName); }
            set { buildName = value; }
        }

        public string Environment
        {
            get { return GetValueOrDefault("aquality.environment", environment); }
            set { environment = value; }
        }

        public string CiBuild
        {
            get { return GetValueOrDefault("aquality.ciBuild", ciBuild); }
            set { ciBuild = value; }
        }

        public bool Debug
        {
            get { return GetValueOrDefault("aquality.debug", debug); }
            set { debug = value; }
        }
    }
}
