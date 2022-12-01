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
    public class OrderDetailConfigure : IEntityTypeConfiguration<OrderDetailEntity>
    {
        public void Configure(EntityTypeBuilder<OrderDetailEntity> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id);
            builder.Property(p => p.OrderId);
            builder.Property(p => p.ProductId);
            builder.Property(p => p.OrderNumber);
            builder.Property(p => p.Price);
            builder.Property(p => p.Discount);
            builder.Property(p => p.Total);

            builder.HasOne(o => o.Order).WithMany(m => m.Details).HasForeignKey(k => k.OrderNumber);
            builder.HasOne(o => o.Product).WithMany(m => m.Details).HasForeignKey(k => k.OrderNumber);
        }
    }
}
