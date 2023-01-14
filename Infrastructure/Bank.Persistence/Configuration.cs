using Microsoft.Extensions.Configuration;

namespace Bank.Persistence;

static class Configuration
{
    public static string ConnectionString
    {
        get
        {
            ConfigurationManager configurationManager = new ConfigurationManager();

            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/Bank.Api"));
            configurationManager.AddJsonFile("appsettings.json");

            return configurationManager.GetConnectionString("SqlServer");
        }
    }
}