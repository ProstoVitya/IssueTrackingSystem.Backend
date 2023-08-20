using IssueTrackingSystem.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IssueTrackingSystem.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["PostgresConnection"];
        services.AddDbContext<IssueDbContext>(options =>
            options.UseNpgsql(connectionString));
        services.AddScoped<IIssueDbContext>(provider => provider.GetService<IssueDbContext>());
        return services;
    }
}