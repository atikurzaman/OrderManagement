using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderManagement.Infrastructure.Persistence;
using OrderManagement.Infrastructure.Persistence.Repositories;

namespace OrderManagement.Infrastructure
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                 b => b.MigrationsAssembly(typeof(OrderDbContext).Assembly.FullName)
                ));

            services.AddTransient<ISubElementRepository, SubElementRepository>();
            services.AddTransient<IWindowRepository, WindowRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}