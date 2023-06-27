using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TM.Application.Projects.Validations;
using TM.Application.Tasks.Validations;

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

            services.AddValidatorsFromAssemblyContaining<CreateProjectCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<TaskDateValidatior>();

            return services;
        }
    }
}