namespace WebAPI.Helpers
{

    public class ConfigurationHelper
    {
        private readonly IConfigurationRoot configuration;

        public ConfigurationHelper()
        {
            configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();
        }

        public string? GetConnectionString(string connectionStringName)
        {
            string? connectionString = configuration.GetConnectionString(connectionStringName);
            return connectionString;
        }
    }
}
