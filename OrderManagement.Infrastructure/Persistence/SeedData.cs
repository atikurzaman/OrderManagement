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
                        Name = "New York Building 1",
                        State = "NY",
                        Windows = new List<Window>
                        {
                            new Window
                            {
                                Name = "A51",
                                QuantityOfWindows = 4,
                                TotalSubElements = 3,
                                SubElements = new List<SubElement>
                                {
                                    new SubElement { Element = 1, Type = "Doors", Width = 1200, Height = 1850 },
                                    new SubElement { Element = 2, Type = "Window", Width = 800, Height = 1850 },
                                    new SubElement { Element = 3, Type = "Window", Width = 700, Height = 1850 }
                                }
                            },
                            new Window
                            {
                                Name = "C Zone 5",
                                QuantityOfWindows = 2,
                                TotalSubElements = 1,
                                SubElements = new List<SubElement>
                                {
                                    new SubElement { Element = 1, Type = "Window", Width = 1500, Height = 2000 }                                   
                                }
                            }
                        }
                    },
                    new Order
                    {
                        Name = "California Hotel AJK",
                        State = "CA",
                        Windows = new List<Window>
                        {
                            new Window
                            {
                                Name = "GLB",
                                QuantityOfWindows = 3,
                                TotalSubElements = 2,
                                SubElements = new List<SubElement>
                                {
                                    new SubElement { Element = 1, Type = "Doors", Width = 1400, Height = 2200 },
                                    new SubElement { Element = 2, Type = "Window", Width = 600, Height = 2200 }                                    
                                }
                            },
                            new Window
                            {
                                Name = "OHF",
                                QuantityOfWindows = 10,
                                TotalSubElements = 2,
                                SubElements = new List<SubElement>
                                {
                                    new SubElement { Element = 1, Type = "Window", Width = 1500, Height = 2000 },
                                    new SubElement { Element = 1, Type = "Window", Width = 1500, Height = 2000 }
                                }
                            }
                        }
                    }
                };

                context.Orders.AddRange(orders);
                context.SaveChanges();
            }
        }
    }
}
