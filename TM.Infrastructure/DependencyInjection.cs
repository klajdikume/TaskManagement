
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TM.Application.Data;

namespace TM.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options
                .UseSqlServer(configuration.GetConnectionString("dbCon")));

            services.AddScoped<IApplicationDbContext>(sp =>
                sp.GetRequiredService<ApplicationDbContext>());

            return services;
        }
    }
}