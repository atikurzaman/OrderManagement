using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagement.Domain.Entities;
using System.Diagnostics;
using System.Reflection.Emit;

namespace OrderManagement.Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : BaseEntityConfiguration<Order>, IEntityTypeConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.Name).HasMaxLength(256).IsRequired();
            builder.Property(o => o.State).HasMaxLength(256).IsRequired();            
        }

    }
}
