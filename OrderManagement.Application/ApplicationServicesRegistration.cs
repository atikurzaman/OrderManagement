using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using OrderManagement.Application.Mapping;
using System.Reflection;

namespace OrderManagement.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}