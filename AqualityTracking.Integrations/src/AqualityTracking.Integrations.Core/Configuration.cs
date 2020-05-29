using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace AqualityTracking.Integrations.Core
{
    public class Configuration
    {
        public bool Enabled { get; set; }

        public string Host { get; set; }

        public string Token { get; set; }

        public int ProjectId { get; set; }

        public string Executor { get; set; }

        public string SuiteName { get; set; }

        public string BuildName { get; set; }

        public string Environment { get; set; }

        public string CiBuild { get; set; }

        public bool Debug { get; set; }
    }
}
