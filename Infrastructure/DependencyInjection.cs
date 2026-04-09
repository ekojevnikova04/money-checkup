using Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IHostApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DB");

        builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));

        builder.Services.AddSingleton(TimeProvider.System);
    }
}