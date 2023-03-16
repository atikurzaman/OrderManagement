using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;
using System.Reflection;

namespace OrderManagement.Infrastructure.Persistence
{
    public class OrderDbContext : DbContext
    {

        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Window> Windows { get; set; }
        public DbSet<SubElement> SubElements { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
