using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace OrderManagement.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IWindowService, WindowService>();
            services.AddScoped<ISubElementService, SubElementService>();

            return services;
        }
    }
}