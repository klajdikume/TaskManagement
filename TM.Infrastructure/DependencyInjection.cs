
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TM.Application.Data;
using TM.Domain.IRepositories;
using TM.Domain.Repositories;
using TM.Infrastructure.Repositories;

namespace TM.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options
                .UseSqlServer(configuration.GetConnectionString("dbCon")));

            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>(sp =>
             new ApplicationDbContext());

            return services;
        }
    }
}