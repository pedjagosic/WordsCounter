using Microsoft.Extensions.Configuration;

namespace WebApi.Extensions
{
    internal static class ConfigurationExtensions
    {
        private const string HostNamePattern = "#HostName";
        private const string DatabaseNamePattern = "#DatabaseName";
        private const string DatabaseHostDefault = "(localdb)\\mssqllocaldb";
        private const string DatabaseNameDefault = "TextDb";
        private const string DatabaseConnectionConfigurationSection = "DatabaseConnection";
        private const string HostNameKey = "HostName";
        private const string DatabaseNameKey = "DatabaseName";

        private static readonly string SqlConnectionString =
            $"Server={HostNamePattern};Database={DatabaseNamePattern};Trusted_Connection=True;MultipleActiveResultSets=true;";

        public static string DatabaseConfiguration(
            this IConfiguration configuration)
        {
            var configurationSection = configuration
                .GetSection(DatabaseConnectionConfigurationSection);

            if (configurationSection == null) return GetDefaultDatabaseConfiguration();

            var hostName = configurationSection.GetValue<string>(HostNameKey);
            var databaseName = configurationSection.GetValue<string>(DatabaseNameKey);

            return SqlConnectionString
                 .Replace(HostNamePattern, hostName)
                 .Replace(DatabaseNamePattern, databaseName);
        }

        private static string GetDefaultDatabaseConfiguration()
            => SqlConnectionString
                 .Replace(HostNamePattern, DatabaseHostDefault)
                 .Replace(DatabaseNamePattern, DatabaseNameDefault);
    }
}
