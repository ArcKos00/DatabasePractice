using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.EntityConfigs
{
    public class ShipperConfigure : IEntityTypeConfiguration<ShipperEntity>
    {
        public void Configure(EntityTypeBuilder<ShipperEntity> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id);
            builder.Property(p => p.CompanyName).HasMaxLength(255);
            builder.Property(p => p.Phone).HasMaxLength(20);

            builder.HasMany(m => m.OrderList).WithOne(o => o.Shipper).HasForeignKey(k => k.ShipperId);
        }
    }
}
