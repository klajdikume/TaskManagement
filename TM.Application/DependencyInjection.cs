using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace TM.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            })
            .AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            return services;
        }
    }
}