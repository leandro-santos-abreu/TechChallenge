using Agenda.Domain.Services;
using Agenda.Infrastructure.Data;
using Agenda.Infrastructure.Interfaces;
using Agenda.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Api.Extensions
{
    public static class DependencyInjection
    {
        public static void ApplyDependencyInjection(WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IDatabaseConfig, DatabaseConfig>();
            builder.Services.AddScoped<IContactRepository, ContactRepository>();


            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionString"));
            });
        }
    }
}
