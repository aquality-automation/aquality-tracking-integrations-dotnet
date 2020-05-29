using System;
using System.Collections.Generic;
using System.Linq;

namespace AqualityTracking.Integrations.Core.Utilities
{
    internal static class EnvironmentReader
    {
        /// <summary>
        /// Gets value of environment variable by key.
        /// </summary>
        /// <param name="key">Environment variable key.</param>
        /// <returns>Value of environment variable.</returns>
        internal static string GetVariable(string key)
        {
            return GetPossibleValues(key).FirstOrDefault();
        }

        private static IEnumerable<string> GetPossibleValues(string key)
        {
            yield return Environment.GetEnvironmentVariable(key);
            yield return Environment.GetEnvironmentVariable(key.ToLower());
            yield return Environment.GetEnvironmentVariable(key.ToUpper());
            yield return Environment.GetEnvironmentVariable(key.ToUpper().Replace('.', '_')); // Azure DevOps specific
        }
    }
}
