using Agenda.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Agenda.Infrastructure.Data;
public class DatabaseConfig : IDatabaseConfig
{
    public string ConnectionString { get; set; }

    public DatabaseConfig()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        ConnectionString = configuration.GetConnectionString("ConnectionString")!;
    }

}