using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Infrastructure.Persistence.Configurations
{
    public class SubElementConfiguration : BaseEntityConfiguration<SubElement>
    {
        public override void Configure(EntityTypeBuilder<SubElement> builder)
        {
            builder.Property(o => o.Element).IsRequired();
            builder.Property(o => o.Type).HasMaxLength(256).IsRequired();
            builder.Property(o => o.Width).IsRequired();
            builder.Property(o => o.Height).IsRequired();            
        }

    }
}
