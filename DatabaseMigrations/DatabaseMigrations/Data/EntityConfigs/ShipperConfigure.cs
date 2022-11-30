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
            builder.ToTable("Shippers");
            builder.HasKey(k => k.ShipperId);

            builder.Property(p => p.ShipperId).HasColumnName("ShipperId").IsRequired(true).HasColumnType("int").ValueGeneratedOnAdd();
            builder.Property(p => p.CompanyName).HasColumnName("CompanyName").IsRequired(true).HasColumnType("text").HasMaxLength(255);
            builder.Property(p => p.Phone).HasColumnName("Phone").IsRequired(true).HasColumnType("text").HasMaxLength(20);

            builder.HasMany(m => m.OrderList).WithOne(o => o.Shipper).HasForeignKey(k => k.ShipperId);
        }
    }
}
