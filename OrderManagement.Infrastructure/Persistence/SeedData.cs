using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Infrastructure.Persistence
{
    public static class SeedData
    {
        public static void PopulateDb(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            AddInitialData(serviceScope.ServiceProvider.GetService<OrderDbContext>()!);
        }

        private static void AddInitialData(OrderDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Orders.Any())
            {
                var orders = new List<Order>()
                {
                    new Order
                    {
                        Name = "William",
                        State = "Shakespeare"
                    },
                    new Order
                    {
                        Name = "William",
                        State = "Shakespeare"
                    }
                };

                context.Orders.AddRange(orders);
                context.SaveChanges();                
            }
        }
    }
}
