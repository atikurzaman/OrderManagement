using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Infrastructure.Persistence.Configurations
{
    public class WindowConfiguration : BaseEntityConfiguration<Window>, IEntityTypeConfiguration<Window>
    {
        public override void Configure(EntityTypeBuilder<Window> builder)
        {
            builder.Property(o => o.Name).HasMaxLength(256).IsRequired();
            builder.Property(o => o.QuantityOfWindows).IsRequired();
            builder.Property(o => o.TotalSubElements).IsRequired();            
        }

    }
}
