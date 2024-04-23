using Agenda.Domain.Interfaces;
using Agenda.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Api.Extensions
{
    public static class DependencyInjection
    {
        public static void ApplyDependencyInjection(WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IDatabaseConfig, DatabaseConfig>();

            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionString"));
            });
        }
    }
}
