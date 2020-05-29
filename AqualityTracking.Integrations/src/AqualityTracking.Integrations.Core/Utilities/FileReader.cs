using System;
using System.IO;

namespace AqualityTracking.Integrations.Core.Utilities
{
    public static class FileReader
    {
        private static readonly string ResourceFolder = "Resources";

        public static string ReadFromResources(string fileName)
        {
            var filePath = GetResourceFilePath(fileName);
            return File.ReadAllText(filePath);
        }

        private static string GetResourceFilePath(string fileName)
        {
            return Path.Combine(AppContext.BaseDirectory, ResourceFolder, fileName);
        }
    }
}
