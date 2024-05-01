using Agenda.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Agenda.Infrastructure.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using DataContext dataContext = scope.ServiceProvider.GetRequiredService<DataContext>()!;

            if(dataContext.Database.GetPendingMigrations().Any())
                dataContext.Database.Migrate();
        }
    }
}
